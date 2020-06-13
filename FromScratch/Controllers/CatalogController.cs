using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using FromScratch.Models.Repositories;
using FS_DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Services.Repositories;
using System.Security.Cryptography.X509Certificates;

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
        public ViewResult CatalogPage() => View(_service.ProjectProduct.GetAll());

        public ViewResult Project() => View(_service.Project.GetAll());
        
        /*[HttpPost]
         public IActionResult CatalogPage()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Project() 
        {
            
            return View();
        }*/
 
    }
}