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

        #region Method for Get
        public async Task<object?> CustomGetAsync<TResponse>(string uri, object? identifier = null)
        {
            string fullUri = $"{uri}{identifier}";

            Uri url = new(fullUri);
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                {  
                    throw new Exception($"Error al cargar la respuesta - StatusCode {response.StatusCode}");
                }

                string result = await response.Content.ReadAsStringAsync();

                return result.TrimStart().StartsWith("[")
                    ? JsonConvert.DeserializeObject<List<TResponse>>(result)
                    : JsonConvert.DeserializeObject<TResponse>(result);
            }
            catch (HttpRequestException ex)
            {
                throw new AggregateException("Error al realizar la solicitud HTTP.", ex);
            }
            catch (Exception ex)
            {
                throw new AggregateException("Error general al procesar la solicitud.", ex);
            }
     

        }
        #endregion

        #region Methods for Post
        public async Task<TResponse?> CustomPostAsync<TResponse, TRequest>(string uri, TRequest request)
        {
            Uri url = new(uri);

            try
            {
                HttpResponseMessage response = await _httpClient.PostAsJsonAsync(url, request);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Error al cargar la respuesta - StatusCode {response.StatusCode}");
                }

                string result = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<TResponse>(result);
            }
            catch (HttpRequestException ex)
            {
                throw new AggregateException("Error al realizar la solicitud HTTP.", ex);
            }
            catch (Exception ex)
            {
                throw new AggregateException("Error general al procesar la solicitud.", ex);
            }          
        }
        public async Task<TResponse?> CustomFormDataAsync<TResponse, TRequest>(string uri, TRequest request)
        {
            Uri url = new(uri);

            using MultipartFormDataContent content = [];

            foreach(var property in typeof(TRequest).GetProperties())
            {
                string? value = property.GetValue(request)?.ToString();

                content.Add(new StringContent(value), property.Name);
            }

            try
            {
                HttpResponseMessage response = await _httpClient.PostAsync(url, content);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Error al cargar la respuesta - StatusCode {response.StatusCode}");
                }

                string result = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<TResponse>(result);
            }
            catch (HttpRequestException ex)
            {
                throw new AggregateException("Error al realizar la solicitud HTTP.", ex);
            }
            catch (Exception ex)
            {
                throw new AggregateException("Error general al procesar la solicitud.", ex);
            }

        }
        #endregion

        #region Method for Put
        public async Task<TResponse?> CustomPutAsync<TResponse, TRequest>(string uri, TRequest request)
        {
            Uri url = new(uri);

            using MultipartFormDataContent content = new();

            foreach (var property in typeof(TRequest).GetProperties())
            {
                string? value = property.GetValue(request)?.ToString();

                if (value != null)
                {
                    content.Add(new StringContent(value), property.Name);
                }
            }

            try
            {
                HttpResponseMessage response = await _httpClient.PutAsync(url, content);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Error al cargar la respuesta - StatusCode {response.StatusCode}");
                }

                string result = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<TResponse>(result);
            }
            catch (HttpRequestException ex)
            {
                throw new AggregateException("Error al realizar la solicitud HTTP - ", ex);
            }
            catch (Exception ex)
            {
                throw new AggregateException("Error general al procesar la solicitud - ",ex);
            }
        }
        #endregion

        #region Method for Delete
        public async Task CustomDeleteAsync(string uri, object? identifier = null)
        {
            string fullUri = identifier != null ? $"{uri}/{identifier}" : uri;

            Uri url = new(fullUri);

            try
            {
                HttpResponseMessage response = await _httpClient.DeleteAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Error al realizar la operación DELETE - StatusCode {response.StatusCode}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new AggregateException("Error al realizar la solicitud HTTP.", ex);
            }
            catch (Exception ex)
            {
                throw new AggregateException("Error general al procesar la solicitud.", ex);
            }
        }
        #endregion

    }
}
