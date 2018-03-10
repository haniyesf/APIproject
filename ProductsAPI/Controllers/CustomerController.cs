using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Data.Entity;
using System.Data;
using System.Threading.Tasks;
using ProductsAPI.Models;
using System.Runtime.InteropServices;
using System.Web.Http;

namespace ProductsAPI.Controllers
{
    public class CustomerController : ApiController
    {

        protected Repositories.ICustomerRepository Repo { get; private set; }

        public CustomerController(Repositories.ICustomerRepository repository)
        {
            this.Repo = repository;
        }


        public CustomerController()
        {
            this.Repo = new Repositories.CustomerRepository();
        }

        [HttpGet]
        [Route("customers")]
        public async Task<dynamic> Get()
        {
            try
            {
                var customer = await this.Repo.GetAll();
                return new
                {
                    status = "success",
                    result = customer
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
        [Route("customers")]
        public async Task<dynamic> AddCustomer(Customer c)
        {
            try
            {
                await this.Repo.Insert(c);
                return new
                {
                    status = "success",
                    result = "One customer Inserted."
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
        [Route("customers/search/{a}")]
        public async Task<dynamic> SearchCustomer(string a)
        {
            try
            {
                var result = await this.Repo.Find(a);
                return new
                {
                    status = "success",
                    result
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
        [Route("customers/{id}")]
        public async Task<dynamic> DetailCustomer(int id)
        {
            try
            {
                Customer customer = await this.Repo.Find(id);
                return new
                {
                    status = "success",
                    result = customer
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
        [Route("customers/{id}")]
        public async Task<dynamic> DeleteCustomer(int id)
        {
            try
            {
                await this.Repo.Delete(id);

                return new
                {
                    status = "success",
                    result = "One Customer Deleted"
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
        [Route("customers/{id}")]
        public async Task<dynamic> EditCustomer(Customer customer, int id)
        {
            try
            {
                var origin = await this.Repo.Find(id);
                if (origin != null)
                {
                    origin.FirstName = customer.FirstName ?? origin.FirstName;
                    origin.LastName = customer.LastName ?? origin.LastName;
                    origin.Tel = customer.Tel ?? origin.Tel;
                    origin.Age = customer.Age ?? origin.Age;
                }
                await this.Repo.Update(origin);
                return new
                {
                    status = "Success",
                    result = "One Customer updated."
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
