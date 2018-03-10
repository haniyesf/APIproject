using System.Collections.Generic;
using System.Threading.Tasks;
using ProductsAPI.Models;

namespace ProductsAPI.Repositories
{
    public interface IFactorRepository
    {
        Task Delete(int id);
        Task<Factor> Find(int id);
        Task<IEnumerable<Factor>> Find(string date);
        Task<IEnumerable<Factor>> GetAll();
        Task Insert(Factor item);
        Task Update(Factor item);
    }
}