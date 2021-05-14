using API.Enums;

namespace API.Entities
{
    public class TeamMember
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SummonerLevel { get; set; }
        public Roles Role { get; set; }
        public string IdSummoner { get; set; }
        
    }
}