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
        MeshopEntities4 entities = new MeshopEntities4();
        public ActionResult Welcome()
        {
            return View();
        }
        public ActionResult Products()
        {
            var data = entities.Products.ToList();
            return View(data);
        }
        public JsonResult InsertData(Product newone)
        {
            decimal result = 1;
            try
            {
                var list = entities.Products.Where(l => l.ProductName == newone.ProductName).SingleOrDefault();
                if (list == null)
                {
                    entities.Products.Add(newone);
                    entities.SaveChanges();
                    result = 0;
                }
                else
                {
                    result = 1;
                }
            }
            catch (Exception ex)
            {

            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}