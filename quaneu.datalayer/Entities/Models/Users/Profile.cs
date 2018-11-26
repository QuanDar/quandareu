using System;
using System.Collections.Generic;
using System.Text;

namespace quaneu.datalayer.Entities.Models.Users
{
    public class Profile
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PictureUrl { get; set; }
        public string FacebookId { get; set; }
    }
}
