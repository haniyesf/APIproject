using System.Collections.Generic;
using System.Threading.Tasks;
using ProductsAPI.Models;

namespace ProductsAPI.Repositories
{
    public interface IVendorRepository
    {
        Task Delete(int id);
        Task<Vendor> Find(int id);
        Task<IEnumerable<Vendor>> Find(string name);
        Task<IEnumerable<Vendor>> GetAll();
        Task Insert(Vendor item);
        Task Update(Vendor item);
    }
}