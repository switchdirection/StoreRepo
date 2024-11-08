using Application.Images.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace StoreRepo.Models
{
    public class ImagesController : Controller
    {
        private readonly IImageService _imageService;
        public ImagesController(IImageService imageService)
        {
            _imageService = imageService;
        }

        [HttpGet("images/{imageId}")]
        public async Task<IActionResult> Get([FromRoute] int imageId, CancellationToken cancellation)
        {
            var image = await _imageService.GetImageDtoAsync(imageId, cancellation);

            return File(image.Data, image.ContentType);
        }

        [HttpPost]
        public async Task<IActionResult> UploadImages(List<IFormFile> ImageFiles, CancellationToken cancellation)
        {
            var imageUrls = await _imageService.SaveImagesAsync(ImageFiles, cancellation);

            return Json(imageUrls);
        }

        [HttpPost]
        public IActionResult DeleteImage([FromBody] string imageUrl)
        {
            return Ok();
        }
    }
}
