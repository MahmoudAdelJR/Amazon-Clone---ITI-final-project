using Admin.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Models;
using Models.AuthenticationClasses;
using Repos;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserSide.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        public IConfiguration configuration;
        IUnitofWork unitofWork;
        IModelRepo<Customer> ModelRepository;
        public AuthenticationController(UserManager<IdentityUser> _userManager, RoleManager<IdentityRole> _roleManager, IConfiguration _configuration, IUnitofWork _unitofWork)
        {
            this.userManager = _userManager;
            this.roleManager = _roleManager;
            this.configuration = _configuration;
            unitofWork = _unitofWork;
            ModelRepository = unitofWork.GetCustomerRepo();
        }


        // Adding Customer

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var userExist = await userManager.FindByNameAsync(model.UserName);
            if (userExist != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Massage = "User Alrady Exist" });
            var user = new IdentityUser()
            {
                //FirstName = model.FirstName,
                //LastName = model.LastName,
                //Address = model.Address,
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.UserName,
                PhoneNumber = model.PhoneNumber
            };
            var result = await userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Massage = "user Creation Failed" });
            }
            else
            {
                if (!await roleManager.RoleExistsAsync(UserRoles.Customer))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Customer));
                if (await roleManager.RoleExistsAsync(UserRoles.Customer))
                {
                    await userManager.AddToRoleAsync(user, UserRoles.Customer);
                }
                try
                {
                    ModelRepository.Create(new Customer()
                    {
                        profileID = user.Id,
                        //userManager.Users.LastOrDefault().Id,
                        Email = model.Email,
                        Name = model.FirstName,
                        PhoneNumber = model.PhoneNumber,
                        Gender = model.Gender,
                        City = model.City,
                        Street = model.Street,
                        PostalCode = model.PostalCode,
                    }) ;
                    unitofWork.Save();
                    return Ok(new Response { Status = "Success", Massage = "User Created Successfully" });
                }
                catch (Exception e)
                {
                    await userManager.DeleteAsync(user);
                    return BadRequest(new Response { Status = "Error", Massage = e.Message });
                }
            }
            
        }

        // Login
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await userManager.FindByNameAsync(model.UserName);
            if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await userManager.GetRolesAsync(user);
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,user.UserName),
                    new Claim("Id", user.Id.ToString()),
                    //new Claim("custID",user)
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                };
                foreach (var userrole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userrole));
                }
                var authSigninkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]));
                var token = new JwtSecurityToken(

                    issuer: configuration["JWT:ValidIssuer"],
                      audience: configuration["JWT:ValidAudience"],
                      expires: DateTime.Now.AddHours(5),
                      claims: authClaims,
                      signingCredentials: new SigningCredentials(authSigninkey, SecurityAlgorithms.HmacSha256)
                      );
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                });
            }
            return Unauthorized();
        }


        // Register as Admin


        [HttpPost]
        [Route("RegisterAdmin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterModel model)
        {
            var userExist = await userManager.FindByNameAsync(model.UserName);
            if (userExist != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Massage = "User Alrady Exist" });
            var user = new IdentityUser()
            {
                
                //FirstName = model.FirstName,
                //LastName = model.LastName,
                //Address = model.Address,
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.UserName
            };
            var result = await userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Massage = "user Creation Failed" });
            }
            if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));

            if (!await roleManager.RoleExistsAsync(UserRoles.Customer))
                await roleManager.CreateAsync(new IdentityRole(UserRoles.Customer));

            if (await roleManager.RoleExistsAsync(UserRoles.Admin))
            {
                await userManager.AddToRoleAsync(user, UserRoles.Admin);
            }
            return Ok(new Response { Status = "Success", Massage = "User Create Scuceful" });
        }

    }
}

