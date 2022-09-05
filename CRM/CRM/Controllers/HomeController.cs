
using CRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRM.Controllers
{
    public class HomeController : Controller
    {


       public ActionResult CreateTagret()
        {
            return View();  

        }
        public ActionResult EditProduct(int? id)
        {
            if (!id.HasValue)
            {
                return HttpNotFound();
            }

            Target target = null;

            using (var dataContext = new DataContext())
            {
                target = dataContext.Targets.FirstOrDefault(d => d.Id == id);
            }

            if (target != null)
            {
                return View(target);
            }

            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult EditProduct(Target target)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Entry(target).State = System.Data.Entity.EntityState.Modified;
                dataContext.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult CreateTagret(Target target)
        {
            var targetList = new List<Target>();
            using (var dataContext = new DataContext())
            {
                
                dataContext.Targets.Add(target);
                dataContext.SaveChanges();
            }
            return RedirectToAction("Index");

        }

        public ActionResult DeleleTarget(int? id)
        {
            using (var dataContext = new DataContext())
            {
                var target = dataContext.Targets.FirstOrDefault(d => d.Id == id);
                if (target != null)
                {
                    dataContext.Entry(target).State = System.Data.Entity.EntityState.Deleted;
                    dataContext.SaveChanges();
                }
            }

            return RedirectToAction("Index");
        }
        public ActionResult Index()
        {


            var targetlist = new List<Target>();

            using (var datacontext = new DataContext())
            {
                targetlist = datacontext.Targets.ToList();
            }
            return View(targetlist); 
        }

         

        public ActionResult About() 
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}