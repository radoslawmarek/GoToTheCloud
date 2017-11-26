using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PIcodeFirst.GoToTheCloud.FrontEnd.Authorization;

namespace PIcodeFirst.GoToTheCloud.FrontEnd.Controllers
{
    public class HomeController : Controller
    {
        private readonly AuthorizationService _authorizationService;


        public HomeController(AuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        public IActionResult Index()
        {
            var isAdmin = _authorizationService.CheckIfUserIsAdministrator(User);

            return View();
        }
    }
}