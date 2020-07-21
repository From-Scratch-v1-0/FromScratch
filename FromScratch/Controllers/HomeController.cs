using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FromScratch.Models;
using Microsoft.AspNetCore.Authorization;
using Services.Contracts;
using Microsoft.AspNetCore.Identity;
using FS_DAL.Entities;
using System.Security.Claims;
using FS_BAL.DTOs;
using FS_BAL.Interfaces;

namespace FromScratch.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserOperations _operations;
        private readonly UserManager<User> _userManager;

        public HomeController(ILogger<HomeController> logger,IUserOperations operations, UserManager<User> userManager)
        {
            _logger = logger;
            _operations = operations;
            _userManager = userManager;
        }
        // Home/Index (Test comment)
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            ViewBag.Mail = user.Email;

            var userInfo = _operations.GetUserInfoById(user.Id);
            ViewBag.BDay = userInfo.BirthDate;

            return View(userInfo);
        }

        [HttpPost]
        public async Task<IActionResult> UserInfo(UserInfoDTO model,string optName)
        {
            if (optName == "person")
            {
                var date = new DateTime();
                if (model.BirthDate == date)
                {
                    model.BirthDate = DateTime.Now;
                }


                _operations.updatePersonInfo(model);
                return RedirectToAction("Index");
            }
            else 
            {
                _operations.addNewSkill(model);
                return RedirectToAction("Index");
            }
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
