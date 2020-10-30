using Leilao.Business;
using Leilao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Leilao.Controllers
{
    public class ProductController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product data)
        {
            try
            {
                var error = "";
                new ProductBll().Create(data, out error);
                TempData["Error"] = error;
                if (error == "")
                {
                    return RedirectToAction("Index", "Auction");
                }
                return View();

            }
            catch
            {
                return View();
            }
        }

    }
}
