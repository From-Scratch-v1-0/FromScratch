using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FromScratch.Controllers
{
    public class CatalogController : Controller
    {
        public IActionResult CatalogPage()
        {
            return View();
        }
    }
}