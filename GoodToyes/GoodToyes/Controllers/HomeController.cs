using GoodToyes.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace GoodToyes.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProduct _context;

        public HomeController(IProduct context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
