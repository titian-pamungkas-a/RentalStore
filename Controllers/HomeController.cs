using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RentalStore.Data;
using RentalStore.DTOs;
using RentalStore.Model;
using RentalStore.Models;

namespace RentalStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly RentalStoreContext _context;

        public HomeController(ILogger<HomeController> logger, RentalStoreContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<ViewData> tabel = await _context.ViewDatas.ToListAsync();
            return View("Views/Home/Index.cshtml", tabel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> Input()
        {
            var users = await _context.Users.ToListAsync();
            var userList = new SelectList(users, "Id", "Name");
            var films = await _context.Films.ToListAsync();
            var filmList = new SelectList(films, "Id", "Name");
            ViewBag.UserList = userList;
            ViewBag.FilmList = filmList;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SubmitInput(RentalInputDTO input)
        {
            Rental rental = new Rental
            {
                UserId = input.UserId,
                FilmId = input.FilmId,
                RentalDate = input.RentalDate,
                DeadlineDate = input.DeadlineDate
            };
            _context.Rentals.Add(rental);
            await _context.SaveChangesAsync();
            return await Index();
        }

        public IActionResult FilmInput()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SubmitFilmInput(Film input)
        {
            Film film= new Film
            {
                Name = input.Name,
                Description = input.Description,
                Synopsis = input.Synopsis,
                ReleaseDate = input.ReleaseDate
            };
            _context.Films.Add(film);
            await _context.SaveChangesAsync();
            return await Index();
        }

        public async Task<IActionResult> UserInput()
        {
            var cities = await _context.Cities.ToListAsync();
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
            User user = new User
            {
                Name = input.Name,
                Email = input.Email,
            };
            await _context.Database.ExecuteSqlRawAsync("CALL add_user({0}, {1}, {2})", input.Name, input.Email, input.GenderUser);
            await _context.SaveChangesAsync();
            var newUser = await _context.Users.Where(u => u.Name == input.Name && u.Email == input.Email).FirstOrDefaultAsync();
            Address address = new Address
            {
                UserId = newUser.Id,
                Name = input.AddressName,
                Num = input.AddressNumber,
                CityId = input.CityId
            };
            _context.Addresses.Add(address);
            await _context.SaveChangesAsync();
            return await Index();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
