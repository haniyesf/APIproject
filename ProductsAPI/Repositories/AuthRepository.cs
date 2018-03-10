using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using ProductsAPI.Models;

namespace ProductsAPI.Repositories
{
    public class AuthRepository: IDisposable
    {

        private IdentityContext _ctx;
        private UserManager<IdentityUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;

        public AuthRepository()
        {
            _ctx = new IdentityContext();
            _userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(_ctx));
            _roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(_ctx)); ;
        }



        public async Task AutoInsertUser()
        {

            if (!_roleManager.RoleExists("Administrator"))
            {
                var role = new IdentityRole();
                role.Name = "Administrator";
                await _roleManager.CreateAsync(role);

            }

            if (!_roleManager.RoleExists("User"))
            {
                var role1 = new IdentityRole();
                role1.Name = "User";
                await _roleManager.CreateAsync(role1);

            }
            if (!_roleManager.RoleExists("role2"))
            {
                var role2 = new IdentityRole();
                role2.Name = "role2";
                await _roleManager.CreateAsync(role2);

            }

            if (await _userManager.FindByEmailAsync("safarii@gmail.com") == null)
            {
                var user1 = new IdentityUser { UserName = "safarii@gmail.com", Email = "safarii@gmail.com" };
                var result = await _userManager.CreateAsync(user1, "Hani@12345");
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user1.Id, "Administrator");
                }
            }

            if (await _userManager.FindByEmailAsync("haniye@gmail.com") == null)
            {
                var user1 = new IdentityUser { UserName = "haniye@gmail.com", Email = "haniye@gmail.com" };
                var result = await _userManager.CreateAsync(user1, "Hani@12345");
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user1.Id, "User");
                }
            }




            if (await _userManager.FindByEmailAsync("eli@gmail.com") == null)
            {
                var user1 = new IdentityUser { UserName = "eli@gmail.com", Email = "eli@gmail.com" };
                var result = await _userManager.CreateAsync(user1, "Hani@12345");
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user1.Id, "role2");
                }
            }

        }


        public async Task<IdentityUser> FindUser(string userName, string password)
        {
            IdentityUser user = await _userManager.FindAsync(userName, password);

            return user;
        }


        public async Task<IdentityResult> RegisterUser(UserModel userModel)
        {
            IdentityUser user = new IdentityUser
            {
                UserName = userModel.UserName
            };

            var result = await _userManager.CreateAsync(user, userModel.Password);
            //if (result.Succeeded)
            //{
            //    await _userManager.AddToRoleAsync(user.Id, "User");
            //}
            return result;
        }

        public void Dispose()
        {
            _ctx.Dispose();
            _userManager.Dispose();
            _roleManager.Dispose();

        }

        
    }
}