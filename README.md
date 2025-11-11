# Exchange Rate Offers — Technical Test

A C#/.NET 9 console app that compares multiple currency exchange rate APIs and selects the best offer.  
Developed as a technical test following Clean Architecture and SOLID principles.

---

## Features

- Queries multiple APIs (mocked) with different formats (JSON, XML)
- Handles unavailable or invalid API responses gracefully
- Returns the best exchange offer in the least possible time
- Fully unit-tested (xUnit + Moq)
- No UI, no SQL — console only

---

## Architecture

Domain/
├── Models/
Application/
├── Interfaces/
├── Services/
Infrastructure/
├── Providers/
ExchangeRateOffers.Tests/

---

## Run Locally

```bash
dotnet restore
dotnet build
dotnet run --project ExchangeRateOffers/ExchangeRateOffers.csproj

```

---

## Run Unit Tests

dotnet test

---

## Tech Stack

- C# / .NET 9
- xUnit + Moq (unit testing)
- Microsoft.Extensions.Logging
- Clean Architecture
