using asp_net_course_udemy.Dtos.Character;
using asp_net_course_udemy.Models;
using AutoMapper;

namespace asp_net_course_udemy
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Character, GetCharacterDTO>();
            CreateMap<AddCharacterDTO, Character>();
        }
    }
}