using MeShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace MeShop.Controllers
{
    public class UserController : Controller
    {
        MeShopEntities meShop = new MeShopEntities();
        // GET: User
        public ActionResult Welcome()
        {
           var data = meShop.Products.ToList();
            return View(data);
        }
        public ActionResult Booking()
        {
            //var list = meShop.Products.Where(x => x.Name == name).SingleOrDefault();
            return View();
        }
        [HttpPost]
        public JsonResult Cart(string productid)
        {
            //var list = meShop.Products.Where(x => x.ProductId == productid).SingleOrDefault();
            return Json("");

        }

    }
}