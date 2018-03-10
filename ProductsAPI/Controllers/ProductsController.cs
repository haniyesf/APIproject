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
using System.Web.Http.Filters;
using System.Threading;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

namespace ProductsAPI.Controllers
{
    public class ProductsController : ApiController
    {
        protected Repositories.IProductRepository Repository { get; private set; }

        public ProductsController(Repositories.IProductRepository repository)
        {
            this.Repository = repository;
        }


        public ProductsController()
        {
            this.Repository = new Repositories.ProductRepository();
        }




        [HttpGet]
        [Authorize]
        [Route("products")]
        public async Task<dynamic> GetProducts()
        {
            try
            {
                var userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(new IdentityContext()));
                var role = User.IsInRole("Administrator");
                var user = await userManager.FindByNameAsync(User.Identity.Name);
                var roles = (await userManager.GetRolesAsync(user.Id)).ToArray();

                var Product = await this.Repository.GetAll();
                return new
                {
                    status = "success",
                    result = roles,
                    userName = User.Identity.Name
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
        [Route("products")]
        public async Task<dynamic> AddProduct(ProductDetail a)
        {
            try
            {
                await this.Repository.Insert(a);
                return new
                {
                    status = "Success",
                    result = "One Product Inserted."
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
        [Route("products/{ID}")]
        public async Task<dynamic> DeletProduct(int ID)
        {
            try
            {
                await this.Repository.Delete(ID);
                return new
                {
                    status = "Success",
                    result = "One Product Deleted."
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
        [Route("products/{id}")]
        public async Task<dynamic> EditProducts(ProductDetail productdetails, int id)
        {
            try
            {
                var origin = await this.Repository.Find(id);
                if (origin != null)
                {
                    origin.Name = productdetails.Name ?? origin.Name;
                    origin.Address = productdetails.Address ?? origin.Address;
                    origin.type = productdetails.type ?? origin.type;
                    origin.price = productdetails.price ?? origin.price;
                }
                await this.Repository.Update(origin);
                return new
                {
                    status = "Success",
                    result = "One productd updated."
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
        [Route("products/search/{q}")]
        public async Task<dynamic> SearchProducts(string q)
        {
            try
            {
                var Product = await this.Repository.Find(q);
                return new
                {
                    status = "success",
                    result = Product
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
        [Route("products/{id}")]
        public async Task<dynamic> DetailProduct(int id)
        {
            try
            {
                var Product = await this.Repository.Find(id);
                return new
                {
                    status = "Success",
                    result = Product
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
