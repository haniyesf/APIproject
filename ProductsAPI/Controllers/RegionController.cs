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
        protected Repositories.IRegionRepository Repository { get; private set; }

        public RegionController(Repositories.IRegionRepository repository)
        {
            this.Repository = repository;
        }

        public RegionController()
        {
            this.Repository = new Repositories.RegionRepository();
        }

        [HttpGet]
        [Route("regions")]
        public async Task<dynamic> GetRegion()
        {
            try
            {
                var Region = await this.Repository.GetAll();
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
                    status = "failed",
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
                await this.Repository.Insert(p);
                return new
                {
                    status = "Success",
                    result = "One Region Inserted."
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
        [Route("regions/{ID}")]
        public async Task<dynamic> DeletRegion(int ID)
        {
            try
            {
                await this.Repository.Delete(ID);
                return new
                {
                    status = "Success",
                    result = "One Region Deleted."
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
        [Route("regions/{id}")]
        public async Task<dynamic> EditRegion(Region Region ,int id)
        {

            try
            {
                var origin = await this.Repository.Find(id);
                if (origin != null)
                {
                    origin.Name = Region.Name ?? origin.Name;
                }
                await this.Repository.Update(origin);
                return new
                {
                    status = "Success",
                    result = "One Region updated."
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
        [Route("regions/search/{q}")]
        public async Task<dynamic> SearchRegion(string q)
        {
            try
            {
                var region = await this.Repository.Find(q);
                return new
                {
                    status = "success",
                    result = region
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
        [Route("regions/{id}")]
        public async Task<dynamic> DetailRegion(int id)
        {
            try
            {
                var region = await this.Repository.Find(id);
                return new
                {
                    status = "Success",
                    result = region
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
