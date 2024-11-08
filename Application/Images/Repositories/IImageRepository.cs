using Application.Common;
using Domain.Entities;

namespace Application.Images.Repositories
{
    public interface IImageRepository : IRepository<ImageEntity>
    {
        Task<ImageEntity> GetByUrlAsync(string url, CancellationToken cancellation);
        Task<int> SaveAsync(ImageEntity image, CancellationToken cancellation);
        Task DeleteImageAsync(int imageId, CancellationToken cancellation);
    }
}
