using AutoMapper;
using Contracts.Orders;
using Domain.Entities;
namespace Infastructure.Mapper
{
    public class OrdersHistoryMapperProfile : Profile
    {
        public OrdersHistoryMapperProfile()
        {
            CreateMap<OrdersHistoryEntity, OrdersHistoryDto>();
        }
    }
}
