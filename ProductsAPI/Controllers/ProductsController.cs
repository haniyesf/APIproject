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
    public class ProductsController : ApiController
    {
        private AllContext db = new AllContext();
        
        [HttpGet]
        [Route("products")]
        public async Task<dynamic> GetProducts()
        {
            try
            {
                var model = await db.ProductDetails.ToListAsync();
                return (model);

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
        [Route("products")]
        public async Task<dynamic> AddProduct(ProductDetail p)
        {
            try
            {
                db.ProductDetails.Add(p);
                await db.SaveChangesAsync();
                return new
                {
                    status = "Success",
                    message = "One Product Inserted."
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
        [Route("products/{ID}")]
        public async Task<dynamic> DeletProduct(int ID)
        {
            try
            {
                ProductDetail product = await db.ProductDetails.FirstOrDefaultAsync(p=>p.ID ==ID);
                db.ProductDetails.Remove(product);
                await db.SaveChangesAsync();
                return new
                {
                    status = "Success",
                    message = "One Product Deleted."
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
        [Route("products/{id}")]
        public async Task<dynamic> EditProducts(ProductDetail productdetails)
        {
            try
            {
                db.Entry(productdetails).State = EntityState.Modified;
                await db.SaveChangesAsync();

                return new
                {
                    status = "Success",
                    message = "One Product updated."
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
        [Route("products/search/{q}")]
        public async Task<dynamic> SearchProducts(string q)
        {
            try
            {
                var product = await db.ProductDetails.Where(s => s.Name.Contains(q)).ToListAsync();
                return new
                {
                    status = "success",
                    result = product
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
        [Route("products/{id}")]
        public async Task<dynamic> DetailProduct(int id)
        {
            try
            {
                ProductDetail productdetail = await db.ProductDetails.FirstOrDefaultAsync(p => p.ID == id);
                //throw new Exception("test");

                return new
                {
                    status = "Success",
                    result = productdetail
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
