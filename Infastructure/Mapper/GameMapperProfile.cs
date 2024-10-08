using AutoMapper;
using Contracts.Games;
using Domain;
using Domain.Entities;
using System.Reflection.Metadata;

namespace Infastructure.Mapper
{
    public sealed class GameMapperProfile : Profile
    {
        public GameMapperProfile()
        {
            CreateMap<GameEntity, ShortGameList>();
        }
    }
}
