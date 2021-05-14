using System.Linq;
using API.DTOs;
using API.Entities;
using API.Extencions;
using AutoMapper;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AppUser, MemberDTO>()
            .ForMember(dest => dest.PhotoUrl, opt => opt.MapFrom(src 
            => src.ProfilePhotos.FirstOrDefault(x => x.IsMain).Url));
            CreateMap<Photo, PhotoDTO>();
            CreateMap<TeamMember, TeamMemberDTO>().ForMember(dest => dest.Role, opt 
            => opt.MapFrom(src => src.Role.GetDescription()));
            CreateMap<TeamMemberDTO, TeamMember>().ForMember(dest => dest.Role, opt 
            => opt.MapFrom(src => src.Role.GetEnum()));
            CreateMap<UserTeam, TeamDTO>();
            
        }
    }
}