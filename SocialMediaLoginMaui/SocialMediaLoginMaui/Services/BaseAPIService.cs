using System.Text.Json;
namespace SocialMediaLoginMaui.Services
{
	public class BaseAPIService
	{
        #region Private Members
        private HttpClient _client;
        private JsonSerializerOptions _jsonSerializerOptions;
        #endregion

        #region Constructor
        public BaseAPIService()
		{
			_client = new HttpClient();

            _jsonSerializerOptions = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                NumberHandling = System.Text.Json.Serialization.JsonNumberHandling.AllowReadingFromString,
                WriteIndented = true,
            };
		}
        #endregion

        #region Public Method
        public async Task<T> PostRequest<T>(string url, object requestBody = null, string token = null)
        {
            try
            {
                StringContent requestContent = null;
                if (requestBody != null)
                {
                    string jsonBody = JsonSerializer.Serialize(requestBody, _jsonSerializerOptions);
                    requestContent = new StringContent(jsonBody, System.Text.Encoding.UTF8, "application/json");
                }

                System.Diagnostics.Debug.WriteLine($"API Request: {url}, End Time: {DateTime.Now}, Request: {requestContent}");
                HttpResponseMessage response = await _client.PostAsync(url, requestContent);
                System.Diagnostics.Debug.WriteLine($"API Response: {url}, End Time: {DateTime.Now}, Response: {response.Content}");

                string responseContent = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<T>(responseContent, _jsonSerializerOptions);
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Exception in PostRequest(): {ex.Message}");
                throw ex;
            }
        }

        public async Task<T> GetRequest<T>(string url, string token = null)
        {
            try
            {
                System.Diagnostics.Debug.WriteLine($"API Request: {url}, End Time: {DateTime.Now}");
                HttpResponseMessage response = await _client.GetAsync(url);
                System.Diagnostics.Debug.WriteLine($"API Response: {url}, End Time: {DateTime.Now}, Response: {response.Content}");

                string responseContent = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<T>(responseContent, _jsonSerializerOptions);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Exception in PostRequest(): {ex.Message}");
                throw ex;
            }
        }
        #endregion
    }
}

