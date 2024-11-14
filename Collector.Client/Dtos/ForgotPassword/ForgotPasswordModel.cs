namespace Collector.Client.Dtos.ForgotPassword
{
    public class ForgotPasswordModel
    {
        public int Code { get; set; }
        public string? Email { get; set; }
        public string? NewPassword { get; set; }
        public string? ConfirmPassword { get; set; }
        public string? ErrorMessage { get; set; }
        public bool IsError { get; set; }
    }
}
