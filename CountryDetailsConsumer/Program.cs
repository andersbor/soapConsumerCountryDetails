using System;
using System.Threading.Tasks;
using CountryDetailsConsumer.ServiceReference1;

namespace CountryDetailsConsumer
{
    class Program
    {
        static void Main()
        {
            string endpointName = "countrySoap12"; // found in App.config
            using (countrySoapClient client = new countrySoapClient(endpointName))
            {
                // This service has many methods
                // Most methods return (long) XML documents with lots of information
                string allCountries = client.GetCountries();
                Console.WriteLine(allCountries);
                 
                Console.WriteLine("Currency information for Denmark");
                string currencyInfo = client.GetCurrencyByCountry("Denmark");
                Console.WriteLine(currencyInfo);

                Console.WriteLine("Async version: Currency information for Denmark");
                Task<string> task = client.GetCurrencyByCountryAsync("Denmark");
                string cInfo = task.Result;
                Console.WriteLine(cInfo);
            }
        }
    }
}
