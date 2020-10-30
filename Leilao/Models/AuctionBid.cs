using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Leilao.Models
{
    [Dapper.Contrib.Extensions.Table("AuctionBid")]
    public class AuctionBid
    {
        public int Id { get; set; }
        [Display(Name = "Valor")]
        public decimal Value { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public DateTime Date { get; set; }
        [Write(false)]
        public string Name { get; set; }
    }
}