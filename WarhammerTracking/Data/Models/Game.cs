using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace WarhammerTracking.Data.Models
{
	public class Game : Entity
	{
		[Required] [DataType(DataType.Date)] public DateTime Date { get; set; }

		public string Note { get; set; }
		public string ListPlayer1 { get; set; }
		public string ListPlayer2 { get; set; }
		public string TableNumber { get; set; }
		public string ScenarioNumber { get; set; }
		public string Location { get; set; }
		public string Player1Id { get; set; }

		[Required] [ForeignKey("Player1Id")] public virtual ApplicationUser Player1 { get; set; }

		[NotMapped]
		public string Player1Name => Player1 != null ? Player1.UserName : "";

		public string Player2Id { get; set; }

		[Required] [ForeignKey("Player2Id")] public virtual ApplicationUser Player2 { get; set; }

		[NotMapped] public string Player2Name => Player2 != null ? Player2.UserName : "";

		public virtual Army ArmyPlayer1 { get; set; }

		[NotMapped] public string ArmyPlayer1Name => ArmyPlayer1 != null ? ArmyPlayer1.Name : "";

		public virtual Army ArmyPlayer2 { get; set; }

		[NotMapped]
		public string ArmyPlayer2Name => ArmyPlayer2 != null ? ArmyPlayer2.Name : "";

		public virtual ICollection<GameLine> GameLines { get; set; }
		public int CpPlayer1 { get; set; }
		public int CpPlayer2 { get; set; }

		[NotMapped]
		public int CpLeftPlayer1
		{
			get
			{
				return Player1 != null
					? GameLines.Where(line => line.Player == Player1)
						.Aggregate(CpPlayer1, (current, line) => current - line.CpUsed)
					: 0;
			}
		}

		[NotMapped]
		public int CpLeftPlayer2
		{
			get
			{
				return Player2 != null
					? GameLines.Where(line => line.Player == Player2)
						.Aggregate(CpPlayer2, (current, line) => current - line.CpUsed)
					: 0;
			}
		}

		[NotMapped]
		public int TotalPlayer1
		{
			get
			{
				return Player1 != null
					? GameLines.Where(line => line.Player == Player1)
						.Aggregate(CpPlayer1, (current, line) => current - line.Total)
					: 0;
			}
		}

		[NotMapped]
		public int TotalPlayer2
		{
			get
			{
				return Player2 != null
					? GameLines.Where(line => line.Player == Player2)
						.Aggregate(CpPlayer1, (current, line) => current - line.Total)
					: 0;
			}
		}

		[NotMapped]
		public int TotalMaelstromPlayer1
		{
			get
			{
				return Player1 != null
					? GameLines.Where(line => line.Player == Player1)
						.Aggregate(CpPlayer1, (current, line) => current - line.Maelstrom)
					: 0;
			}
		}

		[NotMapped]
		public int TotalMaelstromPlayer2
		{
			get
			{
				return Player2 != null
					? GameLines.Where(line => line.Player == Player2)
						.Aggregate(CpPlayer1, (current, line) => current - line.Maelstrom)
					: 0;
			}
		}

		[NotMapped]
		public int TotalEternalPlayer1
		{
			get
			{
				return Player1 != null
					? GameLines.Where(line => line.Player == Player1)
						.Aggregate(CpPlayer1, (current, line) => current - line.Eternal)
					: 0;
			}
		}

		[NotMapped]
		public int TotalEternalPlayer2
		{
			get
			{
				return Player2 != null
					? GameLines.Where(line => line.Player == Player2)
						.Aggregate(CpPlayer1, (current, line) => current - line.Eternal)
					: 0;
			}
		}

		[NotMapped]
		public int TotalKpPlayer1
		{
			get
			{
				return Player1 != null
					? GameLines.Where(line => line.Player == Player1)
						.Aggregate(CpPlayer1, (current, line) => current - line.Kp)
					: 0;
			}
		}

		[NotMapped]
		public int TotalKpPlayer2
		{
			get
			{
				return Player2 != null
					? GameLines.Where(line => line.Player == Player2)
						.Aggregate(CpPlayer1, (current, line) => current - line.Kp)
					: 0;
			}
		}

		[NotMapped]
		public int TotalOthersPlayer1
		{
			get
			{
				return Player1 != null
					? GameLines.Where(line => line.Player == Player1)
						.Aggregate(CpPlayer1, (current, line) => current - line.Others)
					: 0;
			}
		}

		[NotMapped]
		public int TotalOthersPlayer2
		{
			get
			{
				return Player2 != null
					? GameLines.Where(line => line.Player == Player2)
						.Aggregate(CpPlayer1, (current, line) => current - line.Others)
					: 0;
			}
		}

		[NotMapped]
		public int ScorePlayer1
		{
			get
			{
				int score;
				if (TotalPlayer1 >= TotalPlayer2)
				{
					if (TotalPlayer1 - TotalPlayer2 < 20)
						score = 20 - (TotalPlayer1 - TotalPlayer2);
					else
						score = 20;
				}
				else
				{
					if (TotalPlayer2 - TotalPlayer1 < 20)
						score = TotalPlayer2 - TotalPlayer1;
					else
						score = 0;
				}

				return score;
			}
		}

		[NotMapped]
		public int ScorePlayer2
		{
			get
			{
				int score;
				if (TotalPlayer1 >= TotalPlayer2)
				{
					if (TotalPlayer1 - TotalPlayer2 < 20)
						score = TotalPlayer1 - TotalPlayer2;
					else
						score = 0;
				}
				else
				{
					if (TotalPlayer2 - TotalPlayer1 < 20)
						score = TotalPlayer2 - TotalPlayer1;
					else
						score = 20;
				}

				return score;
			}
		}

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