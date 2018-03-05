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
        private AllContext db = new AllContext();

        [HttpGet]
        [Route("customers")]
        public async Task<dynamic> Get()
        {
            try
            {
                var customer = await db.Customer.ToListAsync();
                return customer;
            }
            catch (Exception ex)
            {
                return new
                {
                    status = "faile",
                    resut = ex.Message
                };
            }
        }


        [HttpPost]
        [Route("customers")]
        public async Task<dynamic> AddCustomer(Customer c)
        {
            try
            {
                db.Customer.Add(c);
                await db.SaveChangesAsync();
                return new
                {
                    status = "success",
                    message = "One customer Inserted."
                };

            }
            catch (Exception ex)
            {
                return new
                {
                    status = "faile",
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
                var customer = await db.Customer.Where(s => s.FirstName.Contains(a)).ToListAsync();
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
                    status = "faile",
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
                Customer customer = await db.Customer.FirstOrDefaultAsync(a => a.Id == id);
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
                    status = "faile",
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
                var customer = await db.Customer.FirstOrDefaultAsync(a => a.Id == id);
                db.Customer.Remove(customer);
                await db.SaveChangesAsync();

                return new
                {
                    status = "success",
                    message = "One Customer Deleted"

                };


            }
            catch (Exception ex)
            {
                return new
                {
                    status = "faile",
                    result = ex.Message

                };

            }
        }


        [HttpPut]
        [Route("customers/{id}")]
        public async Task<dynamic> EditCustomer(Customer customer)
        {
            try
            {
                db.Entry(customer).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return new
                {
                    status = "Success",
                    message = "One Customer updated."
                };

            }

            catch (Exception ex)
            {
                return new
                {
                    status = "faile",
                    result = ex.Message

                };

            }


        }

    }
}
