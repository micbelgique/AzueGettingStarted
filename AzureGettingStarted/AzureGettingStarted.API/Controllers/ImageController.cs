using AzureGettingStarted.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using AzureGettingStarted.Repository;

namespace AzureGettingStarted.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IRepository<Image> _repository;
        public ImageController(Context dbContext)
        {
            _repository = new ImageRepository(dbContext);
        }
        [HttpGet]
        public IEnumerable<Image> GetAllImages()
        {
            return _repository.GetAll();
        }
        [HttpPost]
        public async Task<bool> AddImage(Image image)
        {
            return await _repository.Insert(image);
        }
    }
}