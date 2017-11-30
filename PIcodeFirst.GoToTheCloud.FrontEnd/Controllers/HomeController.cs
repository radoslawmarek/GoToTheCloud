using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PIcodeFirst.GoToTheCloud.FrontEnd.Authorization;
using PICodeFirst.GoToTheCloud.App.TravelModel;
using PIcodeFirst.GoToTheCloud.FrontEnd.ViewModel;
using Microsoft.AspNetCore.Authorization;
using PICodeFirst.GoToTheCloud.Infrastructure.AzureAdGraphApi;
using PICodeFirst.GoToTheCloud.App.UserModel;
using PICodeFirst.GoToTheCloud.App.consts;

namespace PIcodeFirst.GoToTheCloud.FrontEnd.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITravelRepository _travelRepository;
        private readonly IUserService _userService;

        public HomeController(ITravelRepository travelRepository, IUserService userService)
        {
            _travelRepository = travelRepository;
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            var travelsViewModel = new TravelsViewModel();
            if (User.Identity.IsAuthenticated)
            {
                var user = User.CreateUser();
                user.IsApplicationAdministrator = await _userService.IsUserInGroup(user, ClaimsPrincipalExtensions.GetApplicationAdminGroupId());
                travelsViewModel.Travels = _travelRepository.GetTravelList(user);
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
            if (!ModelState.IsValid)
            {
                travelView.Locations = _travelRepository.GetAllLocations();
                travelView.Errors = new List<string>(ModelState.Values
                    .SelectMany(s => s.Errors)
                    .Select(e => e.ErrorMessage)
                    .Distinct());
                
                return View(travelView);
            }

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