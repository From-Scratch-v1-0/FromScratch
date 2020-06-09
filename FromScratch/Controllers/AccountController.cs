using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FromScratch.Models.Repositories;
using FromScratch.ViewModels;
using FromScratch.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using FS_DAL.Entities;

namespace FromScratch.Controllers
{
    public class AccountController : Controller
    {
        
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public AccountController(SignInManager<User> signInManager,UserManager<User> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(AccountVM account,string returnUrl) 
        {
            if (ModelState.IsValid)
            {
                if (account.Login != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(account.Login.UserName,account.Login.Password,
                                                                          account.Login.RememberMe,false);
                    if (result.Succeeded)
                    {
                        if (!string.IsNullOrEmpty(returnUrl))
                        {
                            return Redirect(returnUrl);
                        }
                        else 
                        {
                            return RedirectToAction("index","home");
                        }
                    }
                    ModelState.AddModelError(string.Empty,"Ivalid Login atempt");
                }
                else
                {
                    User user = new User()
                    {
                        UserName = account.Signup.UserName,
                        Email = account.Signup.Email,
                        PasswordHash = account.Signup.Password
                    };

                    var result = await _userManager.CreateAsync(user, account.Signup.Password);
                    if (result.Succeeded)
                    {
                        return View();
                    }

                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty,error.Description);
                    }

                }
            }

            return View(account);
        }

    }
}