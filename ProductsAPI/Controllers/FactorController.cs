using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using System.Data.Entity;
using System.Data;
using System.Threading.Tasks;
using ProductsAPI.Models;
using System.Runtime.InteropServices;

namespace ProductsAPI.Controllers
{
    public class FactorController : ApiController
    {
        private AllContext db = new AllContext();

        [HttpGet]
        [Route("factors")]
        public async Task<dynamic> Getfactor()
        {
            try
            {
                var factors = await db.Factor.ToListAsync();
                return (factors);

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
        [Route("factors")]
        public async Task<dynamic> Addfactor(Factor p)
        {
            try
            {
                db.Factor.Add(p);
                await db.SaveChangesAsync();
                return new
                {
                    status = "Success",
                    message = "One factor Inserted."
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
        [Route("factors/{id}")]
        public async Task<dynamic> DetailFactor(int id)
        {
            try
            {
                var factor = await db.Factor.FirstOrDefaultAsync(a => a.Id == id);
                return new
                {
                    status = "success",
                    result = factor
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
        [Route("factors/search/{a}")]
        public async Task<dynamic> SearchFactor(string a)
        {
            try
            {
                var factor = await db.Factor.Where(s => s.Date.Contains(a)).ToListAsync();
                return new
                {
                    status = "success",
                    result = factor
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
        [Route("factors/{id}")]
        public async Task<dynamic> DeleteFactor(int id)
        {
            try
            {
                Factor factor = await db.Factor.FirstOrDefaultAsync(p => p.Id == id);
                db.Factor.Remove(factor);
                await db.SaveChangesAsync();
                return new
                {
                    status = "Success",
                    message = "One Factor Deleted."
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
        [Route("factors/{id}")]
        public async Task<dynamic> EdieFactor(Factor factor)
        {
            try
            {
                db.Entry(factor).State = EntityState.Modified;
                await db.SaveChangesAsync();

                return new
                {
                    status = "Success",
                    message = "One Factor updated."
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