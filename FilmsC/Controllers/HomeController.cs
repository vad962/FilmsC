using FilmsC.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FilmsC.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db;
        private Film mModel;
        List<Film> Films;

        public HomeController()
        {
            Films = new List<Film>();
            Films.Add(new Film { Name = "Samsung Galaxi", Description = "Фильм 1 Описание" });
            Films.Add(new Film { Name = "Samsung Galaxi II", Description = "Фильм 2 Описание" });
            Films.Add(new Film { Name = "Samsung Galaxi II", Description = "Фильм 3 Описание" });
            Films.Add(new Film { Name = "Samsung ACE", Description = "Фильм 4 Описание" });
            Films.Add(new Film { Name = "Samsung ACE II", Description = "Фильм 5 Описание" });
            Films.Add(new Film { Name = "HTC One S", Description = "Фильм 6 Описание" });
            Films.Add(new Film { Name = "HTC One X", Description = "Фильм 7 Описание" });
            Films.Add(new Film { Name = "Nokia N9", Description = "Фильм 8 Описание" });
        }

        public ActionResult Index(int? page)
        {
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(Films.ToPagedList(pageNumber, pageSize));
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