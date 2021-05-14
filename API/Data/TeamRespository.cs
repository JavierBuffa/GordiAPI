using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Intefaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class TeamRespository : ITeamRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public TeamRespository(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<IEnumerable<UserTeam>> GetTeamsAsync()
        {
            return await _context.Teams
            .Include(t => t.Members)
            .ToListAsync();
        }
        public async Task<UserTeam> GetTeamByIdAsync(int id)
        {
            return await _context.Teams.FindAsync(id);
        }

        public IQueryable<UserTeam> GetTeamByTeamName(string teamname)
        {
            return _context.Teams.Where(n => n.TeamName == teamname);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void update(UserTeam team)
        {
            _context.Entry(team).State = EntityState.Modified;
        }

        public async Task<TeamDTO> GetTeamByTeamNameDtoAsync(string teamName)
        {
            return await this.GetTeamByTeamName(teamName).ProjectTo<TeamDTO>(_mapper.ConfigurationProvider).SingleOrDefaultAsync();
        }

        public void add(UserTeam team)
        {
            _context.Teams.Add(team);
            _context.SaveChangesAsync();
        }

        public Task<bool> TeamExists(string teamName)
        {
            return _context.Teams.AnyAsync(n => n.TeamName == teamName);
        }

        public async void delete(int id)
        {
            var team = await _context.Teams.FindAsync(id);
            if (team == null)
            {
                throw new Exception($"Cannot find this team id {id}");
            }
            _context.Teams.Remove(team);
            await _context.SaveChangesAsync(); 
            
        }

        public async Task<TeamMember> NewTeamMember(int idTeam, TeamMember teamMember)
        {
            var team = await _context.Teams.FindAsync(idTeam);
            
            if(team.Members == null)
                team.Members = new List<TeamMember>();

            team.Members.Add(teamMember);
            await _context.SaveChangesAsync();

            return teamMember;
        }

        public async Task<ICollection<TeamMember>> GetTeamMembersAsync(int idTeam)
        {
            var team = await _context.Teams.Where(t => t.Id == idTeam).Include(m => m.Members).SingleOrDefaultAsync();
            
            return team.Members;
        }

        public Task<bool> TeamMemberExists(int idTeam, string name)
        {
            return _context.Members.AnyAsync(m => m.Name == name);
        }
    }
}