using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebEve.Models
{
    public partial class EveHQDataEntities : DbContext
    {
        public void UpdatePrice(Price price)
        {
            int id = Int32.Parse(price.Item.ApiId);
            customPrice customPrice = customPrices.SingleOrDefault(cp => cp.typeID == id);
            if (customPrice == null)
            {
                customPrice = new customPrice();
                customPrice.typeID = Int32.Parse(price.Item.ApiId);
                customPrice.price = price.Sell;
                customPrice.priceDate = price.Date;
                this.customPrices.Add(customPrice);
            }
            else
            {
                customPrice.price = price.Sell;
                customPrice.priceDate = price.Date;
            }
        }
    }
}