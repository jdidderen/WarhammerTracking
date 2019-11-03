using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WarhammerTracking.Data.Models
{
	public class Unit : Entity
	{
		[Required] public virtual Army Army { get; set; }

		public virtual ICollection<UnitCategory> Categories { get; set; }
		public virtual ICollection<UnitKeyword> Keywords { get; set; }
	}
}