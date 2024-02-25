﻿namespace CurrencyExchangeCrud.Services.ServiceBase
{
    public interface ICrudAppService<T>
    {
        Task<List<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }
}
