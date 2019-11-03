using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WarhammerTracking.Data.Models
{
	public class Keyword : Entity
	{
		[Required] public virtual ICollection<UnitKeyword> Units { get; set; }
	}

	public class UnitKeyword : Entity
	{
		public virtual Unit Unit { get; set; }
		public virtual Keyword Keyword { get; set; }

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