using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoodToyes.Controllers
{
    public class DiscountsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
