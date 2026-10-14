using AutoMapper;
using Uper.DTOs;
using Uper.Model;

namespace Uper.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<User, RgisterDTO>().ReverseMap();
        }
    }
}
