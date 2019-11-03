using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WarhammerTracking.Data.Models
{
	public class Objective : Entity
	{
		[Required] public DateTime Date { get; set; }

		[Required] public virtual ApplicationUser Player { get; set; }

		public bool Done { get; set; }

		[MaxLength(20)] [Required] public string Title { get; set; }

		public string Description { get; set; }

		[NotMapped] public string PlayerUserName => Player != null ? Player.UserName : "";

		[NotMapped]
		[Obsolete("Don't use'", true)]
		public new string Name { get; set; }

		[NotMapped]
		[Obsolete("Don't use'", true)]
		public new string BattleScribeId { get; set; }

		[NotMapped]
		[Obsolete("Don't use'", true)]
		public new string BattleScribeRevision { get; set; }
	}
}