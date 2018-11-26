using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace quaneu.webapi.ViewModels
{
    public class GoogleAuthViewModel
    {
        public string Code { get; set; }
        public string AccessToken { get; set; }
    }
}