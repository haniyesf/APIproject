using System.Collections.Generic;
using System.Threading.Tasks;
using ProductsAPI.Models;

namespace ProductsAPI.Repositories
{
    public interface IProductRepository
    {
        Task Delete(int id);
        Task<ProductDetail> Find(int id);
        Task<IEnumerable<ProductDetail>> Find(string name);
        Task<IEnumerable<ProductDetail>> GetAll();
        Task Insert(ProductDetail item);
        Task Update(ProductDetail item);
    }
}