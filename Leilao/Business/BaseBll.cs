using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Data.SqlClient;

namespace Leilao.Business
{
    public class BaseBll
    {
        public SqlConnection db = new SqlConnection(WebConfigurationManager.ConnectionStrings["bdLeilao"].ConnectionString);
    }
}