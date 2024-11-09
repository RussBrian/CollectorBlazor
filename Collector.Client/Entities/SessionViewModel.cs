namespace Collector.Client.Entities
{
    public class SessionViewModel
    {
        public string UserId { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string IdToken { get; set; } = null!;
        public string RolName { get; set; } = null!;
        public string Image { get; set; } = null!;
    }
}
