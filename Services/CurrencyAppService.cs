using AutoMapper;
using CurrencyExchangeCrud.Data.Dtos;
using CurrencyExchangeCrud.Data.Models;
using CurrencyExchangeCrud.Repositories.Interfaces;
using CurrencyExchangeCrud.Services.Interfaces;

namespace CurrencyExchangeCrud.Services
{
    public class CurrencyAppService : ICurrencyAppService
    {
        private readonly ICurrencyRepository _currencyRepository;
        private readonly IMapper _mapper;

        public CurrencyAppService(IMapper mapper, ICurrencyRepository currencyRepository)
        {
            _currencyRepository = currencyRepository;
            _mapper = mapper;
        }

        public async Task CreateAsync(CurrencyMasterDto currencyDto)
        {
            try
            {
                currencyDto.Name = currencyDto.Name.Normalize();
                currencyDto.Code = currencyDto.Code.ToUpper();
                var DataModel = _mapper.Map<CurrencyMaster>(currencyDto);
                await _currencyRepository.CreateAsync(DataModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task DeleteAsync(int id)
        {
            await _currencyRepository.DeleteAsync(id);
        }

        public async Task<List<CurrencyMasterDto>> GetAllAsync()
        {
            var currency = await _currencyRepository.GetAllAsync<CurrencyMasterDto>();

            var dtoModels = currency
                .Select(d => _mapper.Map<CurrencyMasterDto>(d))
                .ToList();

            return dtoModels;
        }

        public async Task<CurrencyMasterDto?> GetByIdAsync(int id)
        {
            var currency = await _currencyRepository.GetByIdAsync<CurrencyMasterDto>(id);

            var dtoModels = _mapper.Map<CurrencyMasterDto>(currency);

            return dtoModels;
        }

        public async Task UpdateAsync(CurrencyMasterDto currencyDto)
        {
            var dtoModels = _mapper.Map<CurrencyMaster>(currencyDto);
            await _currencyRepository.UpdateAsync(dtoModels);
        }
    }
}
