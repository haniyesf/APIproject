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
        protected Repositories.FactorRepository Repository { get; private set; }

        public FactorController()
        {
            Repository = new Repositories.FactorRepository();
        }


        [HttpGet]
        [Route("factors")]
        public async Task<dynamic> Getfactor()
        {
            try
            {
                var factors = await this.Repository.GetAll();
                return new
                {
                    status = "success",
                    result = factors
                };
            }
            catch (Exception ex)
            {
                return new
                {
                    status = "failed",
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
                await this.Repository.Insert(p);
                return new
                {
                    status = "Success",
                    result = "One Vendor Inserted."
                };
            }
            catch (Exception ex)
            {
                return new
                {
                    status = "failed",
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
                var factor = await this.Repository.Find(id);
                return new
                {
                    status = "Success",
                    result = factor
                };
            }
            catch (Exception ex)
            {
                return new
                {
                    status = "failed",
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
                var factor = await this.Repository.Find(a);
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
                    status = "failed",
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
                await this.Repository.Delete(id);
                return new
                {
                    status = "Success",
                    message = "One factor Deleted."
                };
            }
            catch (Exception ex)
            {
                return new
                {
                    status = "failed",
                    result = ex.Message

                };
            }
        }

        [HttpPut]
        [Route("factors/{id}")]
        public async Task<dynamic> EdieFactor(Factor factor, int id)
        {
            try
            {
                var origin = await this.Repository.Find(id);
                if (origin != null)
                {
                    origin.Date = factor.Date ?? origin.Date;
                }
                await this.Repository.Update(origin);
                return new
                {
                    status = "Success",
                    result = "One factor updated."
                };
            }
            catch (Exception ex)
            {
                return new
                {
                    status = "failed",
                    result = ex.Message

                };

            }
        }
    }
}