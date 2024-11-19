using Newtonsoft.Json;

namespace Collector.Client.Utilities.Extensions
{
    public class HttpClientServiceExtensions
    {
        private readonly HttpClient _httpClient;

        public HttpClientServiceExtensions(IHttpClientFactory clientFactory)
        {
            _httpClient = clientFactory.CreateClient();
        }

        //Paso a paso para llamar a estos metodos de forma correcta.
        //Dirigirse a la carpeta service, al archivo "ExampleService", este permitira que puedan ver como crear los metodos para consumir estos servicios.


        public async Task<object?> CustomGetAsync<TResponse>(string uri, object? identifier = null)
        {
            string fullUri = $"{uri}{identifier}";

            Uri url = new(fullUri);

            HttpResponseMessage response = await _httpClient.GetAsync(url);

            _ = response.IsSuccessStatusCode ? true : throw new AggregateException($"Error al cargar la respuesta - StatusCode {response.StatusCode}");

            string result = await response.Content.ReadAsStringAsync();

            return result.TrimStart().StartsWith("[")
                ? JsonConvert.DeserializeObject<List<TResponse>>(result)
                : JsonConvert.DeserializeObject<TResponse>(result);

        }

        public async Task<TResponse?> CustomPostAsync<TResponse, TRequest>(string uri, TRequest request)
        {
            // Esta url la deben pasar por el parametro del metodo, puede ser una referencia a la propiedad.
            Uri url = new(uri);

            HttpResponseMessage response = await _httpClient.PostAsJsonAsync(url, request);

            ////Esto es solo una validacion simple
            //_ = response.IsSuccessStatusCode ? true : throw new AggregateException($"Error al cargar la respuesta - StatusCode {response.StatusCode}");

            string result = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<TResponse>(result);
        }
    }
}
