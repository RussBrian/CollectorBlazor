using System.ComponentModel.DataAnnotations;

namespace Collector.Client.Entities
{
    public class LoginViewModel
    {
        public string Email {  get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty ;
    }
}
