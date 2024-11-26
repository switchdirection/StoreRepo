using Application.Publishers.Model;
using Application.Publishers.Repository;
using AutoMapper;
using Contracts.Games;
using Contracts.Requests;
using Domain.Entities;
using System.Security.Policy;

namespace Application.Publishers.Service
{
    /// <summary>
    /// Сервис по работе с издателями
    /// </summary>
    public sealed class PublisherService : IPublisherService
    {
        private readonly IPublisherRepository _publisherRepository;
        private readonly IMapper _mapper;
        public PublisherService(IPublisherRepository publisherRepository, IMapper mapper)
        {
            _publisherRepository = publisherRepository;
            _mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<bool> AddPublisherByRequestAsync(AddPublisherRequest request, CancellationToken cancellation)
        {
            try
            {
                await _publisherRepository.AddPublisherByRequestAsync(new PublisherEntity
                {
                    PublisherName = request.PublisherName,
                    WebsiteUrl = request.PublisherWebsite
                }, cancellation);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <inheritdoc/>
        public async Task<bool> DeletePublisherAsync(int publisherId, CancellationToken cancellation)
        {
            try
            {
                await _publisherRepository.DeletePublisherAsync(publisherId, cancellation);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <inheritdoc/>
        public async Task<bool> EditPublisherAsync(EditPublisherModel model, CancellationToken cancellation)
        {
            try
            {
                await _publisherRepository.EditPublisherAsync(model, cancellation);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <inheritdoc/>
        public async Task<List<PublisherEntity>> GetAllPublishersAsync(CancellationToken cancellation)
        {
            return await _publisherRepository.GetAllPublishersAsync(cancellation);
        }

        /// <inheritdoc/>
		public async Task<List<PublisherDto>> GetAllPublishersDtoAsync(CancellationToken cancellation)
		{
            var publishers = await _publisherRepository.GetAllPublishersAsync(cancellation);
            var publisherDto = _mapper.Map<List<PublisherDto>>(publishers);
            return publisherDto;
		}

        /// <inheritdoc/>
		public Task<PublisherEntity> GetPublisherByIdAsync(int id, CancellationToken cancellation)
        {
            return _publisherRepository.GetPublisherByIdAsync(id, cancellation);
        }
    }
}
