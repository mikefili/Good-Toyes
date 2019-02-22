using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoodToyes.Controllers
{
    /// <summary>
    /// only accessible for spayed or neutered
    /// </summary>
    [Authorize(Policy = "spayOrNeuter")]
    public class PolicyController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}
