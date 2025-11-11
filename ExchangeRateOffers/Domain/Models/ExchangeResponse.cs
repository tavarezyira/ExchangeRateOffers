namespace ExchangeRateOffers.Domain.Models
{
    public class ExchangeResponse
    {
        public string Provider { get; set; }
        public decimal ConvertedAmount { get; set; }
        public bool Success { get; set; }
    }
}
