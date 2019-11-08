using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WarhammerTracking.Data.Models
{
	public class GameTable : Entity
	{
		public string ImagePath { get; set; }

		public string ImageRelativePath
		{
			get
			{
				if (!string.IsNullOrEmpty(ImagePath))
				{
					return "../" + ImagePath;
				}
				return string.Empty;
			}
		}
		
		[NotMapped]
		[Obsolete("Don't use'", true)]
		public new string BattleScribeId { get; set; }

		[NotMapped]
		[Obsolete("Don't use'", true)]
		public new string BattleScribeRevision { get; set; }
	}
}