using System.Collections.Generic;
using API.Entities;

namespace API.DTOs
{
    public class TeamDTO
    {
        public int Id { get; set; }
        public string TeamName { get; set; }
        public ICollection<TeamMember> Members { get; set; }   
    }
}