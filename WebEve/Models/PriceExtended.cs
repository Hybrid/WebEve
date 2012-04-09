using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebEve.Models
{
    public partial class Price
    {
        public const string BUY = "Buy";
        public const string SELL = "Sell";

        public double GetPrice(string priceMode) {
            if (priceMode.Equals(BUY)) { 
                return this.Buy;
            }
            else if (priceMode.Equals(SELL)) {
                return this.Sell;
            }
            return 0;
        }
    }
}