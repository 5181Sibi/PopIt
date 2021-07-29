using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PopIt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace PopIt.Controllers
{
    public class ManageTeacherController : Controller
    {
        // GET: Director
        public ActionResult Index()
        {
            using (PopItContext Db = new PopItContext())
            {
                return View(Db.TeacherDetails.ToList());
            }

        }

        // GET: Director/Details/5
        public ActionResult Details(int id)
        {
            using (PopItContext Db = new PopItContext())
            {
                return View(Db.TeacherDetails.Where(x => x.TeacherId == id).FirstOrDefault());
            }
        }

        private ActionResult View(Func<TeacherAccount> firstOrDefault)
        {
            throw new NotImplementedException();
        }

        // GET: Director/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Director/Create
        [HttpPost]
        public ActionResult Create(TeacherDetail TeacherAccount)
        {
            try
            {
                // TODO: Add insert logic here
                using (PopItContext Db = new PopItContext())
                {
                    Db.TeacherDetails.Add(TeacherAccount);
                    Db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Director/Edit/5
        public ActionResult Edit(int id)
        {
            using (PopItContext Db = new PopItContext())
            {
                return View(Db.TeacherDetails.Where(x => x.TeacherId == id).FirstOrDefault());
            }
        }

        // POST: Director/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, TeacherDetail TeacherAccount)
        {
            try
            {
                // TODO: Add update logic here
                using (PopItContext Db = new PopItContext())
                {
                    Db.Entry(TeacherAccount).State = EntityState.Modified;
                    Db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Director/Delete/5
        public ActionResult Delete(int id)
        {
            using (PopItContext Db = new PopItContext())
            {
                return View(Db.TeacherDetails.Where(x => x.TeacherId == id).FirstOrDefault());
            }
        }

        // POST: Director/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, TeacherDetail TeacherAccount)
        {
            try
            {
                // TODO: Add delete logic here
                using (PopItContext Db = new PopItContext())
                {
                    TeacherAccount = Db.TeacherDetails.Where(x => x.TeacherId == id).FirstOrDefault();
                    Db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}

namespace PopIt
{
    class TeacherAccount
    {
    }
}