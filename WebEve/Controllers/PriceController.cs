using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebEve.Models;
using System.Xml.Linq;
using WebEve.Repositories;
namespace WebEve.Controllers
{
    public class PriceController : Controller
    {
        private WebEveEntities db = new WebEveEntities();
        private EveOnlineDBEntities EveContext = new EveOnlineDBEntities();
        private EveHQDataEntities eveHQDB = new EveHQDataEntities();
        //
        // GET: /Price/

        public ActionResult Index()
        {
            return View(db.Prices.Where(p => p.Date == DateTime.Today));
        }
        public ActionResult Update() 
        {
            SolarSystem system = db.SolarSystems.Single(s => s.Name.Equals("Jita"));
            IMarketPriceRepository priceRepository = new EveCentralRepository();
            IEnumerable<Price> prices = priceRepository.FetchPrices(db.Items, system);
            foreach (Price p in prices) {
                db.Prices.Add(p);
                eveHQDB.UpdatePrice(p);
            }
            eveHQDB.SaveChanges();
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public void ReprocessProfit() {
            IMarketPriceRepository priceRepository = new EveCentralRepository();
            SolarSystem system = db.SolarSystems.Single(s => s.Name.Equals("Jita"));
            Item item = new Item();
            double buildPrice = 0;
            foreach(invTypeMaterial material in EveContext.invTypeMaterials.Where(m => m.typeID == Int32.Parse(item.ApiId))) 
            {
                Item requiredItem = db.Items.SingleOrDefault(i => i.ApiId == material.materialTypeID.ToString());
                if (material == null)
                {
                    requiredItem = new Item();
                    invType type = EveContext.invTypes.SingleOrDefault(t => t.typeID == material.materialTypeID);
                    requiredItem.ApiId = type.typeID.ToString();
                    requiredItem.Name = type.typeName;
                    db.Items.Add(requiredItem);
                    Price p = priceRepository.FetchPrice(requiredItem, system);
                    db.Prices.Add(p);
                    db.SaveChanges();
                }
                buildPrice += requiredItem.LatestPrice(system).Buy * material.quantity;
            }
            if (buildPrice > item.LatestPrice(system).Sell)
            { 
                // Profit !!!
            }
        }

    }
}
