using Microsoft.AspNetCore.Mvc;
using Galytix.WebApi.Services;
using System;
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
            try
            {
                if (request == null || string.IsNullOrEmpty(request.Country) || request.Lob == null || request.Lob.Count == 0)
                {
                    return BadRequest("Invalid request. Please provide country and line of business data.");
                }

                var calculatedValues = _gwpCalculatorService.CalculateAverageGWP(request.Country, request.Lob);

                return Ok(calculatedValues);
            }
            catch (Exception ex)
            {
               

                return StatusCode(500, "An error occurred while processing the request.");
            }
        }
    }

    
}
