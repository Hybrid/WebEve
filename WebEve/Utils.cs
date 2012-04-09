using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebEve.Models;

namespace WebEve
{
    public class Utils
    {
        public static int ReprocessTax(int quantity, int refiningLevel, int refineryEfficiencyLevel, int scrapProcessingLevel, double standing)
        {
            double ratio = 0.375 * (1 + 0.02 * refiningLevel) * (1 + 0.04 * refineryEfficiencyLevel) * (1 + 0.05 * scrapProcessingLevel);
            double netYield = 0.5;
            double standingTax = Math.Max(5 - (0.75 * standing), 0) / 100;
            return (int)Math.Round(quantity * (Math.Min((netYield + ratio), 1) - standingTax));
        }

        public static double SaleTax(int accountingLevel) 
        {
            return (1 - (accountingLevel * 0.10)) / 100; 
        }

        public static SelectList PriceModeSelect() {
            IList<string> modes = new List<String>{ Price.BUY, Price.SELL };
            return new SelectList(modes); 
        }
    }
}