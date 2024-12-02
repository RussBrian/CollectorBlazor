using Microsoft.AspNetCore.Components.Forms;
using System.Text.Json.Serialization;

namespace Collector.Client.Dtos.Login
{
    public class ReqUserDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? UserName { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Identification { get; set; }
        public IFormFile? File { get; set; }
        public string Image { get; set; } = "DEFAULT";
        public string Gender { get; set; } = "M";
        public string Address { get; set; } = "DEFAULT";
        public string? Password { get; set; }
        public int RolId { get; set; }
        public bool IsMobileRegister { get; set; } = false;
        public string AddedBy { get; set; } = "ADMIN";

        [JsonIgnore]
        public string? ConfirmPassword { get; set; }

        [JsonIgnore]
        public string? ErrorMesagge { get; set; }

        [JsonIgnore]
        public bool IsSuccess { get; set; }

        [JsonIgnore]
        public bool isError { get; set; }
    } 
}
