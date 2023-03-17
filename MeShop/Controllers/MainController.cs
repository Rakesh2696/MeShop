using MeShop.Models;
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
        MeShopEntities meShop=new MeShopEntities();
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
                meShop.SigIns.Add(registerdata);
                meShop.SaveChanges();
                result = true;
            }
            catch(Exception ex) 
            {
            }
            

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult LogIn(SigIn logindata) 
        {
            bool result = false;
            SigIn log = meShop.SigIns.Where(x=> x.UserName==logindata.UserName && x.Password==logindata.Password).FirstOrDefault();
            if (log == null) 
            {
                result= true;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}