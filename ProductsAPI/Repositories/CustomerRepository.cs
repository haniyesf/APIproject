using ProductsAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ProductsAPI.Repositories
{
  public class CustomerRepository
  {

    private Models.AllContext db;

    public CustomerRepository()
    {
      db = new Models.AllContext();
    }

    public async Task<IEnumerable<Customer>> GetAll()
    {
      return await this.db.Customers.ToListAsync();
    }

    public Task<Customer> Find(int Id)
    {
      return this.db.Customers.SingleOrDefaultAsync(row => row.Id == Id);
    }

    public async Task<IEnumerable<Customer>> Find(string keyword)
    {
      return await this.db.Customers.Where(row => row.FirstName.Contains(keyword)).ToListAsync();
    }

    public Task Insert(Customer item)
    {
      this.db.Customers.Add(item);
      return this.db.SaveChangesAsync();
    }

    public Task Update(Customer item)
    {
      var entity = this.db.Entry(item);
      entity.State = EntityState.Modified;

      return this.db.SaveChangesAsync();
    }

    public async Task Delete(int Id)
    {
      var customer = await this.Find(Id);
      if (customer == null)
      {
        return;
      }
      else
      {
        this.db.Customers.Remove(customer);
        await this.db.SaveChangesAsync();
      }
    }
  }
}