using BrighterDarkerMemory.Web.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrighterDarkerMemory.Web.Data
{
    public class TestContext : DbContext
    {
        public TestContext(DbContextOptions<TestContext> options)
            : base(options)
        {

        }

        public virtual DbSet<TestItem> TestItems { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

        }
    }
}
