using FilmsC.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace FilmsC.Controllers
{
    public class FilmController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private List<Film> Films;
        private Film mModel;

        // GET: Films
        public async Task<ActionResult> Index(int? page)
        {
            int pageSize = 7;
            int pageNumber = (page ?? 1);
            Films = await db.Films.ToListAsync();
            return View(Films.ToPagedList(pageNumber, pageSize));
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
            return View(film);
        }

        // GET: Films/Create
        public ActionResult Create()
        {
            return View();
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
            Session["FilmId"] = id;
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
            Session["FilmModel"] = film;
            return View(film);
        }

        [HttpPost]
        public async Task<ActionResult> AddPoster(HttpPostedFileBase uploadImage)
        {
            int fid = (int)Session["FilmId"];
            if (uploadImage == null)
            {
                return View("Edit", fid);
            }
            mModel = (Film)Session["FilmModel"];
            if (mModel == null)
            {
                return View("Edit", fid);
            }
            //Заполним информацию о картинке
            mModel.PosterName = uploadImage.FileName;
            mModel.ContentType = uploadImage.ContentType;
            BinaryReader b = new BinaryReader(uploadImage.InputStream);
            mModel.Poster = b.ReadBytes((int)uploadImage.InputStream.Length);
            mModel.ContentType = uploadImage.ContentType;
            mModel.PosterName = uploadImage.FileName;
            //Сохранить картинку в бд
            db.Entry(mModel).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return View("Edit", mModel);
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

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        [HttpGet]
        public async Task<ActionResult> GetPoster(byte[] byteData, string tp)
        {
            // Или из базы, но я предпочитаю не грузить в БД картинки
            // Конвертируем 
            string imreBase64Data = Convert.ToBase64String(byteData);
            string imgDataURL = string.Format("data:image/png;base64,{0}", imreBase64Data);
            var image = System.IO.File.OpenRead("C:\\images\\myImage.jpeg"); 
            return File(image, "image/jpeg");
        }
    }
}
