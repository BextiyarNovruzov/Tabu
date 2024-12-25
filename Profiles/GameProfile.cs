using AutoMapper;
using Tabu.DTOs.Games;
using Tabu.Entites;

namespace Tabu.Profiles
{
    public class GameProfile:Profile
    {
        public GameProfile()
        {
            CreateMap<GameCreateDto, Game>();
        }
    }
}
