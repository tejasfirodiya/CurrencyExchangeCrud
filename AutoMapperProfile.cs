using AutoMapper;
using CurrencyExchangeCrud.Data.Dtos;
using CurrencyExchangeCrud.Data.Models;

namespace CurrencyExchangeCrud
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CountryMaster, CountryMasterDto>()
            .ForMember(a => a.Name, ab => ab.MapFrom(mf => mf.RefCurrencyMaster.Name))
            .ReverseMap()
            .ForPath(em => em.RefCurrencyMaster.Name, opt => opt.Ignore());

            CreateMap<CurrencyMaster, CurrencyMasterDto>().ReverseMap();

            CreateMap<CurrencyExchangeRate, CurrencyExchangeRateDto>()
            .ForMember(a => a.RefSourceCurrencyName, ab => ab.MapFrom(mf => mf.RefSourceCurrencyMaster.Name))
            .ForMember(a => a.RefTargetCurrencyName, ab => ab.MapFrom(mf => mf.RefTargetCurrencyMaster.Name))
            .ReverseMap()
            .ForPath(em => em.RefSourceCurrencyMaster.Name, opt => opt.Ignore())
            .ForPath(em => em.RefTargetCurrencyMaster.Name, opt => opt.Ignore());
        }
    }
}
