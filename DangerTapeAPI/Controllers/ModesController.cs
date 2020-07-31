using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DangerTapeAPI.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ModesController : ControllerBase
    {
        public ModesController()
        {

        }

        [HttpGet]
        public async Task<ActionResult<List<string>>> GetAllModes()
        {
            var output = new List<string>
            {
                "Ionian",
                "Dorian"
            };

            return await Task.FromResult(output);
        }
    }
}