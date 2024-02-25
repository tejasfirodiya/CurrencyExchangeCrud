using AutoMapper;
using CurrencyExchangeCrud.Data;
using CurrencyExchangeCrud.Data.Models;
using CurrencyExchangeCrud.Repositories.Interfaces;
using CurrencyExchangeCrud.Repositories.RepositoryBase;

namespace CurrencyExchangeCrud.Repositories
{
    public class CurrencyRepository : Repository<CurrencyMaster>, ICurrencyRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public CurrencyRepository(ApplicationDbContext db, IMapper mapper) : base(db, mapper)
        {
            _db = db;
            _mapper = mapper;
        }
    }
}
