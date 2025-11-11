using ExchangeRateOffers.Application.Interfaces;
using ExchangeRateOffers.Domain.Models;
using Newtonsoft.Json;

namespace ExchangeRateOffers.Infrastructure.Providers
{
    public class Api1Provider : IExchangeRateProvider
    {
        public string Name => "API1";

        public async Task<ExchangeResponse> GetExchangeRateAsync(ExchangeRequest request)
        {
            await Task.Delay(300); // simulate latency
            string json = "{\"rate\": 0.92}";
            var data = JsonConvert.DeserializeObject<dynamic>(json);
            decimal rate = (decimal)data.rate;

            return new ExchangeResponse
            {
                Provider = Name,
                ConvertedAmount = request.Amount * rate,
                Success = true
            };
        }
    }
}
