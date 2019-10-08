using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace WarhammerTracking.Data.Game
{
    public class GameLine
    {
        [Key]
        public int id { get; set; }
        public int GameId { get; set; }
        [Required]
        [ForeignKey("GameId")]
        public Game Game { get; set; }
        public string PlayerId { get; set; }
        [Required]
        [ForeignKey("PlayerId")]
        public ApplicationUser Player { get; set; }
        public int Maelstrom { get; set; }
        public int Eternal { get; set; }
        public int KP { get; set; }
        public int Others { get; set; }

        [NotMapped]
        public int Total => Maelstrom + Eternal + KP + Others;

        public int CpUsed { get; set; }
    }
}