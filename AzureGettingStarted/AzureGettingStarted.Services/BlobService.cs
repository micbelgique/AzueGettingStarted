using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace AzureGettingStarted.Services
{
    public class BlobService
    {
        private readonly HttpClient _httpClient;

        public BlobService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> AddAFile(Stream file, string name)
        {
            var streamContent = new StreamContent(file);
            var url = _httpClient.BaseAddress;
            var token = _httpClient.DefaultRequestHeaders.Authorization.Parameter;
            _httpClient.DefaultRequestHeaders.Authorization = null;
            _httpClient.DefaultRequestHeaders.Add("x-ms-blob-type", "BlockBlob");
            _httpClient.DefaultRequestHeaders.Add("x-ms-date", DateTime.UtcNow.ToString("U"));
            await _httpClient.PutAsync(url + name + token, streamContent);
            return url+name;
        }
    }
}
