using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebEve.Models;
using WebEve.Repositories;

namespace WebEve.Controllers
{ 
    public class ItemController : Controller
    {
        private WebEveEntities db = new WebEveEntities();
        private EveOnlineDBEntities EveContext = new EveOnlineDBEntities();
        private EveHQDataEntities eveHQDB = new EveHQDataEntities();

        //
        // GET: /Item/

        public ViewResult Index()
        {
            return View(db.Items.ToList());
        }

        [HttpPost]
        public PartialViewResult AjaxCreate(int ApiId) 
        {
            invType eveItem = EveContext.invTypes.SingleOrDefault(x => x.typeID == ApiId);
            Item item = new Item();
            item.Name = eveItem.typeName;
            item.ApiId = eveItem.typeID.ToString();
            db.Items.Add(item);
            IMarketPriceRepository priceRepository = new EveCentralRepository();
            Price p = priceRepository.FetchPrice(item, db.SolarSystems.Single(s => s.Name.Equals("Jita")));
            db.Prices.Add(p);
            db.SaveChanges();
            eveHQDB.UpdatePrice(p);
            eveHQDB.SaveChanges();
            return PartialView("ItemTableTemplate", item);
        }
        public JsonResult Search(string startswith) 
        {
            IQueryable items = EveContext.invTypes.Where(t => t.typeName.StartsWith(startswith)).Select(x => new {x.typeID, x.typeName});
            return Json(items, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Single(string itemName) 
        {
            var item = EveContext.invTypes.SingleOrDefault(x => x.typeName == itemName);
            if(item != null)
            {
                return Json(new { item.typeID, item.typeName }, JsonRequestBehavior.AllowGet);
            }
            return Json("Error", JsonRequestBehavior.AllowGet);
            
        }
        //
        // GET: /Item/Edit/5
 
        public ActionResult Edit(int id)
        {
            Item item = db.Items.Find(id);
            return View(item);
        }

        //
        // POST: /Item/Edit/5

        [HttpPost]
        public ActionResult Edit(Item item)
        {
            if (ModelState.IsValid)
            {
                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(item);
        }

        //
        // GET: /Item/Delete/5
 
        public ActionResult Delete(int id)
        {
            Item item = db.Items.Find(id);
            return View(item);
        }

        //
        // POST: /Item/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Item item = db.Items.Find(id);
            db.Items.Remove(item);
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