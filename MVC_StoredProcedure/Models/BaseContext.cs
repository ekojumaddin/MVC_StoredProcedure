using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_StoredProcedure.Models
{
    public class BaseContext: DbContext
    {
        public BaseContext() : base( "name = BaseContext" )  
        {
        }

        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Item> Items { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Supplier>().MapToStoredProcedures();
            modelBuilder.Entity<Item>().MapToStoredProcedures();
        }
    }
}