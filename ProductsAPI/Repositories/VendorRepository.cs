using ProductsAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ProductsAPI.Repositories
{
    public class VendorRepository : IVendorRepository
    {

        private Models.AllContext db;

        public VendorRepository()
        {
            db = new Models.AllContext();
        }

        public async Task<IEnumerable<Vendor>> GetAll()
        {
            return await this.db.Vendors.ToListAsync();
        }

        public async Task<Vendor> Find(int id)
        {
            return await this.db.Vendors.SingleOrDefaultAsync(item => item.Id == id);
        }

        public async Task<IEnumerable<Vendor>> Find(string name)
        {
            return await this.db.Vendors.Where(item => item.Name.Contains(name)).ToListAsync();
        }

        public Task Insert(Vendor item)
        {
            this.db.Vendors.Add(item);
            return db.SaveChangesAsync();
        }

        public Task Update(Vendor item)
        {
            var entity = this.db.Entry(item);
            entity.State = EntityState.Modified;
            return this.db.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var vendor = await this.Find(id);
            if (vendor == null)
            {
                return;
            }
            else
            {
                this.db.Vendors.Remove(vendor);
                await this.db.SaveChangesAsync();
            }
        }
    }
}