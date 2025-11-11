using ExchangeRateOffers.Application.Interfaces;
using ExchangeRateOffers.Domain.Models;
using System.Xml.Linq;

namespace ExchangeRateOffers.Infrastructure.Providers
{
    public class Api2Provider : IExchangeRateProvider
    {
        public string Name => "API2";

        public async Task<ExchangeResponse> GetExchangeRateAsync(ExchangeRequest request)
        {
            await Task.Delay(200);
            string xml = "<XML><Result>0.94</Result></XML>";
            var xdoc = XDocument.Parse(xml);
            decimal rate = decimal.Parse(xdoc.Root.Element("Result").Value);

            return new ExchangeResponse
            {
                Provider = Name,
                ConvertedAmount = request.Amount * rate,
                Success = true
            };
        }
    }
}
