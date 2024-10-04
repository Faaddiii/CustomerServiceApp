using CustomerServiceApp.Data;
using CustomerServiceApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CustomerServiceApp.Controllers
{
    public class CompanyController : Controller
    {
        private readonly CustomerServiceAppContext _context;

        public CompanyController(CustomerServiceAppContext context)
        {
            _context = context;
        }

        // GET: CreateCompany
        public async Task<IActionResult> Index()
        {
            return View(await _context.Company.ToListAsync());
        }

        // GET: CreateCompany/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Company? company = await _context.Company
                .FirstOrDefaultAsync(m => m.CompanyID == id);
            return company == null ? NotFound() : View(company);
        }

        // GET: CreateCompany/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CreateCompany/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CompanyID,CompanyName,Address,City,State,ZipCode,County,Description,WebsiteURL,Telephone,Fax,YourName,Title,AddressAtCompany,AddressLine2,UserCity,UserState,UserPostalCode,Country,EmailAddress,Password,ConfirmPassword,DayTelephone,FaxNumber")] Company company)
        {
            if (ModelState.IsValid)
            {
                _=_context.Add(company);
                _=await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(company);
        }

        // GET: CreateCompany/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Company? company = await _context.Company.FindAsync(id);
            return company == null ? NotFound() : View(company);
        }

        // POST: CreateCompany/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CompanyID,CompanyName,Address,City,State,ZipCode,County,Description,WebsiteURL,Telephone,Fax,YourName,Title,AddressAtCompany,AddressLine2,UserCity,UserState,UserPostalCode,Country,EmailAddress,Password,ConfirmPassword,DayTelephone,FaxNumber")] Company company)
        {
            if (id != company.CompanyID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _=_context.Update(company);
                    _=await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanyExists(company.CompanyID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(company);
        }

        // GET: CreateCompany/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Company? company = await _context.Company
                .FirstOrDefaultAsync(m => m.CompanyID == id);
            return company == null ? NotFound() : View(company);
        }

        // POST: CreateCompany/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Company? company = await _context.Company.FindAsync(id);
            if (company != null)
            {
                _=_context.Company.Remove(company);
            }

            _=await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompanyExists(int id)
        {
            return _context.Company.Any(e => e.CompanyID == id);
        }
    }
}
