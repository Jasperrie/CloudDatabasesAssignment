using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;


namespace CloudDatabasesAssignment.DAL
{
    class StoreProductContext : DbContext
    {
        DbSet<StoreProduct> products { get; set; }

        public StoreProductContext(DbContextOptions<StoreProductContext> options) : base(options)
        {
        }

    }
}
