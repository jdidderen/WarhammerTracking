using System.ComponentModel.DataAnnotations;

namespace WarhammerTracking.Data.Models
{
	public class Entity : IEntity
	{
		public string BattleScribeRevision { get; set; }

		[Key] public int Id { get; set; }

		[Required] public string Name { get; set; }

		public string BattleScribeId { get; set; }
	}
}