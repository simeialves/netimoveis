﻿using netimoveis.Net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace netimoveis.Net.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }
    }
}