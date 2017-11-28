using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PIcodeFirst.GoToTheCloud.FrontEnd.Authorization;
using PICodeFirst.GoToTheCloud.App.TravelModel;
using PIcodeFirst.GoToTheCloud.FrontEnd.ViewModel;
using Microsoft.AspNetCore.Authorization;

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

        [HttpGet]
        [Authorize]
        public IActionResult AddNew()
        {
            return View(new TravelViewModel()
            {
                Description = string.Empty,
                Start = DateTime.Now,
                Finish = DateTime.Now,
                Locations = _travelRepository.GetAllLocations()
            });
        }

        [HttpPost]
        [Authorize]
        public IActionResult AddNew(TravelViewModel travelView)
        {
            var travel = new Travel()
            {
                Id = Guid.NewGuid(),
                Description = travelView.Description,
                Start = travelView.Start,
                Finish = travelView.Finish,
                From = new Location() { Id = travelView.FromId },
                To = new Location() { Id = travelView.ToId }
            };

            _travelRepository.AddTravel(travel, User.CreateUser());

            return RedirectToAction("Index");
        }
    }
}