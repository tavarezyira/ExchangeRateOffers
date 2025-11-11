using ExchangeRateOffers.Application.Services;
using ExchangeRateOffers.Application.Interfaces;
using ExchangeRateOffers.Domain.Models;
using Microsoft.Extensions.Logging;
using Moq;

namespace ExchangeRateOffers.Tests
{
    public class ExchangeRateServiceTests
    {
        [Fact]
        public async Task ShouldReturnHighestRate()
        {
            var logger = Mock.Of<ILogger<ExchangeRateService>>();

            var provider1 = new Mock<IExchangeRateProvider>();
            provider1.Setup(p => p.GetExchangeRateAsync(It.IsAny<ExchangeRequest>()))
                     .ReturnsAsync(new ExchangeResponse { Provider = "A", ConvertedAmount = 100, Success = true });

            var provider2 = new Mock<IExchangeRateProvider>();
            provider2.Setup(p => p.GetExchangeRateAsync(It.IsAny<ExchangeRequest>()))
                     .ReturnsAsync(new ExchangeResponse { Provider = "B", ConvertedAmount = 120, Success = true });

            var service = new ExchangeRateService(new[] { provider1.Object, provider2.Object }, logger);

            var result = await service.GetBestOfferAsync(new ExchangeRequest { Amount = 100 });
            Assert.Equal("B", result.Provider);
        }
    }
}
