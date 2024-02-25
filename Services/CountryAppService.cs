using AutoMapper;
using CurrencyExchangeCrud.Data.Dtos;
using CurrencyExchangeCrud.Data.Models;
using CurrencyExchangeCrud.Repositories.Interfaces;
using CurrencyExchangeCrud.Services.Interfaces;

namespace CurrencyExchangeCrud.Services
{
    public class CountryAppService : ICountryAppService
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public CountryAppService(IMapper mapper, ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        public async Task CreateAsync(CountryMasterDto countryDto)
        {
            countryDto.Name = countryDto.Name.Normalize();
            var countryDataModel = _mapper.Map<CountryMaster>(countryDto);
            await _countryRepository.CreateAsync(countryDataModel);
        }

        public async Task DeleteAsync(int id)
        {
            await _countryRepository.DeleteAsync(id);
        }

        public async Task<List<CountryMasterDto>> GetAllAsync()
        {
            var country = await _countryRepository.GetAllAsync<CountryMasterDto>();

            var countryDtoModels = country
                .Select(d => _mapper.Map<CountryMasterDto>(d))
                .ToList();

            return countryDtoModels;
        }

        public async Task<CountryMasterDto?> GetByIdAsync(int id)
        {
            var country = await _countryRepository.GetByIdAsync<CountryMasterDto>(id);

            var countryDtoModels = _mapper.Map<CountryMasterDto>(country);

            return countryDtoModels;
        }

        public async Task UpdateAsync(CountryMasterDto countryDto)
        {
            var countryDtoModels = _mapper.Map<CountryMaster>(countryDto);
            await _countryRepository.UpdateAsync(countryDtoModels);
        }
    }
}
