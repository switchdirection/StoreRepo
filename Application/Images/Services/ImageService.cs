using Application.Images.Handler;
using Application.Images.Repositories;
using Contracts.Images;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using System.Security.Policy;

namespace Application.Images.Services
{
    public sealed class ImageService : IImageService
    {
        private readonly IImageRepository _imageRepository;
        public ImageService(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }

        public async Task<ImageDto> GetImageDtoAsync(int id, CancellationToken cancellation)
        {
            var image = await _imageRepository.GetByIdAsync(id);

            return new ImageDto
            {
                Data = image.Content,
                ContentType = image.ContentType
            };
        }

        public async Task SaveImageAsync(IFormFile imageFile, CancellationToken cancellation)
        {
            var imageEntity = new ImageEntity
            {
                Name = imageFile.Name,
                Content = await GetByteArrayAsync(imageFile, cancellation),
                ContentType = imageFile.ContentType
            };
            var imageList = ImageHandler.GetImagesList();
            imageList.Add(imageEntity);
        }

        public async Task<ImageEntity[]> SaveImageEntityAsync(string[] imagesUrls, GameEntity gameEntity, CancellationToken cancellation)
        {
            if(imagesUrls == null || imagesUrls.Length == 0)
            {
                return [];
            }

            var result = new List<ImageEntity>(imagesUrls.Length);
            foreach (var imageUrl in imagesUrls) 
            {
                var imageId = ExtractImageId(imageUrl);
                var existingImage = await _imageRepository.GetByIdAsync(imageId);

                if(existingImage != null)
                {
                    throw new Exception("Изображение было не найдено. ImageService");
                }

                //existingImage.Game = gameEntity;
                gameEntity.Images.Add(existingImage);

                result.Add(existingImage);
            }

            return result.ToArray();
        }

        public static int ExtractImageId(string imageUrl)
        {
            int lastSlashIndext = imageUrl.LastIndexOf('/');
            if(lastSlashIndext != -1 && lastSlashIndext+1 < imageUrl.Length)
            {
                var stringId = imageUrl.Substring(lastSlashIndext+1);

                return int.Parse(stringId);
            }
            throw new Exception("Не удалось вытащить id изображения. ImageService");
        }

        public async Task<IReadOnlyCollection<string>> SaveImagesAsync(List<IFormFile> ImageFiles, CancellationToken cancellation)
        {
            var result = new List<string>(ImageFiles.Count);
            foreach (var imageFile in ImageFiles) 
            {
                await SaveImageAsync(imageFile, cancellation);
            }

            return result.ToArray();
        }

        private async Task<byte[]> GetByteArrayAsync(IFormFile imageFile, CancellationToken cancellation)
        {
            using var memoryStream = new MemoryStream();
            await imageFile.CopyToAsync(memoryStream, cancellation);

            return memoryStream.ToArray();
        }
    }
}
