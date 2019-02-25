using GoodToyes.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoodToyes.Controllers
{
    public class ShopController : Controller
    {
        private readonly IProduct _context;

        public ShopController(IProduct context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult>Details(int id)
        {
            var product = await _context.GetProduct(id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }
    }
}
