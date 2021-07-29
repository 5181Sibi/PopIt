﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    public class TeacherController : Controller
    {

        public ActionResult TeacherDashboard()
        {
            return View();
        }
        public ActionResult Profile()
        {
            return View();
        }
        public ActionResult UploadMaterials()
        {
            return View();
        }
        public ActionResult CreateAssessment()
        {
            return View();
        }
        public ActionResult StudentResult()
        {
            return View();
        }
        public ActionResult Logout()
        {
            return RedirectToAction("Login", "Home");
        }

    }
}
