using NUnit.Framework;
using Galytix.WebApi.Controllers;
using Galytix.WebApi.Services;
using System.Collections.Generic;

namespace Galytix.WebApi.Tests
{
    [TestFixture]
    public class CountryGwpControllerTests
    {
        [Test]
        public void CalculateAverageGWP_Returns_Ok()
        {
            // Arrange
            var mockService = new MockGwpCalculatorService(); 
            var controller = new CountryGwpController(mockService);

            var request = new CountryGwpRequestModel
            {
                Country = "ae",
                Lob = new List<string> { "property", "transport" }
            };

            // Act
            var result = controller.CalculateAverageGWP(request) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(200, result.StatusCode);

            
        }
    }

 
    public class MockGwpCalculatorService : IGwpCalculatorService
    {
        public Dictionary<string, decimal> CalculateAverageGWP(string country, List<string> lob)
        {
            
            var calculatedValues = new Dictionary<string, decimal>
            {
                { "property", 1000000M },
                { "transport", 2000000M }
            };

            return calculatedValues;
        }
    }
}
