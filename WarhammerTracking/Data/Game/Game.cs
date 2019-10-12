using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace WarhammerTracking.Data.Game
{
    public class Game
    {
        [Key]
        public int id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public string Note { get; set; }
        public string ListPlayer1 { get; set; }
        public string ListPlayer2 { get; set; }
        public string TableNumber { get; set; }
        public string ScenarioNumber { get; set; }
        public string Location { get; set; }
        [Required]
        public ApplicationUser Player1 { get; set; }
        [NotMapped]
        public string Player1Name
        {
            get
            {
                if (Player1 != null)
                {
                    return Player1.UserName;
                }

                return "";
            }
        }
        [Required]
        public ApplicationUser Player2 { get; set; }
        [NotMapped]
        public string Player2Name => Player1 != null ? Player2.UserName : "";
        [Required]
        public Army.Army ArmyPlayer1 { get; set; }
        [NotMapped]
        public string ArmyPlayer1Name => ArmyPlayer1 != null ? ArmyPlayer1.name : "";
        [Required]
        public Army.Army ArmyPlayer2 { get; set; }
        [NotMapped]
        public string ArmyPlayer2Name
        {
            get
            {
                if (ArmyPlayer2 != null)
                {
                    return ArmyPlayer2.name;
                }

                return "";
            }
        }
        public ICollection<GameLine> GameLines { get; set; }
        public int CpPlayer1 { get; set; }
        public int CpPlayer2 { get; set; }
        [NotMapped]
        public int CpLeftPlayer1
        {
            get
            {
                int CpLeft = CpPlayer1;
                foreach (var line in GameLines)
                {
                    if (line.Player == Player1)
                    {
                        CpLeft -= line.CpUsed;
                    }
                }

                return CpLeft;
            }
        }
        [NotMapped]
        public int CpLeftPlayer2
        {
            get
            {
                int CpLeft = CpPlayer2;
                foreach (var line in GameLines)
                {
                    if (line.Player == Player2)
                    {
                        CpLeft -= line.CpUsed;
                    }
                }

                return CpLeft;
            }
        }
        [NotMapped]
        public int TotalPlayer1
        {
            get
            {
                int Total = 0;
                foreach (var line in GameLines)
                {
                    if (line.Player == Player1)
                    {
                        Total += line.Total;
                    }
                }

                return Total;
            }
        }
        [NotMapped]
        public int TotalPlayer2
        {
            get
            {
                int Total = 0;
                foreach (var line in GameLines)
                {
                    if (line.Player == Player2)
                    {
                        Total += line.Total;
                    }
                }
                return Total;
            }
        }
        [NotMapped]
        public int TotalMaelstromPlayer1
        {
            get
            {
                int Total = 0;
                foreach (var line in GameLines)
                {
                    if (line.Player == Player1)
                    {
                        Total += line.Maelstrom;
                    }
                }
                return Total;
            }
        }
        [NotMapped]
        public int TotalMaelstromPlayer2
        {
            get
            {
                int Total = 0;
                foreach (var line in GameLines)
                {
                    if (line.Player == Player2)
                    {
                        Total += line.Maelstrom;
                    }
                }
                return Total;
            }
        }
        [NotMapped]
        public int TotalEternalPlayer1
        {
            get
            {
                int Total = 0;
                foreach (var line in GameLines)
                {
                    if (line.Player == Player1)
                    {
                        Total += line.Eternal;
                    }
                }
                return Total;
            }
        }
        [NotMapped]
        public int TotalEternalPlayer2
        {
            get
            {
                int Total = 0;
                foreach (var line in GameLines)
                {
                    if (line.Player == Player2)
                    {
                        Total += line.Eternal;
                    }
                }
                return Total;
            }
        }
        [NotMapped]
        public int TotalKPPlayer1
        {
            get
            {
                int Total = 0;
                foreach (var line in GameLines)
                {
                    if (line.Player == Player1)
                    {
                        Total += line.KP;
                    }
                }
                return Total;
            }
        }
        [NotMapped]
        public int TotalKPPlayer2
        {
            get
            {
                int Total = 0;
                foreach (var line in GameLines)
                {
                    if (line.Player == Player2)
                    {
                        Total += line.KP;
                    }
                }
                return Total;
            }
        }
        [NotMapped]
        public int TotalOthersPlayer1
        {
            get
            {
                int Total = 0;
                foreach (var line in GameLines)
                {
                    if (line.Player == Player1)
                    {
                        Total += line.Others;
                    }
                }
                return Total;
            }
        }
        [NotMapped]
        public int TotalOthersPlayer2
        {
            get
            {
                int Total = 0;
                foreach (var line in GameLines)
                {
                    if (line.Player == Player2)
                    {
                        Total += line.Others;
                    }
                }
                return Total;
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
                    {
                        score = 20 - (TotalPlayer1 - TotalPlayer2);
                    }
                    else
                    {
                        score = 20;
                    }
                }
                else
                {
                    if (TotalPlayer2 - TotalPlayer1 < 20)
                    {
                        score = TotalPlayer2 - TotalPlayer1;
                    }
                    else
                    {
                        score = 0;
                    }
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
                    {
                        score = TotalPlayer1 - TotalPlayer2;
                    }
                    else
                    {
                        score = 0;
                    }
                }
                else
                {
                    if (TotalPlayer2 - TotalPlayer1 < 20)
                    {
                        score = TotalPlayer2 - TotalPlayer1;
                    }
                    else
                    {
                        score = 20;
                    }
                }
                return score;
            }
        }
    }
}