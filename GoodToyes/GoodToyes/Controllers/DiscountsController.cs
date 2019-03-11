using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoodToyes.Controllers
{
    public class DiscountsController : Controller
    {
        /// <summary>
        /// Returns discounts index view
        /// </summary>
        /// <returns>Discounts index view</returns>
        public IActionResult Index()
        {
            return View();
        }
    }
}
