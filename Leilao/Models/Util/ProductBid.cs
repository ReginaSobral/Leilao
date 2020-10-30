using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Leilao.Models.Util
{
    public class ProductBid
    {
        public int Id{ get; set; }
        public string Product { get; set; }
        public decimal Value{ get; set; }
        public int UserId { get; set; }
        public List<Bid> lstBid { get; set; }
    }
}