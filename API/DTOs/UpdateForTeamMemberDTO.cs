using API.Enums;

namespace API.DTOs
{
    public class UpdateForTeamMemberDTO
    {
        public string id { get; set; }
        public string Name { get; set; }
        public int SummonerLevel { get; set; }
        public Roles Role { get; set; }
    }
}