using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using System.Text;

namespace quaneu.datalayer.Models.Contact
{
    public class Email : MailMessage
    {
        [Required(ErrorMessage = "Vul een voornaam in aub")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Vul een achternaam in aub")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Vul een geldig email adres in aub")]
        public string From { get; set; }
        public string LocalCommunity { get; set; }
        public string ZipCode { get; set; }
        [Required(ErrorMessage = "Vul een subject in aub")]
        public string Subject { get; set; }
        [Required(ErrorMessage = "Vul een bericht in aub")]
        public string Body { get; set; }



    }
}
