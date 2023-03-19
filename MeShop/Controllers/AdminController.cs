using MeShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeShop.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        MeShopEntities entities = new MeShopEntities();

        public ActionResult Welcome()
        {
          //var list1=  entities.Products.Where(l => l.Image == "Image").ToList();
            return View();
        }
        public ActionResult Products()
        {
            var list2 = entities.Products.ToList();
            return View(list2);
        }
        [HttpPost]
        public JsonResult InsertData(Product data)
        {
            decimal result = 0;
            try
            {
                var list2 = entities.Products.Where(l => l.Name == data.Name).SingleOrDefault();
                if (list2 == null)
                {
                    entities.Products.Add(data);
                    entities.SaveChanges();
                    result = 1;
                }
                else
                {
                    result = 0;
                }
            }
            catch (Exception ex)
            {

            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }


    }
}