using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace WarhammerTracking.Components
{
	public class DataGridPage<TItem> : ComponentBase
	{
		[Parameter] public IEnumerable<TItem> Items { get; set; }
		[Parameter] public RenderFragment<TItem> GridRow { get; set; }
		[Parameter] public RenderFragment Column { get; set; }
		[Parameter] public RenderFragment Filters { get; set; }
		[Parameter] public int PageSize { get; set; }
		[Parameter] public string[] FilterList { get; set; }
		protected IEnumerable<TItem> ItemList { get; set; }
		private int _totalPages;
		protected int CurPage;
		private int _pagerSize;
		protected int StartPage;
		protected int EndPage;
		public string CurrentSortColumn = string.Empty;

		protected override async Task OnInitializedAsync()
		{
			_pagerSize = 5;
			CurPage = 1;
			if (Items != null)
			{
				ItemList = Items.Skip((CurPage - 1) * PageSize).Take(PageSize);
				_totalPages = (int) Math.Ceiling(Items.Count() / (decimal) PageSize);
				SetPagerSize();
			}
			else
			{
				ItemList = Items;
			}
		}

		protected void UpdateList(int currentPage)
		{
			ItemList = Items.Skip((currentPage - 1) * PageSize).Take(PageSize);
			CurPage = currentPage;
			StateHasChanged();
		}

		protected void NavigateToNextPage()
		{
			if (CurPage < _totalPages)
			{
				if (CurPage == EndPage)
				{
					SetPagerSize();
				}

				CurPage += 1;
			}

			UpdateList(CurPage);
		}

		protected void NavigateToPreviousPage()
		{
			if (CurPage > 1)
			{
				if (CurPage == StartPage)
				{
					SetPagerSize();
				}

				CurPage -= 1;
			}

			UpdateList(CurPage);
		}

		private void SetPagerSize()
		{
			if (EndPage < _totalPages)
			{
				StartPage = EndPage + 1;
				if (EndPage + _pagerSize < _totalPages)
				{
					EndPage = StartPage + _pagerSize - 1;
				}
				else
				{
					EndPage = _totalPages;
				}

				StateHasChanged();
			}
			else if (StartPage > 1)
			{
				EndPage = StartPage - 1;
				StartPage -= _pagerSize;
			}
		}

		public void SetFilters(Expression<Func<TItem, bool>> expression)
		{
			ItemList = Items.AsQueryable().Where(expression).ToList();
			StateHasChanged();
		}

		protected void Filtering(string value)
		{
			ItemList = new List<TItem>();
			if (string.IsNullOrEmpty(value))
			{
				Console.WriteLine("TEST 1");
				ItemList = Items;
			}
			else
			{
				foreach (var filter in FilterList)
				{
					Console.WriteLine("TEST 2");
					ItemList =
						ItemList.Union(Items.Where(x =>
							x.GetType().GetProperty(filter)?.GetValue(x).ToString().ToLower().IndexOf(value,
								StringComparison.OrdinalIgnoreCase) >= 0));
				}
			}
			StateHasChanged();
		}
		
		public void SortTable(string columnName, bool sort) /* Ascending = False - Descending = True */ 
		{
			ItemList = sort ? ItemList.OrderByDescending(x => x.GetType().GetProperty(columnName)?.GetValue(x, null)).ToList() : ItemList.OrderBy(x => x.GetType().GetProperty(columnName)?.GetValue(x, null)).ToList();
			CurrentSortColumn = columnName;
			StateHasChanged();
		}
	}
}