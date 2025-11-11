﻿using ExchangeRateOffers.Application.Services;
using ExchangeRateOffers.Application.Interfaces;
using ExchangeRateOffers.Infrastructure.Providers;
using ExchangeRateOffers.Domain.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

var services = new ServiceCollection();
services.AddLogging(builder => builder.AddConsole());
services.AddTransient<IExchangeRateProvider, Api1Provider>();
services.AddTransient<IExchangeRateProvider, Api2Provider>();
services.AddTransient<IExchangeRateProvider, Api3Provider>();
services.AddTransient<ExchangeRateService>();

var provider = services.BuildServiceProvider();

var service = provider.GetRequiredService<ExchangeRateService>();

var request = new ExchangeRequest
{
    SourceCurrency = "USD",
    TargetCurrency = "EUR",
    Amount = 1000
};

var bestOffer = await service.GetBestOfferAsync(request);

Console.WriteLine($"Best offer: {bestOffer.Provider} => {bestOffer.ConvertedAmount} {request.TargetCurrency}");

