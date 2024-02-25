using AutoMapper;
using CurrencyExchangeCrud.Data.Dtos;
using CurrencyExchangeCrud.Data.Models;
using CurrencyExchangeCrud.Repositories.Interfaces;
using CurrencyExchangeCrud.Services.Interfaces;

namespace CurrencyExchangeCrud.Services
{
    public class CurrencyExchangeRateAppService : ICurrencyExchangeRateAppService
    {
        private readonly ICurrencyExchangeRateRepository _currencyExchangeRateRepository;
        private readonly IMapper _mapper;

        public CurrencyExchangeRateAppService(IMapper mapper, ICurrencyExchangeRateRepository currencyExchangeRateRepository)
        {
            _currencyExchangeRateRepository = currencyExchangeRateRepository;
            _mapper = mapper;
        }

        public async Task<List<CurrencyExchangeRateDto>> GetAllAsync()
        {
            var currency = await _currencyExchangeRateRepository.GetAllAsync<CurrencyExchangeRateDto>();

            var dtoModels = currency
                .Select(d => _mapper.Map<CurrencyExchangeRateDto>(d))
                .ToList();

            return dtoModels;
        }

        public async Task<CurrencyExchangeRateDto?> GetByIdAsync(int id)
        {
            var currency = await _currencyExchangeRateRepository.GetByIdAsync<CurrencyExchangeRateDto>(id);

            var dtoModels = _mapper.Map<CurrencyExchangeRateDto>(currency);

            return dtoModels;
        }

        public async Task CreateAsync(CurrencyExchangeRateDto currencyExchangeRateDto)
        {
            var DataModel = _mapper.Map<CurrencyExchangeRate>(currencyExchangeRateDto);
            await _currencyExchangeRateRepository.CreateAsync(DataModel);
        }

        public async Task UpdateAsync(CurrencyExchangeRateDto currencyExchangeRateDto)
        {
            var dtoModels = _mapper.Map<CurrencyExchangeRate>(currencyExchangeRateDto);
            await _currencyExchangeRateRepository.UpdateAsync(dtoModels);
        }

        public async Task DeleteAsync(int id)
        {
            await _currencyExchangeRateRepository.DeleteAsync(id);
        }

        public async Task<double> GetExchangeRateToINRByCurrencyCode(string currencyCode, DateTime? exchangeDate = null)
        {
            var exchangeRate = await _currencyExchangeRateRepository.GetExchangeRateToINRByCurrencyCode(currencyCode, exchangeDate);
            return exchangeRate;
        }

        public async Task<double> GetExchangeRateToINRByCurrencyName(string currencyName, DateTime? exchangeDate = null)
        {
            var exchangeRate = await _currencyExchangeRateRepository.GetExchangeRateToINRByCurrencyName(currencyName, exchangeDate);
            return exchangeRate;
        }

        public async Task<double> GetExchangeRateByCurrencyCode(string sourceCurrencyCode, string targetCurrencyCode, DateTime? exchangDate = null)
        {
            var exchangeRate = await _currencyExchangeRateRepository.GetExchangeRateByCurrencyCode(sourceCurrencyCode, targetCurrencyCode, exchangDate);
            return exchangeRate;
        }

        public async Task<double> GetExchangeRateByCurrencyName(string sourceCurrencyName, string targetCurrencyName, DateTime? exchangDate = null)
        {
            var exchangeRate = await _currencyExchangeRateRepository.GetExchangeRateByCurrencyName(sourceCurrencyName, targetCurrencyName, exchangDate);

            return exchangeRate;
        }

    }
}
