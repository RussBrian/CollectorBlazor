using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Collector.Client.Dtos
{
    public class Response <T> where T : class
    {
        public T? Value {  get; set; }
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; } = string.Empty;
    }
}
