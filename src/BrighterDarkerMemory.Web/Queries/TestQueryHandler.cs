using BrighterDarkerMemory.Web.Data;
using BrighterDarkerMemory.Web.Domain;
using Microsoft.EntityFrameworkCore;
using Paramore.Darker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BrighterDarkerMemory.Web.Queries
{
    public class TestQueryHandler : QueryHandlerAsync<TestQuery, IEnumerable<TestItem>>
    {
        TestContext context;

        public TestQueryHandler(TestContext context)
        {
            this.context = context;
        }

        public override async Task<IEnumerable<TestItem>> ExecuteAsync(TestQuery query, 
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var result = await context.TestItems.ToListAsync();
            return result;
        }
    }
}
