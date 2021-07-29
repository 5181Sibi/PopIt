using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult AdminHomePage()
        {
            return View();
        }
        public ActionResult Profile()
        {
            return View();
        }
        public ActionResult ManageStudent()
        {


            return View();
        }
        public ActionResult ManageTeacher()
        {
            return View();
        }
        public ActionResult MappingStudentTeacher()
        {
            return View();
        }
        public ActionResult Logout()
        {
            return View();
        }


    }
}
