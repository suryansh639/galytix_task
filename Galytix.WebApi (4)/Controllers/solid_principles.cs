using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Galytix.WebApi.Controllers
{
    [Route("api/gwp/avg")]
    [ApiController]
    public class CountryGwpController : ControllerBase
    {
        private readonly IYourService _yourService;

        public CountryGwpController(IYourService yourService)
        {
            _yourService = yourService;
        }

        [HttpPost]
        public IActionResult CalculateAverageGWP([FromBody] CountryGwpRequestModel request)
        {
            
            var result = _yourService.PerformCalculations(request);

            return Ok(result); 
        }
    }

    public class CountryGwpRequestModel
    {
        public string Country { get; set; }
        public List<string> Lob { get; set; }
    }
}
