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
        public string TempPlace(LogInVM user) 
        {
            return user.UserName.ToString(); 
        }

        [HttpPost]
        public IActionResult LogIn(LogInVM currentUser) 
        {
            if (_userRepository.ExistUsername(currentUser.UserName)) 
            {
                var userPass = _userRepository.PasswordVerification(currentUser.UserName,currentUser.Password);

                if (userPass)
                    return RedirectToAction("TempPlace",currentUser);

            }

            ModelState.AddModelError("", "Invalid login attempt");
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult SignUp(SignUpVM newUser) 
        {
            if (ModelState.IsValid) 
            {
                if (_userRepository.ExistUsername(newUser.UserName)) 
                {
                    ModelState.AddModelError("", "This Username Alredy Exist");
                    return RedirectToAction("Index",newUser);
                }

                if (_userRepository.ExistUsername(newUser.Email))
                {
                    ModelState.AddModelError("", "This Eamail Alredy Exist");
                    return RedirectToAction("Index", newUser);
                }

                User user = new User
                {
                    UserName = newUser.UserName,
                    Email = newUser.Email,
                    Password = newUser.Password,
                    CreateDate = DateTime.Today,
                    Rating = 0,
                    UserTypeKey = 1
                };

                _userRepository.AddUser(user);
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

    }
}