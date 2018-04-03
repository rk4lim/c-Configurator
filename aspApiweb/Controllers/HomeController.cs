using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace aspApiweb.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public Models.DataOfEmployeesEntities db_empl = new Models.DataOfEmployeesEntities();
        public ActionResult Index()
        {
            var list = db_empl.TEmployees;
            return View(list);
        }
        [HttpPost]
        public ActionResult Index(Models.TEmployee empl)
        {
            db_empl.TEmployees.Add(empl);
            db_empl.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var item = db_empl.TEmployees.Find(id);
            if (item != null)
            {
                db_empl.TEmployees.Remove(item);
                db_empl.SaveChanges();
            }
            else HttpNotFound();
            return RedirectToAction("Index");
        }
    }
}