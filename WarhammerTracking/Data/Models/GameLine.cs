using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WarhammerTracking.Data.Models
{
	public class GameLine : Entity
	{
		[Required] public virtual Game Game { get; set; }

		[Required] public virtual ApplicationUser Player { get; set; }

		public int Maelstrom { get; set; }
		public int Eternal { get; set; }
		public int Kp { get; set; }
		public int Others { get; set; }
		public int CpUsed { get; set; }

		[NotMapped] public int Total => Maelstrom + Eternal + Kp + Others;

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