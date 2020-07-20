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

namespace FromScratch.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUOW _service;
        private readonly UserManager<User> _userManager;

        public HomeController(ILogger<HomeController> logger,IUOW service, UserManager<User> userManager)
        {
            _logger = logger;
            _service = service;
            _userManager = userManager;
        }
        // Home/Index (Test comment)
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            ViewBag.Mail = user.Email;



            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UserInfo(UserInfoDTO model)
        {

            return View();
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
