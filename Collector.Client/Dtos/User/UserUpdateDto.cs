namespace Collector.Client.Dtos.User
{
    public class UserUpdateDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? UserName { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public IFormFile? File { get; set; }
        public string? Image { get; set; }
        public string Address { get; set; } = "DEFAULT";
        public string? UserId { get; set; }
        public string ModifiedBy { get; set; } = "DEFAULT";
    }
}
