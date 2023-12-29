using Microsoft.AspNetCore.Mvc;
using Galytix.WebApi.Services;
using System.Collections.Generic;

namespace Galytix.WebApi.Controllers
{
    [Route("api/gwp/avg")]
    [ApiController]
    public class CountryGwpController : ControllerBase
    {
        private readonly IGwpCalculatorService _gwpCalculatorService;

        public CountryGwpController(IGwpCalculatorService gwpCalculatorService)
        {
            _gwpCalculatorService = gwpCalculatorService;
        }

        [HttpPost]
        public IActionResult CalculateAverageGWP([FromBody] CountryGwpRequestModel request)
        {
            var calculatedValues = _gwpCalculatorService.CalculateAverageGWP(request.Country, request.Lob);

            return Ok(calculatedValues); // Return calculated values as JSON response
        }
    }


}
