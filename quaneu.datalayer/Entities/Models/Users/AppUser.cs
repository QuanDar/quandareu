using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace quaneu.datalayer.Entities.Models.Users
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public long? FacebookId { get; set; }
        public string GoogleId { get; set; }
        public string PictureUrl { get; set; }
    }
}
