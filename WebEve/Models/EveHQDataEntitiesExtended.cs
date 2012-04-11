using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebEve.Models
{
    public partial class EveHQDataEntities : DbContext
    {
        public void UpdatePrice(Price price, string PriceMode)
        {
            int id = Int32.Parse(price.Item.ApiId);
            customPrice customPrice = this.CustomPrices.SingleOrDefault(cp => cp.typeID == id);
            if (customPrice == null)
            {
                customPrice = new customPrice();
                customPrice.typeID = Int32.Parse(price.Item.ApiId);
                customPrice.price = price.GetPrice(PriceMode);
                customPrice.priceDate = price.Date;
                this.CustomPrices.Add(customPrice);
            }
            else
            {
                customPrice.price = price.GetPrice(PriceMode);
                customPrice.priceDate = price.Date;
            }
        }
    }
}