using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Leilao.Models
{
    [Dapper.Contrib.Extensions.Table("UserSistem")]
    public class UserSistem
    {
        public int Id { get; set; }
        [Display(Name = "Nome")]
        public string Name { get; set; }
        public int Age{ get; set; }
    }
}