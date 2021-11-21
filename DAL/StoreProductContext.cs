using System;
using System.Collections.Generic;
using System.Text;
using CloudDatabasesAssignment;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class StoreProductContext : DbContext
    {
        public DbSet<Product> products { get; set; }

        public StoreProductContext(DbContextOptions<StoreProductContext> options) : base(options)
        {

        }
    }
}
