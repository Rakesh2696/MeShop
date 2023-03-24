using MeShop.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;



namespace MeShop.Controllers
{

    public class MainController : Controller
    {
        MeShopEntities meShop = new MeShopEntities();
        // GET: Main
        public ActionResult LogIn()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Savedata(SigIn registerdata)
        {
            bool result = false;
            try
            {
                registerdata.CreatedDate = DateTime.Now;
                registerdata.CreatedBy = "SYSTEM";
                meShop.SigIns.Add(registerdata);
                meShop.SaveChanges();
                result = true;
            }
            catch (Exception ex)
            {

            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult LogIn(SigIn logindata)
        {
            string result = string.Empty;
            try
            {
                var list = meShop.SigIns.Where(l => l.UserName == logindata.UserName && l.Password == logindata.Password).FirstOrDefault();
                if (list != null)
                {
                    if (list.IsAdmin == false)
                    {
                        result = "User";
                        //Response.Redirect("../User/Welcome");
                    }
                    else if (list.IsAdmin == true)
                    {
                        result = "Admin";
                        //Response.Redirect("../Admin/Welcome");
                    }
                }
                
            }
            catch (Exception ex)
            {
                result = "Error";
            }
            return Json(result,JsonRequestBehavior.AllowGet);
        }
    }
}