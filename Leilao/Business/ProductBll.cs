using Dapper;
using Dapper.Contrib.Extensions;
using Leilao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Leilao.Business
{
    public class ProductBll : BaseBll
    {
        public List<Product> GetAll()
        {
            return db.GetAll<Product>().ToList();
        }
        public void Create(Product data, out string error)
        {
            error = "";         
            try
            {
               var user = db.Insert<Product>(data);              
                return;              
            }
            catch (Exception ex)
            {
                error = "Ocorreu um erro ao cadastrar o produto";
                return;
            }

           
        }

        internal Product Get(int productId, out string error)
        {
            error = "";
            try
            {
                return db.Get<Product>(productId);

            }
            catch (Exception ex)
            {
                error = "Erro ao encontrar produto";
                return null;
            }
        }
    }
}