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
using Services.Contracts;
using FS_BAL.Interfaces;

namespace FromScratch.Controllers
{
    public class AccountController : Controller
    {   
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly IAccountOperations operation;

        public AccountController(SignInManager<User> signInManager,UserManager<User> userManager,IAccountOperations operation)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            this.operation = operation;
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

                        Person person = new Person
                        {
                            UserKey = user.Id,
                            FullName = "John Doe",
                            PhoneNumber = "123456789",
                            Age = 0,
                            GenderKey = 1,
                            CountryKey = 1,
                            Address = "Unknown",
                            BirthDate = new DateTime(1753, 1, 1),
                            Proffesion = "Unknown",
                            Education = "Unknown",
                            AboutMe = "I Love Vodka..."
                        };

                        operation.createPerson(person);

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


        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Signup(SignUpVM newUser)
        {

            if (ModelState.IsValid) 
            {
                User user = new User
                {
                    UserName = newUser.UserName,
                    Email = newUser.Email,
                    PasswordHash = newUser.Password
                };


                var result = await _userManager.CreateAsync(user, user.PasswordHash);
                if (result.Succeeded) 
                {
                    Person person = new Person
                    {
                        UserKey = user.Id,
                        FullName = "John Doe",
                        PhoneNumber = "123456789",
                        Age = 0,
                        GenderKey = 1,
                        CountryKey = 1,
                        Address = "Unknown",
                        BirthDate = new DateTime(1753, 1, 1),
                        Proffesion = "Unknown",
                        Education = "Unknown",
                        AboutMe = "I Love Vodka..."
                    };

                    operation.createPerson(person);

                    return RedirectToAction("Login");
                }
            }

            return View(newUser);
        }

        public async Task<IActionResult> Signout() 
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Login");
        }
    }
}