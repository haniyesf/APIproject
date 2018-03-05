using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Data.Entity;
using System.Data;
using System.Threading.Tasks;
using ProductsAPI.Models;
using System.Web.Http;
using System.Runtime.InteropServices;

namespace ProductsAPI.Controllers
{
    public class RegionController : ApiController
    {
        private AllContext db = new AllContext();

        [HttpGet]
        [Route("regions")]
        public async Task<dynamic> GetRegion()
        {
            try
            {
                var Region = await db.Regions.ToListAsync();
                return (Region);

            }
            catch (Exception ex)
            {
                return new
                {
                    status = "fail",
                    result = ex.Message
                };
            }
        }

        [HttpPost]
        [Route("regions")]
        public async Task<dynamic> AddRegion(Region p)
        {
            try
            {
                db.Regions.Add(p);
                await db.SaveChangesAsync();
                return new
                {
                    status = "Success",
                    message = "One Region Inserted."
                };
            }
            catch (Exception ex)
            {
                return new
                {
                    status = "fail",
                    result = ex.Message
                };
            }
        }

        [HttpDelete]
        [Route("regions/{ID}")]
        public async Task<dynamic> DeletRegion(int ID)
        {
            try
            {
                Region Region = await db.Regions.FirstOrDefaultAsync(p => p.Id == ID);
                db.Regions.Remove(Region);
                await db.SaveChangesAsync();
                return new
                {
                    status = "Success",
                    message = "One Region Deleted."
                };
            }
            catch (Exception ex)
            {
                return new
                {
                    status = "fail",
                    result = ex.Message

                };
            }
        }

        [HttpPut]
        [Route("regions/{id}")]
        public async Task<dynamic> EditRegion(Region Region)
        {
            try
            {
                db.Entry(Region).State = EntityState.Modified;
                await db.SaveChangesAsync();

                return new
                {
                    status = "Success",
                    message = "One Region updated."
                };
            }
            catch (Exception ex)
            {
                return new
                {
                    status = "fail",
                    result = ex.Message

                };

            }
        }



        [HttpGet]
        [Route("regions/search/{q}")]
        public async Task<dynamic> SearchRegion(string q)
        {
            try
            {
                var Region = await db.Regions.Where(s => s.Name.Contains(q)).ToListAsync();
                return new
                {
                    status = "success",
                    result = Region
                };
            }
            catch (Exception ex)
            {
                return new
                {
                    status = "fail",
                    result = ex.Message

                };

            }
        }
        [HttpGet]
        [Route("regions/{id}")]
        public async Task<dynamic> DetailRegion(int id)
        {
            try
            {
                Region Region = await db.Regions.FirstOrDefaultAsync(p => p.Id == id);
               

                return new
                {
                    status = "Success",
                    result = Region
                };
            }
            catch (Exception ex)
            {
                return new
                {
                    status = "fail",
                    result = ex.Message
                };
            }

        }




    }
}
