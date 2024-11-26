using AutoMapper;
using Contracts.Games;
using Domain;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Storage;
using System.Reflection.Metadata;

namespace Infastructure.Mapper
{
    public sealed class GameMapperProfile : Profile
    {
        public GameMapperProfile()
        {
            CreateMap<GameEntity, ShortGameList>();
            CreateMap<ShortGameList, GameEntity>();
        }
    }
}
