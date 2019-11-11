using AzureGettingStarted.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using AzureGettingStarted.Repository;
using AzureGettingStarted.Services;
using Microsoft.AspNetCore.Http;

namespace AzureGettingStarted.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IRepository<Image> _repository;
        private readonly VisionService _visionService;
        private readonly BlobService _blobService;
        public ImageController(Context dbContext, VisionService visionService,BlobService blobService)
        {
            _visionService = visionService;
            _blobService = blobService;
            _repository = new ImageRepository(dbContext);
        }
        [HttpGet]
        public IEnumerable<Image> GetAllImages()
        {
            return _repository.GetAll();
        }
        [HttpPost]
        public async Task<bool> AddImage(IFormFile image)
        {
            if (image.Length <= 0) return false;
            var data = image.OpenReadStream();
            var urlBlob = await _blobService.AddAFile(data,image.FileName);
            var visionResult = await _visionService.GetDetailsImage(urlBlob);
            var imageResult = new Image
            {
                Url = urlBlob,
                VisionResult = visionResult
            };
            return true;
            //return await _repository.Insert(image);
        }
    }
}