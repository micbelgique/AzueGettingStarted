using AzureGettingStarted.Model;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AzureGettingStarted.Services
{
    public class VisionService
    {
        private readonly HttpClient _httpClient;
        public VisionService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<VisionResult> GetDetailsImage(string imageUrl)
        {
            var url = _httpClient.BaseAddress;
            var stringContent = new StringContent(imageUrl, Encoding.UTF8, "text/plain");
            var result = await _httpClient.PostAsync(url, stringContent);
            if (!result.IsSuccessStatusCode)
                return null;
            var resJson = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<VisionResult>(resJson);
        }
    }
}
