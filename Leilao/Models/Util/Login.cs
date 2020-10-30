using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Leilao.Models.Util
{
    public class Login
    {
        public string Email { get; set; }
        [Display(Name = "Senha")]
        public string Password { get; set; }
    }
}