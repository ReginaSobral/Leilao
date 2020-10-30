using Leilao.Business;
using Leilao.Models;
using Leilao.Models.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Leilao.Controllers
{
    public class UserSistemController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }



        public ActionResult Login()
        {

            return View();
        }



        [HttpPost]
        public ActionResult Create(UserSistem data)
        {
            try
            {
                var error = "";
                var id = new UserBll().Create(data, out error);
                TempData["Error"] = error;
                if (error == "")
                {
                    Session["Id"] = id.ToString();
                    Session["Name"] = data.Name.ToString();
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
