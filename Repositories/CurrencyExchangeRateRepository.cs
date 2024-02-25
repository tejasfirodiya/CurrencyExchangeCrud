using AutoMapper;
using CurrencyExchangeCrud.Data.Dtos;
using CurrencyExchangeCrud.Data.Models;
using CurrencyExchangeCrud.Data;
using CurrencyExchangeCrud.Repositories.Interfaces;
using CurrencyExchangeCrud.Repositories.RepositoryBase;
using Microsoft.EntityFrameworkCore;

namespace CurrencyExchangeCrud.Repositories
{
    public class CurrencyExchangeRateRepository : Repository<CurrencyExchangeRate>, ICurrencyExchangeRateRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public CurrencyExchangeRateRepository(ApplicationDbContext db, IMapper mapper) : base(db, mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<double> GetExchangeRateToINRByCurrencyCode(string currencyCode, DateTime? exchangeDate = null)
        {
            CurrencyMaster? filteredCurrency = await _db.Currencies
                .Where(xv => xv.Code == currencyCode.ToUpper())
                .FirstOrDefaultAsync();

            if (filteredCurrency == null)
            {
                return 0.0;
            }

            IQueryable<CurrencyExchangeRate> query = _db.CurrencyExchangeRates
                .Where(x => x.RefSourceCurrencyId == filteredCurrency.Id);

            if (exchangeDate.HasValue)
            {
                query = query.Where(x => x.ExchangeDate.Date == exchangeDate.Value.Date);
            }

            CurrencyExchangeRate? currencyExchangeRates = await query.FirstOrDefaultAsync();

            return (double)(currencyExchangeRates?.ExchangeRate ?? 0.0);
        }

        public async Task<double> GetExchangeRateToINRByCurrencyName(string currencyName, DateTime? exchangeDate = null)
        {
            CurrencyMaster? filteredCurrency = await _db.Currencies
                .Where(xv => xv.Name == currencyName.ToUpper())
                .FirstOrDefaultAsync();

            if (filteredCurrency == null)
            {
                return 0.0;
            }

            IQueryable<CurrencyExchangeRate> query = _db.CurrencyExchangeRates
                .Where(x => x.RefSourceCurrencyId == filteredCurrency.Id);

            if (exchangeDate.HasValue)
            {
                query = query.Where(x => x.ExchangeDate.Date == exchangeDate.Value.Date);
            }

            CurrencyExchangeRate? currencyExchangeRates = await query.FirstOrDefaultAsync();

            return (double)(currencyExchangeRates?.ExchangeRate ?? 0.0);
        }

        public async Task<double> GetExchangeRateByCurrencyCode(string sourceCurrencyCode, string targetCurrencyCode, DateTime? exchangeDate = null)
        {
            CurrencyMaster? filteredSourceCurrency = await _db.Currencies
               .Where(xv => xv.Code == sourceCurrencyCode.ToUpper())
               .FirstOrDefaultAsync();

            CurrencyMaster? filteredTargetCurrency = await _db.Currencies.Where(xv => xv.Code == targetCurrencyCode.ToUpper())?.FirstOrDefaultAsync();

            if (filteredSourceCurrency == null || filteredTargetCurrency == null)
            {
                return 0.0;
            }

            IQueryable<CurrencyExchangeRate> query = _db.CurrencyExchangeRates
                .Where(x => x.RefSourceCurrencyId == filteredSourceCurrency.Id && x.RefTargetCurrencyId == filteredTargetCurrency.Id);

            if (exchangeDate.HasValue)
            {
                query = query.Where(x => x.ExchangeDate.Date == exchangeDate.Value.Date);
            }

            CurrencyExchangeRate? currencyExchangeRates = await query.FirstOrDefaultAsync();

            return (double)(currencyExchangeRates?.ExchangeRate ?? 0.0);
        }

        public async Task<double> GetExchangeRateByCurrencyName(string sourceCurrencyName, string targetCurrencyName, DateTime? exchangeDate = null)
        {
            CurrencyMaster? filteredSourceCurrency = await _db.Currencies
               .Where(xv => xv.Name == sourceCurrencyName.ToUpper())
               .FirstOrDefaultAsync();

            CurrencyMaster? filteredTargetCurrency = await _db.Currencies.Where(xv => xv.Name == targetCurrencyName.ToUpper())?.FirstOrDefaultAsync();

            if (filteredSourceCurrency == null || filteredTargetCurrency == null)
            {
                return 0.0;
            }

            IQueryable<CurrencyExchangeRate> query = _db.CurrencyExchangeRates
                .Where(x => x.RefSourceCurrencyId == filteredSourceCurrency.Id && x.RefTargetCurrencyId == filteredTargetCurrency.Id);

            if (exchangeDate.HasValue)
            {
                query = query.Where(x => x.ExchangeDate.Date == exchangeDate.Value.Date);
            }

            CurrencyExchangeRate? currencyExchangeRates = await query.FirstOrDefaultAsync();

            return (double)(currencyExchangeRates?.ExchangeRate ?? 0.0);
        }
    }
}
