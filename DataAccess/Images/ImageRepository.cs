﻿using Application.Images.Repositories;
using DataAccess.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Images
{
    /// <summary>
    /// Репозиторий по работе с изображениями
    /// </summary>
    public sealed class ImageRepository : EntityFrameworkCoreBaseRepository<ImageEntity>, IImageRepository
    {
        private readonly StoreDbContext _dbContext;
        public ImageRepository(StoreDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        /// <inheritdoc/>
        public Task<ImageEntity> GetByUrlAsync(string url, CancellationToken cancellation)
        {
            return _dbContext.Set<ImageEntity>().FirstOrDefaultAsync(x => x.ImageUrl == url, cancellation);
        }

        /// <inheritdoc/>
        public async Task<int> SaveAsync(ImageEntity image, CancellationToken cancellation)
        {
            await _dbContext.AddAsync(image, cancellation);
            await _dbContext.SaveChangesAsync(cancellation);

            return image.ImageId;
        }

        /// <inheritdoc/>
        public async Task DeleteImageAsync(int imageId, CancellationToken cancellation)
        {
            await _dbContext.Images.Where(i => i.ImageId == imageId).ExecuteDeleteAsync(cancellation);
        }
    }
}
