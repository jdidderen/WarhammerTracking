using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WarhammerTracking.Data;

namespace WarhammerTracking.GameRequest
{
    public class GameRequest
    {
        [Key]
        public int id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public string PlayerId { get; set; }
        [Required]
        [ForeignKey("PlayerId")]
        public ApplicationUser Player { get; set; }
        public bool Expired { get; set; }
        
    }
}