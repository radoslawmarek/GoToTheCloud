using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PIcodeFirst.GoToTheCloud.FrontEnd.Authorization;
using PICodeFirst.GoToTheCloud.App.TravelModel;
using PIcodeFirst.GoToTheCloud.FrontEnd.ViewModel;

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
            var travelsViewModel = new TravelsViewModel();
            if (User.Identity.IsAuthenticated)
            {
                travelsViewModel.Travels = _travelRepository.GetTravelList(User.CreateUser());
                travelsViewModel.IsAuthenticated = true;
            }

            return View(travelsViewModel);
        }
    }
}