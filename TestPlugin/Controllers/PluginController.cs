﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestPlugin.Controllers
{
    public class PluginController : Controller
    {
        // GET: Plugin
        public ActionResult Index()
        {
            return View();
        }
    }
}