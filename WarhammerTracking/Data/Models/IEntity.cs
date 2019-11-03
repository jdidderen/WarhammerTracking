namespace WarhammerTracking.Data.Models
{
	public interface IEntity
	{
		int Id { get; set; }
		string Name { get; set; }
		string BattleScribeId { get; set; }
	}
}