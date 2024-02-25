namespace CurrencyExchangeCrud.Data.Dtos
{
    public class CurrencyExchangeRateDto : ViewModelBase
    {
        public int RefSourceCurrencyId { get; set; }
        public string RefSourceCurrencyName { get; set; } = null!;

        public int RefTargetCurrencyId { get; set; }
        public string RefTargetCurrencyName { get; set; } = null!;

        public DateTime ExchangeDate { get; set; }

        public double ExchangeRate { get; set; }
    }
}
