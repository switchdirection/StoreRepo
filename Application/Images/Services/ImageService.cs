using Application.Common;
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

        public async Task<string> SaveImageAsync(IFormFile imageFile, CancellationToken cancellation)
        {
            var imageEntity = new ImageEntity
            {
                Name = imageFile.Name,
                Content = await GetByteArrayAsync(imageFile, cancellation),
                ContentType = imageFile.ContentType
            };
            /*var imageList = ImageHandler.GetImagesList();
            imageList.Add(imageEntity);*/
            var imageId = await _imageRepository.SaveAsync(imageEntity, cancellation);

            return $"https://localhost:7013/images/{imageId}";
        }

        public async Task<ImageEntity[]> SaveImageEntityAsync(string mainImageUrl, string[] imagesUrls, GameEntity gameEntity, CancellationToken cancellation)
        {
            List<ImageEntity> result = null;
            if (mainImageUrl == null && (imagesUrls == null || imagesUrls.Length == 0))
            {
                return [];
            }
            
            
            if (mainImageUrl != null && (imagesUrls == null || imagesUrls.Length == 0))
            {
                result = new List<ImageEntity>(1);

                var mainImageId = ExtractImageId(mainImageUrl);
                var existingMainImage = await _imageRepository.GetByIdAsync(mainImageId);
                if (existingMainImage == null)
                {
                    throw new Exception("Главное изображение было не найдено. ImageService");
                }
                existingMainImage.ImageUrl = mainImageUrl;
                gameEntity.Images.Add(existingMainImage);
                result.Add(existingMainImage);
            }
            
            if (mainImageUrl == null && (imagesUrls != null || imagesUrls.Length != 0))
            {
                result = new List<ImageEntity>(imagesUrls.Length);

                foreach (var imageUrl in imagesUrls)
                {
                    var imageId = ExtractImageId(imageUrl);
                    var existingImage = await _imageRepository.GetByIdAsync(imageId);

                    if (existingImage == null)
                    {
                        throw new Exception("Изображение было не найдено. ImageService");
                    }

                    existingImage.ImageUrl = imageUrl;
                    gameEntity.Images.Add(existingImage);

                    result.Add(existingImage);
                }
                
            }
            else
            {
                result = new List<ImageEntity>(imagesUrls.Length+1);

                var mainImageId = ExtractImageId(mainImageUrl);
                var existingMainImage = await _imageRepository.GetByIdAsync(mainImageId);
                if (existingMainImage == null)
                {
                    throw new Exception("Главное изображение было не найдено. ImageService");
                }
                existingMainImage.ImageUrl = mainImageUrl;
                gameEntity.Images.Add(existingMainImage);
                result.Add(existingMainImage);

                foreach (var imageUrl in imagesUrls)
                {
                    var imageId = ExtractImageId(imageUrl);
                    var existingImage = await _imageRepository.GetByIdAsync(imageId);

                    if (existingImage == null)
                    {
                        throw new Exception("Изображение было не найдено. ImageService");
                    }

                    existingImage.ImageUrl = imageUrl;
                    gameEntity.Images.Add(existingImage);

                    result.Add(existingImage);
                }
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
                var imageUrl =  await SaveImageAsync(imageFile, cancellation);
                result.Add(imageUrl);
            }

            return result.ToArray();
        }

        private async Task<byte[]> GetByteArrayAsync(IFormFile imageFile, CancellationToken cancellation)
        {
            using var memoryStream = new MemoryStream();
            await imageFile.CopyToAsync(memoryStream, cancellation);

            return memoryStream.ToArray();
        }

        public async Task DeleteImageAsync(int imageId, CancellationToken cancellation)
        {
            await _imageRepository.DeleteImageAsync(imageId, cancellation);
        }
    }
}
