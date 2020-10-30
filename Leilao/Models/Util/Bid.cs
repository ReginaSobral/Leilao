using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Leilao.Models.Util
{
    public class Bid
    {
        public decimal Value{ get; set; }
        public DateTime Date { get; set; }
        public string UserName { get; set; }
        public int Id { get; set; }
    }
}