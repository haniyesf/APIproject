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
        private AllContext db = new AllContext();


        [HttpGet]
        [Route("vendors")]
        public async Task<dynamic> GetVendor()
        {
            try
            {
                var vendor = await db.Vendor.ToListAsync();
                return (vendor);

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
        [Route("vendors")]
        public async Task<dynamic> AddVendor(Vendor v)
        {
            try
            {
                db.Vendor.Add(v);
                await db.SaveChangesAsync();
                return new
                {
                    status = "Success",
                    message = "One Vendor Inserted."
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
        [Route("Vendors/{ID}")]
        public async Task<dynamic> DeletVendor(int id)
        {
            try
            {
                Vendor vendor = await db.Vendor.FirstOrDefaultAsync(p => p.Id == id);
                db.Vendor.Remove(vendor);
                await db.SaveChangesAsync();
                return new
                {
                    status = "Success",
                    message = "One Vendor Deleted."
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
        [Route("vendors/{id}")]
        public async Task<dynamic> EditVendor(Vendor vendor)
        {
            try
            {
                db.Entry(vendor).State = EntityState.Modified;
                await db.SaveChangesAsync();

                return new
                {
                    status = "Success",
                    message = "One Vendor updated."
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
        [Route("vendor/search/{d}")]
        public async Task<dynamic> SearchVendor(string d)
        {
            try
            {
                var vendor = await db.Vendor.Where(s => s.Name.Contains(d)).ToListAsync();
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
                    status = "fail",
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
                Vendor vendor = await db.Vendor.FirstOrDefaultAsync(p => p.Id == id);
               
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
                    status = "fail",
                    result = ex.Message
                };
            }

        }

    }
}
