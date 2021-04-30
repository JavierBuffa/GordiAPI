using System;
using System.Collections.Generic;
using API.Entities;

namespace API.DTOs
{
    public class MemberDTO
    {
        public int Id { get; set; }
        
        public string Username { get; set; }

        public string PhotoUrl { get; set; }

        public RegionList Region { get; set; }
        
        public DateTime LastActive { get; set; }

        public ICollection<PhotoDTO> ProfilePhoto { get; set; }
    }
}