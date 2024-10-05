using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CustomerServiceApp.Data;
using CustomerServiceApp.Models;

namespace CustomerServiceApp.Controllers
{
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
            return View(await _context.PostReviews.ToListAsync());
        }

        // GET: PostReviews/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postReview = await _context.PostReviews
                .FirstOrDefaultAsync(m => m.ReviewID == id);
            if (postReview == null)
            {
                return NotFound();
            }

            return View(postReview);
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
                _context.Add(postReview);
                await _context.SaveChangesAsync();
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

            var postReview = await _context.PostReviews.FindAsync(id);
            if (postReview == null)
            {
                return NotFound();
            }
            return View(postReview);
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
                    _context.Update(postReview);
                    await _context.SaveChangesAsync();
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

            var postReview = await _context.PostReviews
                .FirstOrDefaultAsync(m => m.ReviewID == id);
            if (postReview == null)
            {
                return NotFound();
            }

            return View(postReview);
        }

        // POST: PostReviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var postReview = await _context.PostReviews.FindAsync(id);
            if (postReview != null)
            {
                _context.PostReviews.Remove(postReview);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostReviewExists(int id)
        {
            return _context.PostReviews.Any(e => e.ReviewID == id);
        }
    }
}
