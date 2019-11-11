using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AzureGettingStarted.Model;
using Newtonsoft.Json;

namespace AzureGettingStarted.Function
{
    public class PictureVision
    {
        public string Url { get; set; }
    }
    public static class VisionFunction
    {
        private static readonly string endpoint = "";
        private static readonly string key = "";
        private static readonly string parameter =
            "/vision/v2.0/analyze?visualFeatures=Adult,Brands,Categories,Color,Description,Faces,ImageType,Objects,Tags&language=en";
        private static HttpClient httpClient = new HttpClient();
        [FunctionName("VisionFunction")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            var urlImg = await new StreamReader(req.Body).ReadToEndAsync();
            var stringImg = JsonConvert.SerializeObject(new PictureVision
            {
                Url = urlImg
            });
            httpClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", key);
            var content = new StringContent(stringImg,Encoding.UTF8,"application/json");
            var result = await httpClient.PostAsync(endpoint + parameter, content);
            var resultObject = JsonConvert.DeserializeObject<VisionResult>(await result.Content.ReadAsStringAsync());
            return new OkObjectResult(resultObject);
        }
    }
}
