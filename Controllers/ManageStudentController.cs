using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PopIt.Controllers
{
    public class ManageStudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
