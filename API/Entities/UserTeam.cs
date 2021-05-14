using System.Collections.Generic;

namespace API.Entities
{
    public class UserTeam
    {
        public int Id { get; set; }
        public string TeamName { get; set; }
        public ICollection<TeamMember> Members { get; set; }        
    }
}