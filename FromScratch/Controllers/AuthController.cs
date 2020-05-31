using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FromScratch.Models.Repositories;
using FromScratch.ViewModels;
using FromScratch.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

namespace FromScratch.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUserRepository _userRepository;
        //private readonly SignInManager<IdentityUser> _signInManager;

        public AuthController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        // sanam axali gverdi gveqneba manamde sacdelad gadamisamarteba
        // Login-is mere moxdeba aq!
        public string TempPlace() 
        {

            return "Success!"; 
        }

        [HttpPost]
        public IActionResult Index(AutorisationVM newUser) 
        {
            if (ModelState.IsValid) 
            {
                if(newUser.Login != null)
                {
                    if (_userRepository.ExistUsername(newUser.Login.UserName))
                    {
                        var userPass = _userRepository.PasswordVerification(newUser.Login.UserName, newUser.Login.Password);

                        if (userPass)
                        {
                            return RedirectToAction("TempPlace");
                        }
                        else
                        {
                            ModelState.AddModelError("", "Invalid Password entered!");
                            return View(newUser);
                        }
                    }

                    ModelState.AddModelError("", "Invalid Username!");
                    return View(newUser);
                }
                else
                {
                    if (_userRepository.ExistUsername(newUser.Signup.UserName))
                    {
                        ModelState.AddModelError("Signup.UserName", "This Username Alredy Exists!");
                        return View(newUser);
                    }

                    if (_userRepository.ExistEmail(newUser.Signup.Email))
                    {
                        ModelState.AddModelError("Signup.Email", "This Email Alredy Exists!");
                        return View(newUser);
                    }

                    User user = new User
                    {
                        UserName = newUser.Signup.UserName,
                        Email = newUser.Signup.Email,
                        Password = newUser.Signup.Password,
                        CreateDate = DateTime.Today,
                        Rating = 0,
                        UserTypeKey = 1
                    };

                    _userRepository.AddUser(user);
                    return View();
                }
            }

            return View();
        }

    }
}