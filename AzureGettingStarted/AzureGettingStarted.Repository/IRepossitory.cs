using System.Collections.Generic;
using System.Threading.Tasks;

namespace AzureGettingStarted.Repository
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        Task<T> Get(int id);
        Task<bool> Insert(T entity);
        Task<bool> Delete(int id);
        Task<bool> Update(T entity);
    }
}
