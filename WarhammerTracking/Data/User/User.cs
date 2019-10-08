using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace WarhammerTracking.Data
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Game.Game> Player1Games { get; set; }
        public ICollection<Game.Game> Player2Games { get; set; }
        public ICollection<Game.GameLine> GameLines { get; set; }
        public ICollection<GameRequest.GameRequest> GameRequests { get; set; }
        
        [NotMapped]
        public string Password { get; set; }

        [NotMapped]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required] 
        public override string Email { get; set; }
    }
}