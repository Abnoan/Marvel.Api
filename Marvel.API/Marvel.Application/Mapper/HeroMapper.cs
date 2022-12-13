using AutoMapper;
using Marvel.Application.Commands.Create;
using Marvel.Application.ViewModels;
using Marvel.Domain.Battle;
using Marvel.Domain.Entities;

namespace Marvel.Application.Mapper
{
    public class HeroMapper : Profile
    {
        public HeroMapper()
        {
            CreateMap<Hero, CreateHeroCommand>()
                .ReverseMap();

            CreateMap<Hero, HeroViewModel>()
                .ReverseMap();

            CreateMap<HeroViewModel, Attacker>()
                .ReverseMap();

            CreateMap<HeroViewModel, Defender>()
                .ReverseMap();
        }
    }
}
