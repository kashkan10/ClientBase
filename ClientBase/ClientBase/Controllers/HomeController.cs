using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClientBase.Models;

namespace ClientBase.Controllers
{
    public class HomeController : Controller
    {
        PersonContext db=new PersonContext();
        int sum = 0;

        [HttpGet]
        public ActionResult Index()
        {
            var persons = db.Persons;
            if (persons.Count() != 0)
                ViewBag.Persons = persons;
            else ViewBag.Persons = null;

            ViewBag.Sum = GetSum();
            return View();
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Person person)
        {
            db.Persons.Add(person);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Person b = db.Persons.Find(id);
            if (b == null)
                return HttpNotFound();

            return View(b);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            if (id == -1)
            {
                return RedirectToAction("Index");
            }
            else
            {
                Person b = db.Persons.Find(id);
                if (b == null)
                {
                    return HttpNotFound();
                }

                db.Persons.Remove(b);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult Change(int? id)
        {
            return View(db.Persons.Find(id));
        }

        [HttpPost]
        public ActionResult Change(Person person)
        {
            db.Entry(person).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Clear()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ClearConf()
        {
            db.Database.Delete();

            return RedirectToAction("Index");
        }

        private int GetSum()
        {
            foreach(Person person in db.Persons)
            {
                sum += person.Profit;
            }

            return sum;
        }
    }
}