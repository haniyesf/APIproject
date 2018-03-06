using ProductsAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ProductsAPI.Repositories
{
    public class RegionRepository
    {
        private Models.AllContext db;

        public RegionRepository()
        {
            db = new Models.AllContext();
        }

        public async Task<IEnumerable<Region>> GetAll()
        {
            return await this.db.Regions.ToListAsync();
        }

        public async Task<Region> Find(int id)
        {
            return await this.db.Regions.SingleOrDefaultAsync(item => item.Id == id);
        }

        public async Task<IEnumerable<Region>> Find(string name)
        {
            return await this.db.Regions.Where(item => item.Name.Contains(name)).ToListAsync();
        }

        public Task Insert(Region item)
        {
            this.db.Regions.Add(item);
            return db.SaveChangesAsync();
        }

        public Task Update(Region item)
        {
            var entity = this.db.Entry(item);
            entity.State = EntityState.Modified;
            return this.db.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var Region = await this.Find(id);
            if (Region == null)
            {
                return;
            }
            else
            {
                this.db.Regions.Remove(Region);
                await this.db.SaveChangesAsync();
            }
        }

    }
}