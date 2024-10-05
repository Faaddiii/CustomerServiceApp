using CustomerServiceApp.Data;
using CustomerServiceApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CustomerServiceApp.Controllers
{
    public class CompanyReviewsController : Controller
    {
        private readonly CustomerServiceAppContext _context;

        public CompanyReviewsController(CustomerServiceAppContext context)
        {
            _context = context;
        }

        // GET: CompanyReviews
        public async Task<IActionResult> Index()
        {
            return View(await _context.CompanyReviews.ToListAsync());
        }

        // GET: CompanyReviews/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CompanyReview? companyReview = await _context.CompanyReviews
                .FirstOrDefaultAsync(m => m.ReviewID == id);
            return companyReview == null ? NotFound() : View(companyReview);
        }

        // GET: CompanyReviews/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CompanyReviews/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReviewID,OverallRating,Title,Comments,Name,Email,CompanyId,CreatedAt")] CompanyReview companyReview)
        {
            if (ModelState.IsValid)
            {
                _=_context.Add(companyReview);
                _=await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(companyReview);
        }

        // GET: CompanyReviews/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CompanyReview? companyReview = await _context.CompanyReviews.FindAsync(id);
            return companyReview == null ? NotFound() : View(companyReview);
        }

        // POST: CompanyReviews/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReviewID,OverallRating,Title,Comments,Name,Email,CompanyId,CreatedAt")] CompanyReview companyReview)
        {
            if (id != companyReview.ReviewID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _=_context.Update(companyReview);
                    _=await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanyReviewExists(companyReview.ReviewID))
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
            return View(companyReview);
        }

        // GET: CompanyReviews/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CompanyReview? companyReview = await _context.CompanyReviews
                .FirstOrDefaultAsync(m => m.ReviewID == id);
            return companyReview == null ? NotFound() : View(companyReview);
        }

        // POST: CompanyReviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            CompanyReview? companyReview = await _context.CompanyReviews.FindAsync(id);
            if (companyReview != null)
            {
                _=_context.CompanyReviews.Remove(companyReview);
            }

            _=await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompanyReviewExists(int id)
        {
            return _context.CompanyReviews.Any(e => e.ReviewID == id);
        }
    }
}
