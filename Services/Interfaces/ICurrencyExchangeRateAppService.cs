using CurrencyExchangeCrud.Data.Dtos;
using CurrencyExchangeCrud.Services.ServiceBase;

namespace CurrencyExchangeCrud.Services.Interfaces
{
    public interface ICurrencyExchangeRateAppService : ICrudAppService<CurrencyExchangeRateDto>
    {
        Task<double> GetExchangeRateToINRByCurrencyCode(string currencyCode, DateTime? exchangeDate = null);
        Task<double> GetExchangeRateToINRByCurrencyName(string currencyName, DateTime? exchangeDate = null);

        Task<double> GetExchangeRateByCurrencyCode(string sourceCurrencyCode, string targetCurrencyCode, DateTime? exchangeDate = null);
        Task<double> GetExchangeRateByCurrencyName(string sourceCurrencyName, string targetCurrencyName, DateTime? exchangeDate = null);
    }
}
