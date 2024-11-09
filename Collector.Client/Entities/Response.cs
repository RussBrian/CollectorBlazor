namespace Collector.Client.Entities
{
    public class Response <T> where T : class
    {
        public T? value {  get; set; }
        public bool isSuccess { get; set; } 
        public string errorMessage { get; set; } = string.Empty;
    }
}
