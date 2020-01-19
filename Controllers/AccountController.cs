using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using agos_api.Models;
using agos_api.Models.Base;
using agos_api.Models.Users;
using agos_api.Models.Organizations;
using agos_api.Models.UsersOrg;
using agos_api.Helpers;

namespace agos_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly AppDbContext _dbContext;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            AppDbContext dbcontext
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _dbContext = dbcontext;
        }

        [HttpPost]
        [Route("registeruserorg")]
        public async Task<IActionResult> RegisterUserOrg(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                    if (AccountHelper.IsValidPassword(model.Password)){
                        var checkUserName = await _dbContext.Users.FirstOrDefaultAsync(x => x.UserName == model.Login);
                    var checkEmail = await _dbContext.Users.FirstOrDefaultAsync(x => x.Email == model.Email);

                    if ((checkEmail == null) && (checkUserName == null)){
                        ApplicationUser user = new ApplicationUser { 
                            Email = model.Email,
                            UserName = model.Login,
                            Name = model.Name,
                            Surname = model.Surname,
                            Middlename = model.Middlename,
                            };
                        try{
                            var result = await _userManager.CreateAsync(user, model.Password);
                            var role = await _roleManager.FindByNameAsync(model.RoleName);
                            if (role == null)
                            {
                                return BadRequest();
                            }

                            var OrganizationUser = new UserOrganization(user);
                            _dbContext.UserOrganizations.Add(OrganizationUser);

                            await _dbContext.SaveChangesAsync();
                            return Ok(user);
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine(ex);
                            return BadRequest(model);
                        }
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
                else
                {
                    return BadRequest("Пользователь с такой почтой или логином уже есть.");
                }
            }
            else
            {
                return BadRequest(model);
            }
        }

        // [HttpPost]
        // [Route("registerdevuser")]
        // public async Task<IActionResult> RegisterDevUser(RegisterViewModel model)
        // {

        // }
    }
}