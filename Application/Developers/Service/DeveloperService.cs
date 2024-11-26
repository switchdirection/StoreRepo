using Application.Developers.Model;
using Application.Developers.Repository;
using AutoMapper;
using Contracts.Games;
using Contracts.Requests;
using Domain.Entities;

namespace Application.Developers.Service
{
    /// <summary>
    /// Сервис по работе с разработчиками
    /// </summary>
    public sealed class DeveloperService : IDeveloperService
    {
        private readonly IDeveloperRepository _developerRepository;
        private readonly IMapper _mapper;
        public DeveloperService(IDeveloperRepository developerRepository, IMapper mapper)
        {
            _developerRepository = developerRepository;
            _mapper = mapper;
        }
        /// <inheritdoc/>
        public async Task<bool> AddDeveloperAsync(string developerName, string developerWebsite, CancellationToken cancellation)
        {
            return await _developerRepository.AddDeveloperAsync(new DeveloperEntity 
            { 
                DeveloperName = developerName,
                WebsiteUrl = developerWebsite 
            }, cancellation);
        }

        /// <inheritdoc/>
        public async Task<bool> AddDeveloperByRequestAsync(AddDeveloperRequest request, CancellationToken cancellation)
        {
            try
            {
                await _developerRepository.AddDeveloperByRequestAsync(new DeveloperEntity
                {
                    DeveloperName = request.DeveloperName,
                    WebsiteUrl = request.DeveloperWebsite
                }, cancellation);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <inheritdoc/>
        public async Task<bool> DeleteDeveloperAsync(int developerId, CancellationToken cancellation)
        {
            try
            {
               await _developerRepository.DeleteDeveloperAsync(developerId, cancellation);
               return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <inheritdoc/>
        public async Task<bool> EditDeveloperAsync(EditDeveloperModel model, CancellationToken cancellation)
        {
            try
            {
                await _developerRepository.EditDeveloperAsync(model, cancellation);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <inheritdoc/>
        public async Task<List<DeveloperEntity>> GetAllDevelopersAsync(CancellationToken cancellation) 
        {
            return await _developerRepository.GetAllDevelopersAsync(cancellation);
        }

        /// <inheritdoc/>
		public async Task<List<DeveloperDto>> GetAllDevelopersDtoAsync(CancellationToken cancellation)
		{
            var developers = await _developerRepository.GetAllDevelopersAsync(cancellation);
            var developersDto = _mapper.Map<List<DeveloperDto>>(developers);
            return developersDto;
		}

        /// <inheritdoc/>
		public Task<DeveloperEntity> GetDeveloperByIdAsync(int id, CancellationToken cancellation)
        {
           return _developerRepository.GetDeveloperByIdAsync(id, cancellation);
        }
    }
}
