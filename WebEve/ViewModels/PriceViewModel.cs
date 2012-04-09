using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebEve.Models;
using System.Web.Mvc;

namespace WebEve.ViewModels
{
    public class PriceViewModel
    {
        public IQueryable<Item> Items { get; set; }
        public SelectList Systems { get; set; }
        public SelectList PriceModes{ get { return Utils.PriceModeSelect(); } }
    }
}