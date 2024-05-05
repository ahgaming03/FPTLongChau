using FPTLongChau.Areas.Admin.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace FPTLongChau.Models
{
	public class ApplicationUser : IdentityUser
	{
		[StringLength(50)]
		public string? FirstName { get; set; }
		[StringLength(50)]
		public string? LastName { get; set; }
		[Required]
		[MinLength(5)]
		public string? UserName { get; set; }
		public DateTime? Birthday { get; set; }
	}
}
