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
using FS_BAL.Interfaces;
using X.PagedList;

namespace FromScratch.Controllers
{
    [Authorize]
    public class CatalogController : Controller
    {
        private readonly ICatalogOperations _operation;
        private readonly UserManager<User> _userManager;

        public CatalogController(ICatalogOperations operation,UserManager<User> userManager)
        {
            _operation = operation;
            _userManager = userManager;
        }


        [AllowAnonymous]
        public IActionResult CatalogPage(string? sphereName,string search, int? page)
        {

            var pageNumber = page ?? 1;

            if (sphereName == "Front-End")
            {
                if (search == null)
                    goto There;
                var result = _operation.Search(search);
                var pagee = result.ToPagedList(pageNumber, 6);
                return View(pagee);
            }
            

        There:
            var data = _operation.GetAllProjects();
            var onePage = data.ToPagedList(pageNumber, 6);
            return View(onePage);







        }

     
        public IActionResult Project()
        {

            return View();
        }

    }
}