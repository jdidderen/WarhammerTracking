using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace WarhammerTracking.Data.Models
{
	public class ApplicationUser : IdentityUser
	{
		public virtual ICollection<Game> Player1Games { get; set; }
		public virtual ICollection<Game> Player2Games { get; set; }
		public virtual ICollection<GameLine> GameLines { get; set; }
		public virtual ICollection<GameRequest> GameRequests { get; set; }
		public virtual ICollection<Objective> Objectives { get; set; }

		[NotMapped] public string Password { get; set; }

		[NotMapped]
		[Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
		public string ConfirmPassword { get; set; }

		[Required] public override string Email { get; set; }
	}
}