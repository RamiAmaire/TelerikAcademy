using System;
using System.Data.Entity;
using ProductsDB.Model;

namespace ProductsDB.Data
{
    public class ProductsDBContext : DbContext
    {
        public ProductsDBContext()
            :base("ProductsDB")
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Measure> Measures { get; set; }
        public DbSet<SalesReport> SalesReports { get; set; }
        public DbSet<Expense> Expenses { get; set; }
    }
}
