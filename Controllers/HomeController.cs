using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public object FormsAuthentication { get; private set; }

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpGet]
        public ActionResult Login()
        {
            ViewBag.message = " ";
            return View();
        }
        [HttpPost]
        
        public ActionResult Login(LoginViewModel model)
        {
            using (PopItContext Login = new PopItContext())
            {
                if (ModelState.IsValid)
                {
                    var validuser = isvaliduser(model);
                    var validuser2 = isvaliduser2(model);
                    var validuser3 = isvaliduser3(model);

                    if (validuser != null || validuser2 !=null || validuser3 != null )
                    {


                        //Session["userid"] = validuser.userid;
                        //return RedirectToAction("StudentInformation", "Home");
                        //FormsAuthentication.SetAuthCookie(model.username, model.RememberMe);
                        if (validuser !=null)
                        {
                            return RedirectToAction("Privacy");

                        }
                        if(validuser2 != null)
                        {
                            return RedirectToAction("Index");
                        }
                        if (validuser3 != null)
                        {
                            return RedirectToAction("Privacy");
                        }
                    }
                    else
                    {
                        ViewBag.message = "Incorrect username or password";
                    }
                }
                else
                {
                    return View(model);

                }
            }
            return View();
        }
        public AdminLogin isvaliduser(LoginViewModel model)
        {
            using (PopItContext db = new PopItContext())
            {
                AdminLogin uSer = db.AdminLogins.Where(query => query.AdminNo.Equals(model.username) && query.Password.Equals(model.password)).SingleOrDefault();

                if (uSer == null)
                {
                    return null;
                }
                else
                {
                    return uSer;
                }
            }
        }
        public StudentDetail isvaliduser2(LoginViewModel model)
        {
            using (PopItContext db = new PopItContext())
            {
                StudentDetail uSer = db.StudentDetails.Where(query => query.RollNo.Equals(model.username) && query.Password.Equals(model.password)).SingleOrDefault();

                if (uSer == null)
                {
                    return null;
                }
                else
                {
                    return uSer;
                }
            }
        }
        public TeacherDetail isvaliduser3(LoginViewModel model)
        {
            using (PopItContext db = new PopItContext())
            {
                TeacherDetail uSer = db.TeacherDetails.Where(query => query.StaffNo.Equals(model.username) && query.Password.Equals(model.password)).SingleOrDefault();

                if (uSer == null)
                {
                    return null;
                }
                else
                {
                    return uSer;
                }
            }
        }


    }
 }