using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrighterDarkerMemory.Web.Data
{
    public class TestContextInitializer
    {
        public static async Task Initialize(IServiceProvider services)
        {
            TestContext context =
                services.GetRequiredService<TestContext>();

            await context.Database.MigrateAsync();
            await SeedMediaBankContext(context);
        }

        protected static async Task SeedMediaBankContext(TestContext context)
        {
            //var any = await context.MediaItems.AnyAsync();

            //if (!any)
            //{
            //    // add temporary data if needed.
            //}
        }
    }
}
