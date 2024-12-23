using AutoMapper;
using Tabu.DTOs.Words;
using Tabu.Entites;

namespace Tabu.Profiles
{
    public class WordProfile : Profile
    {
        public WordProfile()
        {
            CreateMap<WordCreateDto, Word>();
            CreateMap<Word,WordUpdateDto>().ReverseMap();
            CreateMap<Word, WordGetDto>();
        }
    }
}
