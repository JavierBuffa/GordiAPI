using System;
using System.Collections.Generic;

namespace API.Entities
{
    public class AppUser
    {
        public int Id { get; set; }
        public string UserName { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        public RegionList Region { get; set; }

        public DateTime LastActive { get; set; } = DateTime.Now;

        public ICollection<Photo> ProfilePhoto { get; set; }
    }
}