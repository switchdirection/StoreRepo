using AutoMapper;
using Contracts.Games;
using Domain.Entities;

namespace Infastructure.Mapper
{
    public sealed class PlatformMapperProfile : Profile
    {
        public PlatformMapperProfile()
        {
            CreateMap<PlatformEntity, PlatformDto>();
        }
    }
}
