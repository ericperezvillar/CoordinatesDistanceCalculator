using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.DataAccess.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IReadOnlyList<T>> GetAllAsync();

        Task<T> AddAsync(T entity);
    }
}
