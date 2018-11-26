using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using quaneu.datalayer.Models.Contact;
using quaneu.webapi.Services;
using quaneu.webapi.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace quaneu.webapi.Controllers
{
    [Route("api/[controller]")]
    public class MailController : Controller
    {
        private readonly IConfiguration _configuration;

        public MailController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // POST api/<mail>
        [HttpPost]
        public async Task<IActionResult> PostEmail([FromBody]MailViewModel mail)
        {
            await MailService.PostEmail(mail, _configuration);

            return Ok("Email is verstuurd");
        }
    }
}
