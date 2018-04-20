using BrighterDarkerMemory.Web.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrighterDarkerMemory.Web.Controllers
{
    [Route("api/test-no-processor")]
    public class TestNoProcessorController : Controller
    {
        TestContext context;

        public TestNoProcessorController(TestContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var result = await context.TestItems.ToListAsync();
            return Ok(result);
        }
    }
}
