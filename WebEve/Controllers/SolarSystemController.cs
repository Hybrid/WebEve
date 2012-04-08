using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebEve.Models;

namespace WebEve.Controllers
{ 
    public class SolarSystemController : Controller
    {
        private WebEveEntities db = new WebEveEntities();
        private EveOnlineDBEntities EveContext = new EveOnlineDBEntities();
        //
        // GET: /SolarSystem/

        public ViewResult Index()
        {
            return View(db.SolarSystems.ToList());
        }

        //
        // GET: /SolarSystem/Details/5

        public ViewResult Details(int id)
        {
            SolarSystem solarsystem = db.SolarSystems.Find(id);
            return View(solarsystem);
        }

        //
        // GET: /SolarSystem/Create

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AjaxCreate(int ApiId)
        {
            mapSolarSystem eveSolar = EveContext.mapSolarSystems.SingleOrDefault(x => x.solarSystemID == ApiId);
            SolarSystem solarSystem = new SolarSystem();
            solarSystem.Name = eveSolar.solarSystemName;
            solarSystem.ApiId = eveSolar.solarSystemID.ToString();
            db.SolarSystems.Add(solarSystem);
            db.SaveChanges();
            return Json(solarSystem, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Search(string startswith)
        {
            IQueryable systems = EveContext.mapSolarSystems.Where(t => t.solarSystemName.StartsWith(startswith)).Select(x => new { x.solarSystemID, x.solarSystemName });
            return Json(systems, JsonRequestBehavior.AllowGet);
        }

        //
        // POST: /SolarSystem/Create

        [HttpPost]
        public ActionResult Create(SolarSystem solarsystem)
        {
            if (ModelState.IsValid)
            {
                db.SolarSystems.Add(solarsystem);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(solarsystem);
        }
        
        //
        // GET: /SolarSystem/Edit/5
 
        public ActionResult Edit(int id)
        {
            SolarSystem solarsystem = db.SolarSystems.Find(id);
            return View(solarsystem);
        }

        //
        // POST: /SolarSystem/Edit/5

        [HttpPost]
        public ActionResult Edit(SolarSystem solarsystem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(solarsystem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(solarsystem);
        }

        //
        // GET: /SolarSystem/Delete/5
 
        public ActionResult Delete(int id)
        {
            SolarSystem solarsystem = db.SolarSystems.Find(id);
            return View(solarsystem);
        }

        //
        // POST: /SolarSystem/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            SolarSystem solarsystem = db.SolarSystems.Find(id);
            db.SolarSystems.Remove(solarsystem);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}