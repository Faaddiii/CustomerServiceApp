using CustomerServiceApp.Data;
using CustomerServiceApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CustomerServiceApp.Controllers
{
    public class AuthController : Controller
    {
        private readonly CustomerServiceAppContext _context;
        public AuthController(CustomerServiceAppContext customerServiceAppContext)
        {
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
                return RedirectToActionPermanent("Index","Home");
            }

            ViewBag.Message = "Invalid credentials";
            return View(loginDto);
        }

        [HttpGet]
        public IActionResult Logout()
        {
            ClientSession.ID = 0;
            ClientSession.Username = "";
            return View("Login");
        }
    }
}
