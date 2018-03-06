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
using System.Runtime.InteropServices;
using System.Web.Http;

namespace ProductsAPI.Controllers
{
    public class VendorController : ApiController
    {
        protected Repositories.VendorRepository Repository { get; private set; }


        public VendorController()
        {
            this.Repository = new Repositories.VendorRepository();
        }


        [HttpGet]
        [Route("vendors")]
        public async Task<dynamic> GetVendor()
        {
            try
            {
                var vendor = await this.Repository.GetAll();
                return new
                {
                    status = "success",
                    result = vendor
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
        [Route("vendors")]
        public async Task<dynamic> AddVendor(Vendor v)
        {
            try
            {
               await this.Repository.Insert(v);
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

        [HttpDelete]
        [Route("Vendors/{ID}")]
        public async Task<dynamic> DeletVendor(int id)
        {
            try
            {
               await this.Repository.Delete(id);
                return new
                {
                    status = "Success",
                    result = "One Vendor Deleted."
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
        [Route("vendors/{id}")]
        public async Task<dynamic> EditVendor(Vendor vendor,int id)
        {
            try
            {
                var origin = await this.Repository.Find(id);
                if (origin != null)
                {
                    origin.Name = vendor.Name ?? origin.Name;
                    origin.Address = vendor.Address ?? origin.Address;
                    origin.Tel = vendor.Tel ?? origin.Tel;
                }
                await this.Repository.Update(origin);
                return new
                {
                    status = "Success",
                    result = "One vendor updated."
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
        [Route("vendor/search/{d}")]
        public async Task<dynamic> SearchVendor(string d)
        {
            try
            {
               var vendor= await this.Repository.Find(d);
                return new
                {
                    status = "success",
                    result = vendor
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
        [Route("vendor/detail/{id}")]
        public async Task<dynamic> DetailVendor(int id)
        {
            try
            {
                var vendor = await this.Repository.Find(id);
                return new
                {
                    status = "Success",
                    result = vendor
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
