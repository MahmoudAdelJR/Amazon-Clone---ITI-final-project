using Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models.AuthenticationClasses;
using Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using WebApplication7.BL.Helper;
using ViewModel;


namespace WebApplication7.Controllers
{
    
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly ILogger<AccountController> logger;
        IModelRepo<Admins> ModelRepository;
        IUnitofWork unitofWork;

        public AccountController(UserManager<IdentityUser> userManager , RoleManager<IdentityRole> _roleManager, SignInManager<IdentityUser> signInManager , ILogger<AccountController> logger, IUnitofWork _unitofWork)
        {
            this.userManager = userManager;
            this.roleManager = _roleManager;
            this.signInManager = signInManager;
            this.logger = logger;
            unitofWork = _unitofWork;
            ModelRepository = unitofWork.GetAdminRepo();
        }
        [Authorize(Roles = UserRoles.Admin)]
        public IActionResult Registration()
        {
            return View();
        }
        [Authorize(Roles = UserRoles.Admin)]
        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationVM model)
        {
            if (ModelState.IsValid)
            {

                var user = new IdentityUser()
                {
                    UserName = model.Email ,
                    Email = model.Email
                };

                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                        await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                    if (await roleManager.RoleExistsAsync(UserRoles.Admin))
                    {
                        await userManager.AddToRoleAsync(user, UserRoles.Admin);
                    }
                    try
                    {
                        ModelRepository.Create(new Admins
                        {
                            profileID = user.Id,
                            Name = model.Email,
                            Email = model.Email,
                        });
                        unitofWork.Save();
                    }
                    catch(Exception e)
                    {
                        await userManager.DeleteAsync(user);
                        ModelState.AddModelError("", e.Message);
                        return View(model);
                    }
                    return RedirectToAction("Login");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }


            }

            return View(model);
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new IdentityUser
            {
                UserName = model.Email,
                Email = model.Email
            };

            var result = await userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                AddErrorsToModelState(result.Errors);
                return View(model);
            }

            if (!await EnsureAdminRoleExists())
            {
                await userManager.DeleteAsync(user);
                ModelState.AddModelError("", "Failed to create admin role.");
                return View(model);
            }

            if (!await AssignUserToAdminRole(user))
            {
                await userManager.DeleteAsync(user);
                ModelState.AddModelError("", "Failed to assign user to admin role.");
                return View(model);
            }

            if (!await CreateAdminProfile(user, model))
            {
                await userManager.DeleteAsync(user);
                return View(model);
            }

            return RedirectToAction("Login");
        }

        private async Task<bool> EnsureAdminRoleExists()
        {
            if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
            {
                var roleResult = await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                return roleResult.Succeeded;
            }
            return true;
        }

        private async Task<bool> AssignUserToAdminRole(IdentityUser user)
        {
            if (await roleManager.RoleExistsAsync(UserRoles.Admin))
            {
                var roleResult = await userManager.AddToRoleAsync(user, UserRoles.Admin);
                return roleResult.Succeeded;
            }
            return false;
        }

        private async Task<bool> CreateAdminProfile(IdentityUser user, RegistrationVM model)
        {
            try
            {
                ModelRepository.Create(new Admins
                {
                    profileID = user.Id,
                    Name = model.Email,
                    Email = model.Email,
                });
                unitofWork.Save();
                return true;
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return false;
            }
        }

        private void AddErrorsToModelState(IEnumerable<IdentityError> errors)
        {
            foreach (var error in errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if (ModelState.IsValid)
            {
              var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RemomberMe, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid UserName Or Password Attempt");

                }
            
            
            }
            
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();

            return RedirectToAction("Login");
        }


        public IActionResult ForgetPassword()
        {
            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> ForgetPassword(ForgetPasswordVM model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var user = await userManager.FindByEmailAsync(model.Email);

        //        if (user != null)
        //        {
        //            var token = await userManager.GeneratePasswordResetTokenAsync(user);

        //            var passwordResetLink = Url.Action("ResetPassword", "Account", new { Email = model.Email, Token = token }, Request.Scheme);

        //            MailHelper.sendMail("Password Reset Link", passwordResetLink);

        //            logger.Log(LogLevel.Warning, passwordResetLink);

        //            return RedirectToAction("ConfirmForgetPassword");
        //        }

        //        return RedirectToAction("ConfirmForgetPassword");

        //    }

        //    return View(model);
        //}



        public IActionResult ConfirmForgetPassword()
        {
            return View();
        }

        public IActionResult ResetPassword(string Email , string Token)
        {
            if(Email == null || Token == null)
            {
                ModelState.AddModelError("", "Invalid Data");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordVM model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.Email);

                if (user != null)
                {
                    var result = await userManager.ResetPasswordAsync(user, model.Token, model.Password);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("ConfirmResetPassword");
                    }

                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }

                    return View(model);
                }

                return RedirectToAction("ConfirmResetPassword");
            }

            return View(model);
        }


        public IActionResult ConfirmResetPassword()
        {
            return View();
        }




    }
}
