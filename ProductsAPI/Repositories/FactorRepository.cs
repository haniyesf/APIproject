using ProductsAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ProductsAPI.Repositories
{
    public class FactorRepository : IFactorRepository
    {
        private Models.AllContext db;
        public FactorRepository()
        {
            db = new Models.AllContext();
        }


        public async Task<IEnumerable<Factor>> GetAll()
        {
            return await db.Factors.ToListAsync();
        }

        public async Task<Factor> Find(int id)
        {
            return await this.db.Factors.SingleOrDefaultAsync(item =>item.Id ==id);
        }

        public async Task<IEnumerable<Factor>> Find(string date)
        {
            return await db.Factors.Where(item => item.Date.Contains(date)).ToListAsync();
        }

        public Task Update(Factor item)
        {
            var entity = db.Entry(item);
            entity.State = EntityState.Modified;

            return db.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var factor = await Find(id);
            if (factor == null)
            {
                return;
            }
            else
            {
                db.Factors.Remove(factor);
                await db.SaveChangesAsync();
            }
        }

        public Task Insert(Factor item)
        {
           db.Factors.Add(item);
            return db.SaveChangesAsync();
        }
    }
}