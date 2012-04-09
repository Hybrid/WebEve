using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebEve.Models
{
    public partial class Item
    {
        public Price LatestPrice()
        {
            return Prices.OrderByDescending(p => p.Date).First();
        }
        public Price LatestPrice(SolarSystem system)
        {
            return Prices.Where(p => p.SolarSystemId == system.Id).OrderByDescending(p => p.Date).First();
        }
    }
}