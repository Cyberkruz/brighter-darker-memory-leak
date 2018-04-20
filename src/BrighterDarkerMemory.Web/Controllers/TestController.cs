using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BrighterDarkerMemory.Web.Queries;
using Microsoft.AspNetCore.Mvc;
using Paramore.Darker;

namespace BrighterDarkerMemory.Web.Controllers
{
    [Route("api/test")]
    public class TestController : Controller
    {
        IQueryProcessor queryProcessor;

        public TestController(IQueryProcessor queryProcessor)
        {
            this.queryProcessor = queryProcessor;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var result = await queryProcessor.ExecuteAsync(new TestQuery());
            return Ok(result);
        }
    }
}
