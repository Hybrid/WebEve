﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebEve.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    
    public partial class EveHQDataEntities : DbContext
    {
        public EveHQDataEntities()
            : base("name=EveHQDataEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }

        /*public void UpdatePrice(Price price)
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
        }*/

        public DbSet<assetItemName> assetItemNames { get; set; }
        public DbSet<customPrice> customPrices { get; set; }
        public DbSet<eveIDToName> eveIDToNames { get; set; }
        public DbSet<eveMail> eveMails { get; set; }
        public DbSet<eveNotification> eveNotifications { get; set; }
        public DbSet<inventionResult> inventionResults { get; set; }
        public DbSet<marketPrice> marketPrices { get; set; }
        public DbSet<requisition> requisitions { get; set; }
        public DbSet<walletJournal> walletJournals { get; set; }
        public DbSet<walletTransaction> walletTransactions { get; set; }
    }
}
