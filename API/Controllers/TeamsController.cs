using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Extencions;
using API.Intefaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    // [Authorize]
    public class TeamsController : BaseApiController
    {
        private readonly ITeamRepository _teamRepository;
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        
        public TeamsController(ITeamRepository teamRepository, DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
            _teamRepository = teamRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeamDTO>>> GetTeams()
        {
            var teams = await _teamRepository.GetTeamsAsync();

            return Ok(teams);
        }

        [HttpGet("name/{teamname}")]
        public async Task<ActionResult<TeamDTO>> GetTeam(string teamname)
        {
            return await _teamRepository.GetTeamByTeamNameDtoAsync(teamname.ToUpper());
        }

        [HttpGet("id/{id}")]
        public async Task<ActionResult<TeamDTO>> GetTeamById(int id)
        {
            return (await _teamRepository.GetTeamByIdAsync(id)).ToDto(_mapper);
        }

        [HttpGet("id/{id}/members")]
        public async Task<ActionResult<ICollection<TeamMemberDTO>>> GetTeamMembers(int id)
        {
            var members = await _teamRepository.GetTeamMembersAsync(id);
            if (members.Count == 0) 
            {
                return NoContent();
            }
            return Ok(members);
        }

        [HttpPost("id/{id}/members/new")]
        public async Task<ActionResult<TeamMemberDTO>> NewTeamMember(int id, TeamMemberDTO teamMemberDTO)
        {
            if(await _teamRepository.TeamMemberExists(id, teamMemberDTO.Name))
            {
                return BadRequest($"Summoner {teamMemberDTO.Name} already exist in team {id}");
            }

            TeamMember newTeamMember = _mapper.Map<TeamMember>(teamMemberDTO);
            
            var member = await _teamRepository.NewTeamMember(id, newTeamMember);

            return teamMemberDTO;
        } 

        [HttpPost("createteam")]
        public async Task<ActionResult<TeamDTO>> CreateTeam(CreateTeamDTO createTeamDto)
        {
            if (await TeamExists(createTeamDto.TeamName)) return BadRequest("That team already exist");

            var team = new UserTeam();
            team.TeamName = createTeamDto.TeamName.ToUpper();
            _teamRepository.add(team);

            return new TeamDTO
            {
                TeamName = createTeamDto.TeamName
            };
        }

        [HttpPut("edit/{id}")]
        public async Task<ActionResult<TeamDTO>> teamUpdate(int id, UpdateForTeamDTO updateTeam)
        {
            var teamFromRepo = await _teamRepository.GetTeamByIdAsync(id);
            teamFromRepo.TeamName = updateTeam.TeamName;

            if (await _teamRepository.SaveAllAsync())
                return NoContent();

            throw new Exception($"Unable to update team {id}");

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> deleteTeam(int id)
        {
            try
            {
                var teamFromRepo = await _teamRepository.GetTeamByIdAsync(id);
                _teamRepository.delete(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        private async Task<bool> TeamExists(string teamname)
        {
            return await _teamRepository.TeamExists(teamname);
        }
    }
}