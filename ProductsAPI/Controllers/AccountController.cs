using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using ProductsAPI.Models;
using ProductsAPI.Repositories;

namespace ProductsAPI.Controllers
{
    public class AccountController : ApiController
    {
        protected AuthRepository Repository { get; private set; }

        public AccountController()
        {
            this.Repository = new AuthRepository();
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("Users/autoinsert")]
        public async Task<dynamic> AutoInsert()
        {
            try
            {
              await this.Repository.AutoInsertUser();
                return new
                {
                    status = "success",
                    result = "users Inserted!"
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


        [AllowAnonymous]
        [Route("Register")]
        [Authorize(Roles = "Administrator")]
        public async Task<IHttpActionResult> Register(UserModel userModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IdentityResult result = await Repository.RegisterUser(userModel);

            IHttpActionResult errorResult = GetErrorResult(result);

            if (errorResult != null)
            {
                return errorResult;
            }
           


            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Repository.Dispose();
            }

            base.Dispose(disposing);
        }

        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }


    }

}