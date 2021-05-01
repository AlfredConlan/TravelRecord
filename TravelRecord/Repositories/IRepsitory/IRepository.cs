using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TravelRecord.Repository.IRepsitory
{
    /// <summary>
    /// Repository for all API calls
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T : class
    {

        Task<T> GetAsync(string url, int Id);
        Task<IEnumerable<T>> GetAllAsync(string url);
        Task<bool> CreateAsync(string url, T objToCreate);
        Task<bool> UpdateAsync(string url, T objToUpdate);
        Task<bool> DeleteAsync(string url, int Id);

    }
}
