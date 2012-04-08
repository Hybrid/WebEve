using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebEve.Models;
namespace WebEve.Repositories
{
    interface IMarketPriceRepository
    {
        Price FetchPrice(Item item, SolarSystem system);
        IEnumerable<Price> FetchPrices(IEnumerable<Item> items, SolarSystem system);
    }
}
