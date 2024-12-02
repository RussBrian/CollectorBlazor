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

        #region Method for Get
        public async Task<object?> CustomGetAsync<TResponse>(string uri, object? identifier = null)
        {
            string fullUri = $"{uri}/{identifier}";

            Uri url = new(fullUri);
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(url);

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

            foreach (var property in typeof(TRequest).GetProperties())
            {
                var value = property.GetValue(request);

                // Si la propiedad es una lista de archivos (ejemplo: List<IFormFile>)
                if (value is IEnumerable<IFormFile> files)
                {
                    int index = 0;
                    foreach (var file in files)
                    {
                        var fileContent = new StreamContent(file.OpenReadStream());
                        fileContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(file.ContentType);
                        content.Add(fileContent, $"{property.Name}", file.FileName);
                        index++;
                    }
                }
                else if (value != null)
                {
                    // Para propiedades simples, convertir a texto
                    content.Add(new StringContent(value.ToString()!), property.Name);
                }
            }

            try
            {
                HttpResponseMessage response = await _httpClient.PostAsync(url, content);

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

        public async Task<TResponse?> CustomFormDataReportAsync<TResponse, TRequest>(string uri, TRequest request)
        {
            Uri url = new(uri);

            using MultipartFormDataContent content = [];

            foreach(var property in typeof(TRequest).GetProperties())
            {
                var value = property.GetValue(request);

                // Si la propiedad es una lista de archivos (ejemplo: List<IFormFile>)
                if (value is IEnumerable<IFormFile> files)
                {
                    int index = 0;
                    foreach (var file in files)
                    {
                        var fileContent = new StreamContent(file.OpenReadStream());
                        fileContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(file.ContentType);
                        content.Add(fileContent, $"{property.Name}", file.FileName);
                        index++;
                    }
                }
                else if (value != null)
                {
                    // Para propiedades simples, convertir a texto
                    content.Add(new StringContent(value.ToString()!), property.Name);
                }
            }

            try
            {
                HttpResponseMessage response = await _httpClient.PostAsync(url, content);

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
        public async Task<TResponse?> CustomPutFormDataAsync<TResponse, TRequest>(string uri, TRequest request)
        {
            Uri url = new(uri);

            using MultipartFormDataContent content = [];

            foreach (var property in typeof(TRequest).GetProperties())
            {
                var value = property.GetValue(request);

                // Si la propiedad es una lista de archivos (ejemplo: List<IFormFile>)
                if (value is IEnumerable<IFormFile> files)
                {
                    int index = 0;
                    foreach (var file in files)
                    {
                        var fileContent = new StreamContent(file.OpenReadStream());
                        fileContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(file.ContentType);
                        content.Add(fileContent, $"{property.Name}", file.FileName);
                        index++;
                    }
                }
                else if (value != null)
                {
                    // Para propiedades simples, convertir a texto
                    content.Add(new StringContent(value.ToString()!), property.Name);
                }
            }

            try
            {
                HttpResponseMessage response = await _httpClient.PutAsync(url, content);

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

        public async Task<TResponse?> CustomPutFormDataReportAsync<TResponse, TRequest>(string uri, TRequest request)
        {
            Uri url = new(uri);

            using MultipartFormDataContent content = [];

            foreach (var property in typeof(TRequest).GetProperties())
            {
                var value = property.GetValue(request);

                // Si la propiedad es una lista de archivos (ejemplo: List<IFormFile>)
                if (value is IEnumerable<IFormFile> files)
                {
                    int index = 0;
                    foreach (var file in files)
                    {
                        var fileContent = new StreamContent(file.OpenReadStream());
                        fileContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(file.ContentType);
                        content.Add(fileContent, $"{property.Name}", file.FileName);
                        index++;
                    }
                }
                else if (value != null)
                {
                    // Para propiedades simples, convertir a texto
                    content.Add(new StringContent(value.ToString()!), property.Name);
                }
            }

            try
            {
                HttpResponseMessage response = await _httpClient.PutAsync(url, content);

                string result = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<TResponse>(result);
            }
            catch (HttpRequestException ex)
            {
                throw new AggregateException("Error al realizar la solicitud HTTP - ", ex);
            }
            catch (Exception ex)
            {
                throw new AggregateException("Error general al procesar la solicitud - ", ex);
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
