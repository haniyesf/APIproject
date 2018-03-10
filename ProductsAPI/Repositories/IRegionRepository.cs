using System.Collections.Generic;
using System.Threading.Tasks;
using ProductsAPI.Models;

namespace ProductsAPI.Repositories
{
    public interface IRegionRepository
    {
        Task Delete(int id);
        Task<Region> Find(int id);
        Task<IEnumerable<Region>> Find(string name);
        Task<IEnumerable<Region>> GetAll();
        Task Insert(Region item);
        Task Update(Region item);
    }
}