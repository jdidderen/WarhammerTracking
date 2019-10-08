using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WarhammerTracking.Data.Army
{
    public class Army
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
    }
}