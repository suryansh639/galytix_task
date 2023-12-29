namespace Galytix.WebApi.Services
{
    public interface IYourService
    {
        
        object PerformCalculations(CountryGwpRequestModel request);
    }

    public class YourService : IYourService
    {
        
        public object PerformCalculations(CountryGwpRequestModel request)
        {
           

            return new { };
        }
    }
}
