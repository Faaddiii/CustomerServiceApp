using CustomerServiceApp.Data;
using CustomerServiceApp.Models;
using CustomerServiceApp.Utilities;
using CustomerServiceApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CustomerServiceApp.Controllers
{
    [SessionCheck]
    public class PostReviewsController : Controller
    {
        private readonly CustomerServiceAppContext _context;

        public PostReviewsController(CustomerServiceAppContext context)
        {
            _context = context;
        }

        // GET: PostReviews
        public async Task<IActionResult> Index()
        {
            var companyReviews = from cr in _context.PostReviews
                                 join c in _context.CompanyPost on cr.PostId equals c.Id
                                 select new PostReviewViewModel
                                 {
                                     ReviewID = cr.ReviewID,
                                     OverallRating = cr.OverallRating,
                                     Title = cr.Title,
                                     Comments = cr.Comments,
                                     Name = cr.Name,
                                     Email = cr.Email,
                                     PostId = c.Id,
                                     PostTitle = c.Title,
                                     CreatedAt = cr.CreatedAt
                                 };

            return View(await companyReviews.ToListAsync());
        }

        // GET: PostReviews/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PostReview? postReview = await _context.PostReviews
                .FirstOrDefaultAsync(m => m.ReviewID == id);
            return postReview == null ? NotFound() : View(postReview);
        }

        // GET: PostReviews/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PostReviews/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReviewID,OverallRating,Title,Comments,Name,Email,PostId,CreatedAt")] PostReview postReview)
        {
            if (ModelState.IsValid)
            {
                _=_context.Add(postReview);
                _=await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(postReview);
        }

        // GET: PostReviews/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PostReview? postReview = await _context.PostReviews.FindAsync(id);
            return postReview == null ? NotFound() : View(postReview);
        }

        // POST: PostReviews/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReviewID,OverallRating,Title,Comments,Name,Email,PostId,CreatedAt")] PostReview postReview)
        {
            if (id != postReview.ReviewID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _=_context.Update(postReview);
                    _=await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostReviewExists(postReview.ReviewID))
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
            return View(postReview);
        }

        // GET: PostReviews/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PostReview? postReview = await _context.PostReviews
                .FirstOrDefaultAsync(m => m.ReviewID == id);
            return postReview == null ? NotFound() : View(postReview);
        }

        // POST: PostReviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            PostReview? postReview = await _context.PostReviews.FindAsync(id);
            if (postReview != null)
            {
                _=_context.PostReviews.Remove(postReview);
            }

            _=await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostReviewExists(int id)
        {
            return _context.PostReviews.Any(e => e.ReviewID == id);
        }
    }
}
