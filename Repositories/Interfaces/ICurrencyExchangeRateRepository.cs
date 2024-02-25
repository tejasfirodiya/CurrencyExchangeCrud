using CurrencyExchangeCrud.Data.Dtos;
using CurrencyExchangeCrud.Data.Models;
using CurrencyExchangeCrud.Repositories.RepositoryBase;

namespace CurrencyExchangeCrud.Repositories.Interfaces
{
    public interface ICurrencyExchangeRateRepository : IRepository<CurrencyExchangeRate>
    {
        Task<double> GetExchangeRateToINRByCurrencyCode(string currencyCode, DateTime? exchangeDate = null);
        Task<double> GetExchangeRateToINRByCurrencyName(string currencyName, DateTime? exchangeDate = null);

        Task<double> GetExchangeRateByCurrencyCode(string sourceCurrencyCode, string targetCurrencyCode, DateTime? exchangeDate = null);
        Task<double> GetExchangeRateByCurrencyName(string sourceCurrencyName, string targetCurrencyName, DateTime? exchangeDate = null);
    }
}
