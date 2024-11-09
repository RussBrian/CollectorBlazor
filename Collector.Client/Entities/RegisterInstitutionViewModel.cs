using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Components.Forms;

namespace Collector.Client.Entities;

public class RegisterInstitutionViewModel
{
    public string Name { get; set; }
    public string RNC { get; set; }
    public string Representative { get; set; }
    
    [EmailAddress]
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    
    [MinLength(8)]
    public string Password { get; set; } = string.Empty;

    [Compare("Password")]
    public string ConfirmPassword { get; set; } = string.Empty;
    public IBrowserFile? ProfileImage { get; set; }
}