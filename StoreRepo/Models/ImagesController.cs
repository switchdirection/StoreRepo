using Application.Images.Services;
using Microsoft.AspNetCore.Mvc;

namespace StoreRepo.Models
{
    /// <summary>
    /// Контроллер изображений
    /// </summary>
    public class ImagesController : Controller
    {
        private readonly IImageService _imageService;
        public ImagesController(IImageService imageService)
        {
            _imageService = imageService;
        }
        /// <summary>
        /// Метод контроллера для получения изображения
        /// </summary>
        /// <param name="imageId">Идентификатор изображения</param>
        /// <param name="cancellation"></param>
        [HttpGet("images/{imageId}")]
        public async Task<IActionResult> Get([FromRoute] int imageId, CancellationToken cancellation)
        {
            var image = await _imageService.GetImageDtoAsync(imageId, cancellation);

            return File(image.Data, image.ContentType);
        }
        /// <summary>
        /// Метод контроллера для загрузки изображения
        /// </summary>
        /// <param name="ImageFiles">Выбранное изображение</param>
        /// <param name="cancellation">Токен отмены</param>
        [HttpPost]
        public async Task<IActionResult> UploadImages(List<IFormFile> ImageFiles, CancellationToken cancellation)
        {
            var imageUrls = await _imageService.SaveImagesAsync(ImageFiles, cancellation);

            return Json(imageUrls);
        }
        /// <summary>
        /// Метод контроллера для удаления изображения
        /// </summary>
        /// <param name="imageUrl">Ссылка на изображение</param>
        [HttpPost]
        public IActionResult DeleteImage([FromBody] string imageUrl)
        {
             //TODO
            return Ok();
        }
    }
}
