namespace Galytix.WebApi.Services
{
    public interface IGwpCalculatorService
    {
        Dictionary<string, decimal> CalculateAverageGWP(string country, List<string> lob);
    }

    public class GwpCalculatorService : IGwpCalculatorService
    {
        public Dictionary<string, decimal> CalculateAverageGWP(string country, List<string> lob)
        {
            // Placeholder logic to calculate average GWP for illustration
            var calculatedValues = new Dictionary<string, decimal>();

            foreach (var lineOfBusiness in lob)
            {
                decimal averageGWP = /* Perform actual calculation based on country and lineOfBusiness */;
                calculatedValues.Add(lineOfBusiness, averageGWP);
            }

            return calculatedValues;
        }
    }
}
