using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace GoodToyes.Controllers
{
    public class Order : Controller
    {
        /// <summary>
        /// Sends last ten orders to View
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }
    }
}
