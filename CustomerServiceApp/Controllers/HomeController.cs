using CustomerServiceApp.Data;
using CustomerServiceApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace CustomerServiceApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CustomerServiceAppContext _context;
        public HomeController(ILogger<HomeController> logger, CustomerServiceAppContext customerServiceAppContext)
        {
            _logger = logger;
            _context = customerServiceAppContext;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            // Simple validation logic
            var user = await _context.Logins.Where(x => x.Username.ToLower() == loginDto.Username.ToLower() && x.Password == loginDto.Password).FirstOrDefaultAsync();
            if (user != null)
            {
                ClientSession.Username = user.Username;
                ClientSession.ID = user.ID;
                return RedirectToAction("Index");
            }

            ViewBag.Message = "Invalid credentials";
            return View(loginDto);
        }

        public async Task<IActionResult> Index()
        {
            var companies = await _context.Company.ToListAsync();
            return View(companies); // Pass companies list to the view
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
