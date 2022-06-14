using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VuHoangLam.Models;

namespace VuHoangLam.Controllers
{
    public class RubikController : Controller
    {
        // GET: Rubik
        DbRubikStore db = new DbRubikStore();
        public ActionResult Index()
        {
            var all_Rubik = db.Rubiks.ToList();
            return View(all_Rubik);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Rubik rubik = db.Rubiks.Find(id);
            if (rubik == null)
            {
                return HttpNotFound();
            }
            return View(rubik);
        }
    }
}