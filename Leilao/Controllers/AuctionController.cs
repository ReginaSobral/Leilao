using Leilao.Business;
using Leilao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Leilao.Controllers
{
    public class AuctionController : Controller
    {
        public ActionResult Index()
        {
            var users = new UserBll().GetAll();
            var user = new UserSistem();
            user.Id = 0;
            user.Name = "Todos";
            users.Add(user);
            ViewBag.UserId = new SelectList(users.OrderBy(n => n.Id), "Id", "Name");

            var results = new AuctionBll().GetAll();
            return View(results);
        }

        [HttpPost]
        public ActionResult Index(int userId = 0)
        {
            var users = new UserBll().GetAll();
            var user = new UserSistem();
            user.Id = 0;
            user.Name = "Todos";
            users.Add(user);
            ViewBag.UserId = new SelectList(users.OrderBy(n => n.Id), "Id", "Name");

            var results = new AuctionBll().GetAll(userId);
            return View(results);
        }

        
        public ActionResult Create(int productId)
        {
            var auctionBid = new AuctionBid();
            auctionBid.ProductId = productId;
            return View();
        }


        [HttpPost]
        public ActionResult Create(AuctionBid data)
        {
            var error = "";
            data.UserId = Convert.ToInt32(Session["Id"]);
            if (data.UserId == 0)
            {
                return RedirectToAction("Create", "UserSistem");

            }
            new AuctionBll().Create(data, out error);

            TempData["Error"] = error;
            if (error == "")
            {
                return RedirectToAction("Index");
            }
            return View();
        }



    }
}
