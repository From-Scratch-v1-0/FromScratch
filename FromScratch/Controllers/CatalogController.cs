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
        
        [HttpGet]
        public IActionResult CatalogPage(IEnumerable<ProjectProduct> prpr)
        {
            //ორივე შემთხვევისათვის გავტესტე და მუშაობს! ჯერჯერობით იყოს ასე და თუ რამეა ჩაასწორეთ არ მაქვს პრობლემა!//
            //დაახლოებით ასეთი რამე უნდა გაკეთდეს და თუ რამე შეცდომაა ან არ უნდა იყოს ისე, როგორც საჭიროა, მაშინ ჩაასწორეთ!//
            //ეს ჯერჯერობით იყოს დაკომენტარებული//
           /* if (prpr.Where(x=> x.ProjectKey>=1).Count()==0)
                return View("EmptyCatalog");*/
            return View(prpr);          
        }
        [HttpGet]
        public IActionResult Project(Project proj) 
        {
            return View(proj);
        }
 
    }
}