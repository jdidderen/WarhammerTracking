using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace WarhammerTracking.Data.Army
{
    public class Faction
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        public int ArmyId { get; set; }
        [Required]
        [ForeignKey("ArmyId")]
        public Army army { get; set; }
    }
}