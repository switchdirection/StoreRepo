using AutoMapper;
using Contracts.Roles;
using Domain.Entities;
namespace Infastructure.Mapper
{
    public sealed class RoleMapperProfile : Profile
    {
        public RoleMapperProfile()
        {
            CreateMap<ApplicationRole, RoleDto>();
        }
    }
}
