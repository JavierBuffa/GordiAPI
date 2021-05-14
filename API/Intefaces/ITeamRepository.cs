using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;

namespace API.Intefaces
{
    public interface ITeamRepository
    {
        void update(UserTeam team);
        void add(UserTeam team);
        Task<bool> SaveAllAsync();
        Task<IEnumerable<UserTeam>> GetTeamsAsync();
        Task<UserTeam> GetTeamByIdAsync(int id);
        IQueryable<UserTeam> GetTeamByTeamName(string teamname);
        Task<TeamDTO> GetTeamByTeamNameDtoAsync(string teamName);
        Task<bool> TeamExists(string teamName);
        void delete(int id); 
        Task<TeamMember> NewTeamMember(int idTeam, TeamMember teamMember);
        Task<ICollection<TeamMember>> GetTeamMembersAsync(int idTeam);
        Task<bool> TeamMemberExists(int idTeam, string name);
    }
}