using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using WebEve.Models;
namespace WebEve.Repositories
{
    public class EveCentralRepository : IMarketPriceRepository
    {
        private string _priceURL = "http://api.eve-central.com/api/marketstat?{0}";
        Price IMarketPriceRepository.FetchPrice(Item item, SolarSystem system)
        {
            string urlData = String.Format("typeid={0}&usesystem={1}", item.ApiId, system.ApiId);
            XDocument doc = XDocument.Load(String.Format(_priceURL, urlData));
            XElement itemElement = doc.Element("evec_api").Element("marketstat").Elements("type").First();
            Price price = new Price
            {
                Item = item,
                SolarSystem = system,
                Buy = Double.Parse(itemElement.Element("buy").Element("max").Value),
                Sell = Double.Parse(itemElement.Element("sell").Element("min").Value),
                Date = DateTime.Today
            };
            return price;
        }

        IEnumerable<Price> IMarketPriceRepository.FetchPrices(IEnumerable<Item> items, SolarSystem system)
        {
            string urlData = "";
            foreach (Item item in items)
            {
                urlData += "typeid=" + item.ApiId + "&";
            }
            urlData += "usesystem=" + system.ApiId;

            XDocument doc = XDocument.Load(String.Format(String.Format(_priceURL, urlData)));
            IEnumerable<XElement> itemElements = doc.Element("evec_api").Element("marketstat").Elements("type");
            IList<Price> prices = new List<Price>();
            foreach (XElement itemElement in itemElements)
            {
                string itemApi = itemElement.Attribute("id").Value;
                Item currentItem = items.Single(i => i.ApiId.Equals(itemApi));
                Price price = new Price
                {
                    Item = currentItem,
                    SolarSystem = system,
                    Buy = Double.Parse(itemElement.Element("buy").Element("max").Value),
                    Sell = Double.Parse(itemElement.Element("sell").Element("min").Value),
                    Date = DateTime.Today
                };
                prices.Add(price);
            }
            return prices.AsEnumerable();
        }
    }
}