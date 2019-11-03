using System;
using System.Linq;
using System.Web;
using System.Xml;
using Microsoft.EntityFrameworkCore.Internal;
using WarhammerTracking.Data.Models;

namespace WarhammerTracking.Pages.Admin
{
	public class AdminPanelPage : BasePage
	{
		protected async void DownloadXml()
		{
			var myXmlDocument = new XmlDocument();
			myXmlDocument.Load("https://raw.githubusercontent.com/BSData/wh40k/master/Tyranids.cat");
			var catalogue = myXmlDocument.GetElementsByTagName("catalogue")[0];
			var army = await ArmyRepository.GetByBattleScribeId(catalogue.Attributes["id"].Value);
			if (army == null)
			{
				army = new Data.Models.Army
				{
					BattleScribeId = catalogue.Attributes["id"].Value,
					BattleScribeRevision = catalogue.Attributes["revision"].Value,
					Name = catalogue.Attributes["name"].Value
				};
				await ArmyRepository.Create(army);
			}

			var categoryNodeList = myXmlDocument.GetElementsByTagName("categoryEntry");
			foreach (XmlNode categoryNode in categoryNodeList)
			{
				var category = await CategoryRepository.GetByBattleScribeId(categoryNode.Attributes["id"].Value);
				var create = false;
				if (category == null)
				{
					create = true;
					category = new Category();
				}

				category.Name = HttpUtility.HtmlDecode(categoryNode.Attributes["name"].Value);
				category.BattleScribeId = categoryNode.Attributes["id"].Value;
				if (create)
				{
					await CategoryRepository.Create(category);
				}
				else
				{
					await CategoryRepository.Update(category);
				}
			}

			var unitList = myXmlDocument.GetElementsByTagName("selectionEntry");
			foreach (XmlNode unitNode in unitList)
			{
				if (!unitNode.Attributes["type"].Any() || unitNode.Attributes["type"].Value != "unit") continue;
				var create = false;
				var unit = await UnitRepository.GetByBattleScribeId(unitNode.Attributes["id"].Value);
				if (unit == null)
				{
					create = true;
					unit = new Data.Models.Unit();
				}

				unit.Name = unitNode.Attributes["name"].Value;
				unit.BattleScribeId = unitNode.Attributes["id"].Value;
				unit.Army = army;
				if (create)
				{
					await UnitRepository.Create(unit);
				}
				else
				{
					await UnitRepository.Update(unit);
				}

				var categoryLinkNodes = unitNode.ChildNodes.Cast<XmlNode>()
					.First(nc => nc.LocalName == "categoryLinks").Cast<XmlNode>()
					.Where(ncc => ncc.LocalName == "categoryLink");
				foreach (var categoryLinkNode in categoryLinkNodes)
				{
					var unitCateg = await UnitCategoryRepository.GetbyBattleScribeIds(
						categoryLinkNode.Attributes["targetId"].Value, unitNode.Attributes["id"].Value);
					if (unitCateg != null) continue;
					Console.WriteLine("CREATE CATEG");
					var category =
						await CategoryRepository.GetByBattleScribeId(categoryLinkNode.Attributes["targetId"].Value);
					if (category == null) continue;
					unitCateg = new UnitCategory
					{
						Unit = unit,
						Category = category
					};
					await UnitCategoryRepository.Create(unitCateg);
				}

				var keywordNodes = unitNode.ChildNodes.Cast<XmlNode>()
					.FirstOrDefault(nc => nc.LocalName == "profiles")?.Cast<XmlNode>()
					.FirstOrDefault(ncc =>
						ncc.LocalName == "profile" && ncc.Attributes["typeName"] != null &&
						ncc.Attributes["typeName"].Value == "Keywords")?.Cast<XmlNode>()
					.FirstOrDefault(atr => atr.LocalName == "characteristics")?.Cast<XmlNode>()
					.Where(atr => atr.LocalName == "characteristic");
				if (keywordNodes == null) continue;
				foreach (var keywordNode in keywordNodes)
				{
					var keyword = await KeywordRepository.GetByName(HttpUtility.HtmlDecode(keywordNode.InnerText));
					if (keyword == null)
					{
						keyword = new Keyword
						{
							Name = HttpUtility.HtmlDecode(keywordNode.InnerText)
						};
						await KeywordRepository.Create(keyword);
					}

					var unitKeyword = await UnitKeywordRepository.GetbyIds(keyword.Id, unit.Id);
					if (unitKeyword != null) continue;
					unitKeyword = new UnitKeyword
					{
						Unit = unit,
						Keyword = keyword
					};
					await UnitKeywordRepository.Create(unitKeyword);
				}
			}
		}
	}
}