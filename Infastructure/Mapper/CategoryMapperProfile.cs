using AutoMapper;
using Contracts.Games;
using Domain.Entities;

namespace Infastructure.Mapper
{
    public sealed class CategoryMapperProfile : Profile
    {
        public CategoryMapperProfile()
        {
            CreateMap<CategoryEntity, CategoryListDto>();
        }
    }
}
