using AutoMapper;
using Contracts.Games;
using Domain.Entities;

namespace Infastructure.Mapper
{
	public sealed class DeveloperMapperProfile : Profile
	{
        public DeveloperMapperProfile()
        {
            CreateMap<DeveloperEntity, DeveloperDto>();
        }
    }
}
