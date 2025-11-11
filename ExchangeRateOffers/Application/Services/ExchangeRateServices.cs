using ExchangeRateOffers.Application.Interfaces;
using ExchangeRateOffers.Domain.Models;
using Microsoft.Extensions.Logging;

namespace ExchangeRateOffers.Application.Services
{
    public class ExchangeRateService
    {
        private readonly IEnumerable<IExchangeRateProvider> _providers;
        private readonly ILogger<ExchangeRateService> _logger;

        public ExchangeRateService(IEnumerable<IExchangeRateProvider> providers, ILogger<ExchangeRateService> logger)
        {
            _providers = providers;
            _logger = logger;
        }

        public async Task<ExchangeResponse> GetBestOfferAsync(ExchangeRequest request)
        {
            var tasks = _providers.Select(async p =>
            {
                try
                {
                    return await p.GetExchangeRateAsync(request);
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Provider {p.Name} failed: {ex.Message}");
                    return new ExchangeResponse { Provider = p.Name, Success = false };
                }
            });

            var results = await Task.WhenAll(tasks);
            var valid = results.Where(r => r.Success);

            if (!valid.Any())
                throw new Exception("No valid responses from providers.");

            return valid.OrderByDescending(r => r.ConvertedAmount).First();
        }
    }
}
