using System;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace OnlineStore.Data
{
    public static class OnlineStoreDbContextFactory
    {
        public static OnlineStoreDbContext Create()
        {
            var basePath = AppContext.BaseDirectory;

            var builder = new ConfigurationBuilder().SetBasePath(basePath).AddJsonFile("appsettings.json");

            var configuration = builder.Build();

            var build = new DbContextOptionsBuilder<OnlineStoreDbContext>();
            build.UseSqlServer(configuration.GetConnectionString("MSSqlServer"));
            //build.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=FoodShop.Dev;Trusted_Connection=True;MultipleActiveResultSets=true");
            return new OnlineStoreDbContext(build.Options);

        }
    }
}


