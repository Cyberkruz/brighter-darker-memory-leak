using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BrighterDarkerMemory.Web.Data
{
    public class DesignTimeDbContextFactory
        : IDesignTimeDbContextFactory<TestContext>
    {
        public TestContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<TestContext>();

            var connectionString = configuration.GetConnectionString("SqlDatabaseConnection");

            builder.UseSqlServer(connectionString);

            return new TestContext(builder.Options);
        }
    }
}
