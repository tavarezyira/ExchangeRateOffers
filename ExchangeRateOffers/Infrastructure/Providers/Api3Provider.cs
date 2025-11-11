using ExchangeRateOffers.Application.Interfaces;
using ExchangeRateOffers.Domain.Models;
using Newtonsoft.Json;

namespace ExchangeRateOffers.Infrastructure.Providers
{
    public class Api3Provider : IExchangeRateProvider
    {
        public string Name => "API3";

        public async Task<ExchangeResponse> GetExchangeRateAsync(ExchangeRequest request)
        {
            await Task.Delay(250);
            string json = "{\"statusCode\":200,\"data\":{\"total\":0.95}}";
            var data = JsonConvert.DeserializeObject<dynamic>(json);
            decimal rate = (decimal)data.data.total;

            return new ExchangeResponse
            {
                Provider = Name,
                ConvertedAmount = request.Amount * rate,
                Success = true
            };
        }
    }
}
