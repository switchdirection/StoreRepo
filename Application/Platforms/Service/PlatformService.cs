using Application.Platforms.Model;
using Application.Platforms.Repository;
using AutoMapper;
using Contracts.Games;
using Domain.Entities;

namespace Application.Platforms.Service
{
    /// <summary>
    /// Сервис по работе с платформами
    /// </summary>
    public sealed class PlatformService : IPlatformService
    {
        private readonly IPlatformRepository _platformRepository;
        private readonly IMapper _mapper;
        public PlatformService(IPlatformRepository platformRepository, IMapper mapper)
        {
            _platformRepository = platformRepository;
            _mapper = mapper;
        }
        /// <inheritdoc/>
        public async Task<bool> AddPlatformAsync(string platformName, CancellationToken cancellation)
        {
            try
            {
                await _platformRepository.AddPlatformAsync(platformName, cancellation);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <inheritdoc/>
        public async Task<bool> DeletePlatformAsync(int platformId, CancellationToken cancellation)
        {
            try
            {
                await _platformRepository.DeletePlatformAsync(platformId, cancellation);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <inheritdoc/>
        public async Task<bool> EditPlatformAsync(EditPlatformModel model, CancellationToken cancellation)
        {
            try
            {
                await _platformRepository.EditPlatformAsync(model, cancellation);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <inheritdoc/>
        public Task<PlatformEntity> GeetPlatformByIdAsync(int id, CancellationToken cancellation)
        {
            return _platformRepository.GeetPlatformByIdAsync(id, cancellation);
        }

        /// <inheritdoc/>
        public async Task<List<PlatformEntity>> GetAllPlatformsAsync(CancellationToken cancellation)
        {
            return await _platformRepository.GetAllPlatformsAsync(cancellation);
        }

        /// <inheritdoc/>
		public async Task<List<PlatformDto>> GetAllPlatformsDtoAsync(CancellationToken cancellation)
		{
            var platforms = await _platformRepository.GetAllPlatformsAsync(cancellation);
            var platformsDto = _mapper.Map<List<PlatformDto>>(platforms);
            return platformsDto;
		}
	}
}
