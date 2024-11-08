using Domain.Entities;
using Contracts.Images;
using Microsoft.AspNetCore.Http;

namespace Application.Images.Services
{
    public interface IImageService
    {

        Task<ImageDto> GetImageDtoAsync(int id, CancellationToken cancellation);
        Task<IReadOnlyCollection<string>> SaveImagesAsync(List<IFormFile> ImageFiles, CancellationToken cancellation);
        Task<ImageEntity[]> SaveImageEntityAsync(string mainImageUrl, string[] imagesUrls, GameEntity gameEntity, CancellationToken cancellation);
        Task DeleteImageAsync(int imageId, CancellationToken cancellation);
    }
}
