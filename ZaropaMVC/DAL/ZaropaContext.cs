using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using ZaropaMVC.Entities;

namespace ZaropaMVC.DAL
{
	public class ZaropaContext: DbContext
	{
        public ZaropaContext() : base("DefaultConnectionZaropa")
        {
            Database.SetInitializer<ZaropaContext>(new DropCreateDatabaseIfModelChanges<ZaropaContext>() );
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Shoes> Shoes { get; set; }
        public DbSet<Tiers> Tiers { get; set; }
        public DbSet<Sales> Sales { get; set; }
   
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public System.Data.Entity.DbSet<ZaropaMVC.Models.Admin> Admins { get; set; }

        public System.Data.Entity.DbSet<ZaropaMVC.Models.ExpandedUserDTO> ExpandedUserDTOes { get; set; }
    }
}