using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RentalStore.Data;
using RentalStore.DTOs;
using RentalStore.Model;
using RentalStore.Models;
using RentalStore.Services;

namespace RentalStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserService _userService;
        private readonly IRentalService _rentalService;
        private readonly IFilmService _filmService;

        public HomeController(ILogger<HomeController> logger, IUserService userService, IFilmService filmService, IRentalService rentalService)
        {
            _logger = logger;
            _filmService = filmService;
            _rentalService = rentalService; 
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            List<ViewData> tabel = await _rentalService.GetRentals();
            return View("Views/Home/Index.cshtml", tabel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> Input()
        {
            var users = await _userService.GetUsers();
            var userList = new SelectList(users, "Id", "Name");
            var films = await _filmService.GetFilms();
            var filmList = new SelectList(films, "Id", "Name");
            ViewBag.UserList = userList;
            ViewBag.FilmList = filmList;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SubmitInput(RentalInputDTO input)
        {
            await _rentalService.AddRental(input);
            return await Index();
        }

        public IActionResult FilmInput()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SubmitFilmInput(Film input)
        {
            await _filmService.AddFilm(input);
            return await Index();
        }

        public async Task<IActionResult> UserInput()
        {
            var cities = await _userService.GetCities();
            var cityList = new SelectList(cities, "Id", "Name");
            var genders = new List<string>() { "male", "female" };
            var genderList = new SelectList(genders, "Name");
            ViewBag.CityList = cityList;
            ViewBag.Gender = genderList;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SubmitUserInput(UserInputDTO input)
        {
            await _userService.AddUser(input);
            return await Index();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
