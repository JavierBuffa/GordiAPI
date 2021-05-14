using API.Enums;

namespace API.DTOs
{
    public class TeamMemberDTO
    {
        public string Name { get; set; }
        public int SummonerLevel { get; set; }
        public string Role { get; set; }
        public string IdSummoner { get; set; }
    }
}