using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Leilao.Models
{
    [Dapper.Contrib.Extensions.Table("Product")]
    public class Product
    {
        public int Id { get; set; }
        [Display(Name = "Nome da casa")]
        public string Name { get; set; }
        [Display(Name = "Valor mínimo")]
        public decimal Value { get; set; }
    }
}