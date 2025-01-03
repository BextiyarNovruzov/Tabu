﻿using AutoMapper;
using Tabu.DTOs.BannedWords;
using Tabu.Entites;

namespace Tabu.Profiles
{
    public class BannedWordProfile : Profile
    {
        public BannedWordProfile()
        {
            CreateMap<BannedWord, BannedWordGetDto>();
            CreateMap<BannedWord, BannedWordUpdateDto>().ReverseMap();
        }
    }
}
