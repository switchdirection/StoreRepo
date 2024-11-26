using AutoMapper;
using Contracts.Games;
using Domain.Entities;

namespace Infastructure.Mapper
{
    public sealed class PublisherMapperProfile : Profile
    {
        public PublisherMapperProfile()
        {
            CreateMap<PublisherEntity, PublisherDto>();
        }
    }
}
