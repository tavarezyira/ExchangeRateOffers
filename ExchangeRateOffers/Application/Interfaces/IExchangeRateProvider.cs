using System.Threading.Tasks;
using ExchangeRateOffers.Domain.Models;

namespace ExchangeRateOffers.Application.Interfaces
{
    public interface IExchangeRateProvider
    {
        string Name { get; }
        Task<ExchangeResponse> GetExchangeRateAsync(ExchangeRequest request);
    }
}
