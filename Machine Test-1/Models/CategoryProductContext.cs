using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Machine_Test_1.Models
{
    public class CategoryProductContext : DbContext
    {
        public CategoryProductContext() : base("name=cs")
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}