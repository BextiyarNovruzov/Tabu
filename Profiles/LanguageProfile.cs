using AutoMapper;
using Tabu.DTOs.Languages;
using Tabu.Entites;

namespace Tabu.Profiles
{
    public class LanguageProfile : Profile
    {
        public LanguageProfile()
        {
            CreateMap<LanguageCreateDto, Language>()
                .ForMember(L => L.Icon, LCD => LCD.MapFrom(x => x.IconUrl));
            CreateMap<Language, LanguageGetDto>();
            CreateMap<Language, LanguageUpdateDto>().ReverseMap();

        }

    }
}
