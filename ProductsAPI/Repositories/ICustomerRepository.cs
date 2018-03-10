using System.Collections.Generic;
using System.Threading.Tasks;
using ProductsAPI.Models;

namespace ProductsAPI.Repositories
{
    public interface ICustomerRepository
    {
        Task Delete(int Id);
        Task<Customer> Find(int Id);
        Task<IEnumerable<Customer>> Find(string keyword);
        Task<IEnumerable<Customer>> GetAll();
        Task Insert(Customer item);
        Task Update(Customer item);
    }
}