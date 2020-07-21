using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<ItemGroup> ItemGroups { get; set; }
        public DbSet<Item> Item { get; set; }
    }
}