using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Galytix.WebApi.Controllers
{
    [Route("api/gwp/avg")]
    [ApiController]
    public class CountryGwpController : ControllerBase
    {
        [HttpPost]
        public IActionResult CalculateAverageGWP([FromBody] CountryGwpRequestModel request)
        {
            // Your logic to calculate average GWP based on 'request' data
            // Sample response
            var response = new Dictionary<string, decimal>
            {
                { "transport", 446001906.1M },
                { "liability", 634545022.9M }
            };

            return Ok(response); // Return calculated values as JSON response
        }
    }

    public class CountryGwpRequestModel
    {
        public string Country { get; set; }
        public List<string> Lob { get; set; }
    }
}

public async Task<IActionResult> CalculateAverageGWP([FromBody] CountryGwpRequestModel request)
{
    
    var result = await SomeAsyncOperation(request);

    

    return Ok(result); 
}