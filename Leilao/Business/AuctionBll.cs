using Dapper;
using Dapper.Contrib.Extensions;
using Leilao.Models;
using Leilao.Models.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Leilao.Business
{
    public class AuctionBll : BaseBll
    {
        public List<ProductBid> GetAll(int userId = 0)
        {
            var products = new ProductBll().GetAll();
            var auction = new List<ProductBid>();
            var filter = "";
            if (userId != 0)
            {
                filter = $" and a.userId = {userId} ";
            }
            foreach (var item in products)
            {
                var bid = new ProductBid();
                bid.Product = item.Name;
                bid.Value = item.Value;
                bid.Id = item.Id;
                bid.lstBid = db.Query<Bid>($@"select a.Id, a.Value, a.Date, u.Name UserName 
                                                from AuctionBid a
                                                join UserSistem u on u.id = a.UserId
                                                where a.productId= {item.Id} {filter}
                                                order by value desc").ToList();
                auction.Add(bid);
            }
            return auction;
        }

        public AuctionBid GetLastBid(int productId)
        {
            return db.Query<AuctionBid>($"SELECT TOP 1 * FROM AuctionBid where ProductId = {productId} Order BY Value DESC").FirstOrDefault();
        }


        public void Create(AuctionBid data, out string error)
        {
            error = "";

            var lastBid = GetLastBid(data.ProductId);

            if (lastBid == null)
            {
                var prod = db.Get<Product>(data.ProductId);
                lastBid = new AuctionBid();
                lastBid.Value = prod.Value;

                if (lastBid.Value > data.Value)
                {
                    error = "Não foi possível realizar o lance, valor menor o lance minimo de " + lastBid.Value;
                    return;
                }
            }

            if (lastBid.Value >= data.Value)
            {
                error = "Não foi possível realizar o lance, valor menor que ultimo lance de " + lastBid.Value;
                return;
            }

            try
            {
                data.Date = DateTime.Now;
                db.Insert<AuctionBid>(data);
                return;
            }
            catch (Exception ex)
            {
                error = "Ocorreu um erro ao fazer o lance";
                return;
            }


        }
    }
}