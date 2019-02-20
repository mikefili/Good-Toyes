using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoodToyes.Controllers
{
    public class AccountController : Controller
    {
        /// <summary>
        /// User register Page
        /// </summary>
        /// <returns>View</returns>
        [HttpGet]
        public IActionResult Register() => View();
        
        [HttpPost]
        public IActionResult Register()
        {

        }
        
    }
}
