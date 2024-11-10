namespace Collector.Client.Services.Register;

public class ReqRegistrationDto
{
    public string FristName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Identification { get; set; }
    public byte[] File { get; set; }   
    public string Gender { get; set; }
    public string Address { get; set; }
    public string Password { get; set; }
    public string RoleId { get; set; }
    public string Image { get; set; }
}