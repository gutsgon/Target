
using AutoMapper;
using Target.Dto;
using Target.Models;

namespace Target.Config.mapper
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<DiaValorDto, DiaValorModel>();
        }
    }
}