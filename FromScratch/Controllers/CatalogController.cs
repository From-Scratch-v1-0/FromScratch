using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FS_DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace FromScratch.Controllers
{
    [Authorize]
    public class CatalogController : Controller
    {
        private readonly IUOW _service;
        private readonly UserManager<User> _userManager;

        public CatalogController(IUOW service,UserManager<User> userManager)
        {
            _service = service;
            _userManager = userManager;
        }

        [AllowAnonymous]
        public IActionResult CatalogPage()
        {
            return View();
        }

        public IActionResult Project() 
        {
            return View();
        }

    }
}