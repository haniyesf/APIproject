using ProductsAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ProductsAPI.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private AllContext db;

        public ProductRepository()
        {
            db = new AllContext();
        }

        public async Task<IEnumerable<ProductDetail>> GetAll()
        {
            return await this.db.ProductDetails.ToListAsync();
        }

        public async Task<ProductDetail> Find(int id)
        {
            return await this.db.ProductDetails.SingleOrDefaultAsync(item => item.ID == id);
        }

        public async Task<IEnumerable<ProductDetail>> Find(string name)
        {
            return await this.db.ProductDetails.Where(item => item.Name.Contains(name)).ToListAsync();
        }

        public Task Insert(ProductDetail item)
        {
            this.db.ProductDetails.Add(item);
            return db.SaveChangesAsync();
        }

        public Task Update(ProductDetail item)
        {
            var entity = this.db.Entry(item);
            entity.State = EntityState.Modified;
            return this.db.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var ProductDetail = await this.Find(id);
            if (ProductDetail == null)
            {
                return;
            }
            else
            {
                this.db.ProductDetails.Remove(ProductDetail);
                await this.db.SaveChangesAsync();
            }
        }
    }
}