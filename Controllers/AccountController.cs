using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using agos_api.Models;
using agos_api.Models.Base;
using agos_api.Models.Users;
using agos_api.Models.Organizations;
using agos_api.Models.Organizations.PersonOrg;
using agos_api.Helpers;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using System.Text;

namespace agos_api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _config;
        private readonly AppDbContext _dbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAccountHelper _accountHelper;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            IConfiguration config,
            AppDbContext dbcontext,
            IHttpContextAccessor httpContextAccessor,
            IAccountHelper accountHelper
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _config = config;
            _dbContext = dbcontext;
            _httpContextAccessor = httpContextAccessor;
            _accountHelper = accountHelper;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody]LogInViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Email != null)
                {
                    var user = await _userManager.FindByNameAsync(model.Email);
                    if (user != null)
                    {
                        // if (!await _userManager.IsEmailConfirmedAsync(user))
                        // {
                        //     ModelState.AddModelError(string.Empty, "Вы не подтвердили свой email");
                        //     return NotFound("Вы не подтвердили свой email");
                        // }
                    }
                    else
                    {
                        return BadRequest("Пользователь с таким логином не найден.");
                    }
                    
                    var role = await _userManager.GetRolesAsync(user);
                    var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
                    if (result.Succeeded)
                    {
                        var token = _accountHelper.GenerateJwtToken(user.UserName, role);

                        return Ok(new
                            {
                                user.UserName,
                                user.FullName,
                                role,
                                token
                            });
                    }
                    else
                    {
                        return BadRequest("E-mail или пароль введены не верно");
                    }
                }
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }

            return BadRequest(model);
        }
        
       

        // [Authorize]
        [HttpGet]
        [Route("logout")]
        public async Task<IActionResult> LogOut()
        {
            // удаляем аутентификационные куки
            await _signInManager.SignOutAsync();
            return Ok();
        }

        // [Authorize]
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterUserOrg([FromBody]RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (_accountHelper.IsValidPassword(model.Password)){
                        var checkEmail = await _dbContext.Users.FirstOrDefaultAsync(x => x.Email == model.Email);

                    if (checkEmail == null){
                        ApplicationUser user = new ApplicationUser { 
                            Email = model.Email,
                            UserName = model.Email,
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
                            await _userManager.AddToRoleAsync(user, model.RoleName);
                            var studyOrganization = await _dbContext.StudyOrganizations.FirstOrDefaultAsync(
                                x => x.StudyOrganizationId == model.studyOrganizationId);
                            if (studyOrganization != null)
                            {
                                var OrganizationUser = new UserOrganization(user, studyOrganization);
                                _dbContext.UserOrganizations.Add(OrganizationUser);
                            }
                            else
                            {
                                var devUser = new devUser(user);
                                _dbContext.devUsers.Add(devUser);
                            }

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
                         return BadRequest("Пользователь с такой почтой уже есть.");
                    }
                }
                else
                {
                   return BadRequest();
                }
            }
            else
            {
                return BadRequest(model);
            }
        }

        // [HttpPost]
        // [Route("registerdevuser")]
        // public async Task<IActionResult> RegisterDevUser([FromBody]RegisterViewModel model)
        // {

        // }
    }
}