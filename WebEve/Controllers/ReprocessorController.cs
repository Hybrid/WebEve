using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebEve.ViewModels;
using WebEve.Models;
using WebEve.Repositories;
using System.Collections;
namespace WebEve.Controllers
{
    public class ReprocessorController : Controller
    {

        private WebEveEntities db = new WebEveEntities();
        private EveOnlineDBEntities EveContext = new EveOnlineDBEntities();
        public ActionResult Index()
        {
            ReprocessorViewModel vm = new ReprocessorViewModel
            {
                Systems = new SelectList(db.SolarSystems.OrderBy(x => x.Name), "Id", "Name", db.SolarSystems.Single(x => x.Name.Equals("Jita")).Id)
            };
            return View("Index", vm);
        }
        [HttpPost]
        public ActionResult ProfitAnalysis(int solarSystemID, int refiningLevel, int refineryEfficiencyLevel, int scrapProcessingLevel, double standing, int accountingLevel, string buyMode, string sellMode)
        {
            IList<ProfitViewModel> profitableItems = new List<ProfitViewModel>();
            IMarketPriceRepository priceRepository = new EveCentralRepository();
            SolarSystem system = db.SolarSystems.Find(solarSystemID);
            
            foreach (Item item in db.Items.ToList<Item>())
            {
                double reprocessPrice = 0;
                int eveId = Int32.Parse(item.ApiId);
                foreach (invTypeMaterial material in EveContext.invTypeMaterials.Where(m => m.typeID == eveId))
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

                    reprocessPrice += double.Parse(String.Format("{0:0.00}", (requiredItem.LatestPrice(system).GetPrice(sellMode) * Utils.ReprocessTax(material.quantity, refiningLevel, refineryEfficiencyLevel, scrapProcessingLevel, standing)) * (1 - Utils.SaleTax(accountingLevel))));
                }
                double profit = reprocessPrice - item.LatestPrice(system).GetPrice(buyMode);
                if (profit > 0) {
                    profitableItems.Add(new ProfitViewModel { Item = item, Profit = profit });
                }
            }
            return View("ProfitAnalysis", profitableItems);
        }
    }
}
