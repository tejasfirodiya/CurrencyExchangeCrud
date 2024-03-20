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
            try
            {
                var currency = await _currencyExchangeRateRepository.GetAllAsync<CurrencyExchangeRateDto>();

                var dtoModels = currency
                    .Select(d => _mapper.Map<CurrencyExchangeRateDto>(d))
                    .ToList();

                return dtoModels;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<CurrencyExchangeRateDto?> GetByIdAsync(int id)
        {
            try
            {
                var currency = await _currencyExchangeRateRepository.GetByIdAsync<CurrencyExchangeRateDto>(id);

                var dtoModels = _mapper.Map<CurrencyExchangeRateDto>(currency);

                return dtoModels;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task CreateAsync(CurrencyExchangeRateDto currencyExchangeRateDto)
        {
            try
            {
                var DataModel = _mapper.Map<CurrencyExchangeRate>(currencyExchangeRateDto);
                await _currencyExchangeRateRepository.CreateAsync(DataModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task UpdateAsync(CurrencyExchangeRateDto currencyExchangeRateDto)
        {
            try
            {
                var dtoModels = _mapper.Map<CurrencyExchangeRate>(currencyExchangeRateDto);
                await _currencyExchangeRateRepository.UpdateAsync(dtoModels);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                await _currencyExchangeRateRepository.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<double> GetExchangeRateToINRByCurrencyCode(string currencyCode, DateTime? exchangeDate = null)
        {
            try
            {
                var exchangeRate = await _currencyExchangeRateRepository.GetExchangeRateToINRByCurrencyCode(currencyCode, exchangeDate);
                return exchangeRate;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<double> GetExchangeRateToINRByCurrencyName(string currencyName, DateTime? exchangeDate = null)
        {
            try
            {
                var exchangeRate = await _currencyExchangeRateRepository.GetExchangeRateToINRByCurrencyName(currencyName, exchangeDate);
                return exchangeRate;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<double> GetExchangeRateByCurrencyCode(string sourceCurrencyCode, string targetCurrencyCode, DateTime? exchangDate = null)
        {
            try
            {
                var exchangeRate = await _currencyExchangeRateRepository.GetExchangeRateByCurrencyCode(sourceCurrencyCode, targetCurrencyCode, exchangDate);
                return exchangeRate;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<double> GetExchangeRateByCurrencyName(string sourceCurrencyName, string targetCurrencyName, DateTime? exchangDate = null)
        {
            try
            {
                var exchangeRate = await _currencyExchangeRateRepository.GetExchangeRateByCurrencyName(sourceCurrencyName, targetCurrencyName, exchangDate);

                return exchangeRate;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

    }
}
