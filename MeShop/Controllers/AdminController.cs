﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeShop.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Welcome()
        {
            return View();
        }
    }
}