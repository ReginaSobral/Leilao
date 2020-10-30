using Dapper;
using Dapper.Contrib.Extensions;
using Leilao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Leilao.Business
{
    public class UserBll : BaseBll
    {

        public List<UserSistem> GetAll()
        {
        
            return db.GetAll<UserSistem>().ToList();
        }

        public int Create(UserSistem data, out string error)
        {
            error = "";
            try
            {
                var user = db.Insert<UserSistem>(data);
                return Convert.ToInt32(user);
            }
            catch (Exception ex)
            {
                error = "Ocorreu um erro ao cadastrar o Usuario";
                return 0;
            }


        }
    }
}