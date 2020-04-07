using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EGL_V1.Models;

namespace EGL_V1.Controllers
{
    public class DehumidifiersController : Controller
    {
        private AppliancesEntities db = new AppliancesEntities();

        // GET: Dehumidifiers
        public ActionResult Index()
        {
            var dehumidifiers = db.Dehumidifiers.Include(d => d.AppliancesType);
            return View(dehumidifiers.ToList());
        }

        // GET: Dehumidifiers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dehumidifier dehumidifier = db.Dehumidifiers.Find(id);
            if (dehumidifier == null)
            {
                return HttpNotFound();
            }
            return View(dehumidifier);
        }

        // GET: Dehumidifiers/Create
        public ActionResult Create()
        {
            ViewBag.TypeId = new SelectList(db.AppliancesTypes, "TypeId", "TypeName");
            return View();
        }

        // POST: Dehumidifiers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DehumidifiersId,Partner,BrandName,ModelName,ModelNumber,AdditionalModelInfo,DehumidifierType,AlternateConfigurationType,IntegratedEnergyFactor,WaterRemovalCapcity,DateAvailable,Market,ModelIdentifier,Criteria,TypeId")] Dehumidifier dehumidifier)
        {
            if (ModelState.IsValid)
            {
                db.Dehumidifiers.Add(dehumidifier);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TypeId = new SelectList(db.AppliancesTypes, "TypeId", "TypeName", dehumidifier.TypeId);
            return View(dehumidifier);
        }

        // GET: Dehumidifiers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dehumidifier dehumidifier = db.Dehumidifiers.Find(id);
            if (dehumidifier == null)
            {
                return HttpNotFound();
            }
            ViewBag.TypeId = new SelectList(db.AppliancesTypes, "TypeId", "TypeName", dehumidifier.TypeId);
            return View(dehumidifier);
        }

        // POST: Dehumidifiers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DehumidifiersId,Partner,BrandName,ModelName,ModelNumber,AdditionalModelInfo,DehumidifierType,AlternateConfigurationType,IntegratedEnergyFactor,WaterRemovalCapcity,DateAvailable,Market,ModelIdentifier,Criteria,TypeId")] Dehumidifier dehumidifier)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dehumidifier).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TypeId = new SelectList(db.AppliancesTypes, "TypeId", "TypeName", dehumidifier.TypeId);
            return View(dehumidifier);
        }

        // GET: Dehumidifiers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dehumidifier dehumidifier = db.Dehumidifiers.Find(id);
            if (dehumidifier == null)
            {
                return HttpNotFound();
            }
            return View(dehumidifier);
        }

        // POST: Dehumidifiers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dehumidifier dehumidifier = db.Dehumidifiers.Find(id);
            db.Dehumidifiers.Remove(dehumidifier);
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
