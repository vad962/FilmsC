using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FilmsC.Models;
using PagedList;

namespace FilmsC.Controllers
{
    public class FilmController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private Film FilmModel;

        // GET: Films
        public async Task<ActionResult> Index(int? page)
        {
            int pageSize = 4;
            int pageNumber = (page ?? 1);
            List<Film> films = await db.Films.ToListAsync();  
            return View(films.ToPagedList(pageNumber, pageSize));
        }

        // GET: Films/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Film film = await db.Films.FindAsync(id);
            if (film == null)
            {
                return HttpNotFound();
            }
            Session["FilmModel"] = film;
            return View(film);
        }

        // GET: Films/Create
        public ActionResult Create()
        {
            var film = new Film { Owner = User.Identity.Name };
            Session["FilmModel"] = film;
            return View(film);
        }

        // POST: Films/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Name,Description,Year,Producer,Genre,Owner,Poster,PosterName,ContentType")] Film film)
        {
            if (ModelState.IsValid)
            {
                db.Films.Add(film);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(film);
        }

        // GET: Films/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Film film = await db.Films.FindAsync(id);
            if (film == null)
            {
                return HttpNotFound();
            }
            //Сохранить модель
            Session["FilmModel"] = film;
            return View(film);
        }

        // POST: Films/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Name,Description,Year,Producer,Genre,Owner,Poster,PosterName,ContentType")] Film film)
        {
            if (ModelState.IsValid)
            {
                db.Entry(film).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(film);
        }

        // GET: Films/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Film film = await db.Films.FindAsync(id);
            if (film == null)
            {
                return HttpNotFound();
            }
            return View(film);
        }

        // POST: Films/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Film film = await db.Films.FindAsync(id);
            db.Films.Remove(film);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult AddPoster(HttpPostedFileBase upload)
        {
            //Получить модель
            Film film = (Film)Session["FilmModel"];
            if(film == null)
            {
                return View("Index");  
            }
            if (upload != null)
            {
                // получаем имя файла
                film.PosterName = upload.FileName;
                film.ContentType = upload.ContentType;
                //считаем загруженный файл в массив
                film.Poster = new byte[upload.ContentLength];
                upload.InputStream.Read(film.Poster, 0, upload.ContentLength);
                // сохраняем файл в БД
                db.Entry(film).State = EntityState.Modified;
                db.SaveChanges();
            }
            Session["FilmModel"] = film;
            return View("Edit", film);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
