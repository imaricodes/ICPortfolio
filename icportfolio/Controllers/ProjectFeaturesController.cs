using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using icportfolio;

namespace icportfolio.Controllers
{
    public class ProjectFeaturesController : Controller
    {
        private ICPORTFOLIOEntities2 db = new ICPORTFOLIOEntities2();

        // GET: ProjectFeatures
        public ActionResult Index()
        {
            var projectFeatures = db.ProjectFeatures.Include(p => p.Project).Include(p => p.Property);
            return View(projectFeatures.ToList());
        }

        // GET: ProjectFeatures/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectFeature projectFeature = db.ProjectFeatures.Find(id);
            if (projectFeature == null)
            {
                return HttpNotFound();
            }
            return View(projectFeature);
        }

        // GET: ProjectFeatures/Create
        public ActionResult Create()
        {
            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "name");
            ViewBag.PropertyID = new SelectList(db.Properties, "PropertyID", "Property1");
            return View();
        }

        // POST: ProjectFeatures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProjectFeatureID,ProjectID,PropertyID")] ProjectFeature projectFeature)
        {
            if (ModelState.IsValid)
            {
                db.ProjectFeatures.Add(projectFeature);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "name", projectFeature.ProjectID);
            ViewBag.PropertyID = new SelectList(db.Properties, "PropertyID", "Property1", projectFeature.PropertyID);
            return View(projectFeature);
        }

        // GET: ProjectFeatures/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectFeature projectFeature = db.ProjectFeatures.Find(id);
            if (projectFeature == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "name", projectFeature.ProjectID);
            ViewBag.PropertyID = new SelectList(db.Properties, "PropertyID", "Property1", projectFeature.PropertyID);
            return View(projectFeature);
        }

        // POST: ProjectFeatures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProjectFeatureID,ProjectID,PropertyID")] ProjectFeature projectFeature)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projectFeature).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "name", projectFeature.ProjectID);
            ViewBag.PropertyID = new SelectList(db.Properties, "PropertyID", "Property1", projectFeature.PropertyID);
            return View(projectFeature);
        }

        // GET: ProjectFeatures/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectFeature projectFeature = db.ProjectFeatures.Find(id);
            if (projectFeature == null)
            {
                return HttpNotFound();
            }
            return View(projectFeature);
        }

        // POST: ProjectFeatures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProjectFeature projectFeature = db.ProjectFeatures.Find(id);
            db.ProjectFeatures.Remove(projectFeature);
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
    }
}
