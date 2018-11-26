using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace quaneu.webapi.ViewModels
{
    public class MailViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string From { get; set; }
        public string LocalCommunity { get; set; }
        public string ZipCode { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

    }
}
