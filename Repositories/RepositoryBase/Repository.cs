using CurrencyExchangeCrud.Data.Dtos;
using CurrencyExchangeCrud.Data.Models;
using CurrencyExchangeCrud.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace CurrencyExchangeCrud.Repositories.RepositoryBase
{
    public class Repository<TDataModel> : IRepository<TDataModel> where TDataModel : DataModelBase
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        protected readonly DbSet<TDataModel> DbSet;

        public Repository(ApplicationDbContext db, IMapper mapper)
        {
            DbSet = db.Set<TDataModel>();
            _mapper = mapper;
            _db = db;
        }

        public async Task<List<TViewModel>> GetAllAsync<TViewModel>()
        {
            try
            {
                var countryQuery = _mapper.ProjectTo<TViewModel>(DbSet);

                return await countryQuery.ToListAsync();
            }
            catch (DbUpdateException ex)
            {
                // Handle or log the exception
                Console.WriteLine($"Error getting list : {ex.Message}");
                throw null;
            }
        }

        public async Task<TViewModel?> GetByIdAsync<TViewModel>(int id) where TViewModel : ViewModelBase
        {
            try
            {
                var countryQuery = _mapper.ProjectTo<TViewModel>(DbSet)
                    .Where(m => m.Id == id);

                return await countryQuery.FirstOrDefaultAsync();
            }
            catch (DbUpdateException ex)
            {
                // Handle or log the exception
                Console.WriteLine($"Error getting data by id : {ex.Message}");
                throw null;
            }
        }

        public async Task CreateAsync(TDataModel entity)
        {
            try
            {
                await DbSet.AddAsync(entity);
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                // Handle or log the exception
                Console.WriteLine($"Error saving changes: {ex.Message}");
            }
        }

        public async Task UpdateAsync(TDataModel entity)
        {
            try
            {
                DbSet.Update(entity);
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                // Handle or log the exception
                Console.WriteLine($"Error updating changes: {ex.Message}");
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var country = await DbSet.FindAsync(id);

                if (country != null)
                {
                    DbSet.Remove(country);
                }

                await _db.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                // Handle or log the exception
                Console.WriteLine($"Error deleting changes : {ex.Message}");
            }
        }

        public async Task<bool> Exists(int id)
        {
            try
            {
                return await DbSet.AnyAsync(e => e.Id == id);
            }
            catch (DbUpdateException ex)
            {
                // Handle or log the exception
                Console.WriteLine($"Error deleting changes : {ex.Message}");
                throw null;
            }
        }
    }
}
