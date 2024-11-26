using AutoMapper;
using Contracts.Orders;
using Domain.Entities;

namespace Infastructure.Mapper
{
    public sealed class OrderMapperProfile : Profile
    {
        public OrderMapperProfile()
        {
            CreateMap<OrderEntity, OrderDto>();
        }
    }
}
