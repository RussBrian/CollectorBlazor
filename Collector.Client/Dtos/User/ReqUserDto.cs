using Microsoft.AspNetCore.Components.Forms;
using System.ComponentModel.DataAnnotations;

namespace Collector.Client.Dtos.Login
{
    public class ReqUserDto
    {
        public string? FirstName { get; set; } 
        public string? LastName { get; set; } 
        public string? UserName { get; set; }

        [EmailAddress]
        public string? Email { get; set; } 
        public string? Identification { get; set; } 
        public string? Phone { get; set; } 
        [MinLength(8)]
        public string? Password { get; set; } 

        [Compare("Password")]
        public string? ConfirmPassword { get; set; }

        public int RolId { get; set; }
        public bool IsMobileRegister { get; set; } = false;
        public string AddedBy { get; set; } = "ADMIN";
    }
}
