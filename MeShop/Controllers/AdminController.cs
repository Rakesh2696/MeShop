using MeShop.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace MeShop.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        MeShopEntities entities = new MeShopEntities();

        public ActionResult Welcome()
        {
            var list1 = entities.Products.ToList();
            
      
            return View(list1);
        }
        [HttpPost]
        public ActionResult UploadImage()
        {
            try
            {
                HttpFileCollectionBase files = Request.Files;
                for (int i = 0; i < files.Count; i++)
                {
                    HttpPostedFileBase file = files[i];
                    string fname = file.FileName;
                    fname = Path.Combine(Server.MapPath("~/Content/ProductImages/"), fname);
                    file.SaveAs(fname);
                }
                return Json("File Uploaded Successfully!");
            }
            catch (Exception ex)
            {
                return Json("Error occurred. Error details: " + ex.Message);
            }
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
                data.CreatedDate = DateTime.Now;
                data.CreatedBy = "System";
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