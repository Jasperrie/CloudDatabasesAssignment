using CloudDatabasesAssignment.DAL;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace CloudDatabasesAssignment
{
    class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<StoreProductContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
