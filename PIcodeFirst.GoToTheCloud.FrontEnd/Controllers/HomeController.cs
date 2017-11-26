using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PIcodeFirst.GoToTheCloud.FrontEnd.Authorization;
using PICodeFirst.GoToTheCloud.App.TravelModel;

namespace PIcodeFirst.GoToTheCloud.FrontEnd.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITravelRepository _travelRepository;

        public HomeController(ITravelRepository travelRepository)
        {
            _travelRepository = travelRepository;
        }

        public IActionResult Index()
        {
            var travelList = _travelRepository.GetTravelList(User.CreateUser());

            return View(travelList);
        }
    }
}