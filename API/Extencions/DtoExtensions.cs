using API.DTOs;
using API.Entities;
using AutoMapper;

namespace API.Extencions
{
    public static class DtoExtensions
    {
        public static TeamDTO ToDto(this UserTeam entity, IMapper mapper)
        {
            return mapper.Map<TeamDTO>(entity);
        }

        // public static TeamDTO ToDto(this TeamMembers entity, IMapper mapper)
        // {
        //     return mapper.Map<TeamDTO>(entity);
        // }
    }
}