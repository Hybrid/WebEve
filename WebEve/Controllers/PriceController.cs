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
using WebEve.ViewModels;
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
            PriceViewModel vm = new PriceViewModel
            {
                Items = db.Items.OrderBy(x => x.Name) as IQueryable<Item>,
                Systems = new SelectList(db.SolarSystems.OrderBy(x => x.Name), "Id", "Name", db.SolarSystems.Single(x => x.Name.Equals("Jita")).Id)
            };
            return View(vm);
        }
        public ActionResult Update(int SolarSystemID, string PriceMode) 
        {
            SolarSystem system = db.SolarSystems.Find(SolarSystemID);
            IMarketPriceRepository priceRepository = new EveCentralRepository();
            IEnumerable<Price> prices = priceRepository.FetchPrices(db.Items, system);
            foreach (Price p in prices) {
                db.Prices.Add(p);
                eveHQDB.UpdatePrice(p, PriceMode);
            }
            eveHQDB.SaveChanges();
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public JsonResult ReprocessProfit(int itemId, int refiningLevel, int refineryEfficiencyLevel, int scrapProcessingLevel, double standing, int accountingLevel) {
            IMarketPriceRepository priceRepository = new EveCentralRepository();
            SolarSystem system = db.SolarSystems.Single(s => s.Name.Equals("Jita"));
            Item item = db.Items.Find(itemId);
            double reprocessPrice = 0;
            int eveId = Int32.Parse(item.ApiId);
            foreach(invTypeMaterial material in EveContext.invTypeMaterials.Where(m => m.typeID == eveId)) 
            {
                string materialId = material.materialTypeID.ToString();
                Item requiredItem = db.Items.SingleOrDefault(i => i.ApiId == materialId);
                if (requiredItem == null)
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
                // There's a tax when selling an item but not when buying one (only if not in advanced mode)

                reprocessPrice += double.Parse(String.Format("{0:0.00}", (requiredItem.LatestPrice(system).Buy * Utils.ReprocessTax(material.quantity, refiningLevel, refineryEfficiencyLevel, scrapProcessingLevel, standing)) * (1 - Utils.SaleTax(accountingLevel))));
            }
            double profit = reprocessPrice - item.LatestPrice(system).Buy;
            return Json(profit, JsonRequestBehavior.AllowGet);
        }
    }
}
