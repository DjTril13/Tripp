using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Planner.Models;
using System.Configuration;
using System.IO;

namespace Planner.Controllers
{
    public class MyExperiencesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MyExperiences
        public ActionResult Index()
        {
            return View(db.MyExperiences.ToList());
        }

        // GET: MyExperiences/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyExperiences myExperiences = db.MyExperiences.Find(id);
            if (myExperiences == null)
            {
                return HttpNotFound();
            }
            return View(myExperiences);
        }

        // GET: MyExperiences/Create
        public ActionResult Create()
        {
            MyExperiences NewExperience = new MyExperiences();
            NewExperience.MyImages = new List<Image>();
            Image newImage = new Image();
            NewExperience.MyImages.Add(newImage);
            db.MyExperiences.Add(NewExperience);
            db.SaveChanges();
            return View(NewExperience);
        }

        // POST: MyExperiences/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ActivitiesId,Comments")] MyExperiences myExperiences)
        {
            if (ModelState.IsValid)
            {
                db.MyExperiences.Add(myExperiences);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(myExperiences);
        }

        // GET: MyExperiences/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyExperiences myExperiences = db.MyExperiences.Find(id);
            if (myExperiences == null)
            {
                return HttpNotFound();
            }
            return View(myExperiences);
        }

        // POST: MyExperiences/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ActivitiesId,Comments")] MyExperiences myExperiences)
        {
            if (ModelState.IsValid)
            {
                db.Entry(myExperiences).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(myExperiences);
        }

        // GET: MyExperiences/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyExperiences myExperiences = db.MyExperiences.Find(id);
            if (myExperiences == null)
            {
                return HttpNotFound();
            }
            return View(myExperiences);
        }

        // POST: MyExperiences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MyExperiences myExperiences = db.MyExperiences.Find(id);
            db.MyExperiences.Remove(myExperiences);
            db.SaveChanges();
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
        [HttpPost]
        public ActionResult UploadFiles(List<Image> Images)
        {
            bool isSuccess = false;
            string serverMessage = string.Empty;
            var fileOne = Request.Files[0] as HttpPostedFileBase;
            string uploadPath = ConfigurationManager.AppSettings["UPLOAD_PATH"].ToString();
            string newFileOne = Path.Combine(uploadPath, fileOne.FileName);

            foreach (var i in Images) {
                var Experience = db.MyExperiences.Where(m => m.Id == i.Id).Single();
                var imageFilePath = "~/Image/" + fileOne.FileName;
                Image NewImage = new Image();
                NewImage.ImageFilePath = imageFilePath;
                Experience.MyImages.Add(NewImage);

                db.SaveChanges();

                fileOne.SaveAs(newFileOne);
            }

            if (System.IO.File.Exists(newFileOne))
            {
                isSuccess = true;
                serverMessage = "File has been uploaded successfully";
            }
            else
            {
                isSuccess = false;
                serverMessage = "File upload has failed. Please try again.";
            }
            return Json(new { IsSucccess = isSuccess, ServerMessage = serverMessage, JsonRequestBehavior.AllowGet });
        }
    }
}
