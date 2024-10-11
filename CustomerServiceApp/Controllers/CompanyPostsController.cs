using CustomerServiceApp.Data;
using CustomerServiceApp.Dtos;
using CustomerServiceApp.Models;
using CustomerServiceApp.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CustomerServiceApp.Controllers
{
    [SessionCheck]
    public class CompanyPostsController : Controller
    {
        private readonly CustomerServiceAppContext _context;

        public CompanyPostsController(CustomerServiceAppContext context)
        {
            _context = context;
        }

        // GET: CompanyPosts
        public async Task<IActionResult> Index()
        {
            Microsoft.EntityFrameworkCore.Query.IIncludableQueryable<CompanyPost, Company?> customerServiceAppContext = _context.CompanyPost.Include(c => c.Company);
            return View(await customerServiceAppContext.ToListAsync());
        }

        // GET: CompanyPosts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CompanyPost? companyPost = await _context.CompanyPost
                .Include(c => c.Company)
                .FirstOrDefaultAsync(m => m.Id == id);
            return companyPost == null ? NotFound() : View(companyPost);
        }

        public IActionResult Create()
        {
            var companies = _context.Company.ToList(); // Retrieve companies from database

            if (companies == null || !companies.Any())
            {
                // If no companies are found, return an error view or an empty list
                ViewBag.CompanyId = new SelectList(Enumerable.Empty<Company>(), "CompanyID", "CompanyName");
            }
            else
            {
                // Populate the SelectList with the companies
                ViewBag.CompanyId = new SelectList(companies, "CompanyID", "CompanyName");
            }

            return View();
        }



        // POST: CompanyPosts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,IsFeature,CompanyId")] CompanyPost companyPost)
        {
            if (ModelState.IsValid)
            {
                companyPost.CreatedOn = DateTime.Now;
                _ =_context.Add(companyPost);
                _=await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CompanyId"] = new SelectList(_context.Company, "CompanyID", "CompanyName", companyPost.CompanyId);
            return View(companyPost);
        }

        // GET: CompanyPosts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CompanyPost? companyPost = await _context.CompanyPost.FindAsync(id);
            if (companyPost == null)
            {
                return NotFound();
            }
            ViewData["CompanyId"] = new SelectList(_context.Company, "CompanyID", "CompanyName", companyPost.CompanyId);
            return View(companyPost);
        }

        // POST: CompanyPosts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,IsFeature,CompanyId")] CompanyPost companyPost)
        {
            if (id != companyPost.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _=_context.Update(companyPost);
                    _=await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanyPostExists(companyPost.Id))
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
            ViewData["CompanyId"] = new SelectList(_context.Company, "CompanyID", "CompanyName", companyPost.CompanyId);
            return View(companyPost);
        }

        // GET: CompanyPosts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CompanyPost? companyPost = await _context.CompanyPost
                .Include(c => c.Company)
                .FirstOrDefaultAsync(m => m.Id == id);
            return companyPost == null ? NotFound() : View(companyPost);
        }

        // POST: CompanyPosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            CompanyPost? companyPost = await _context.CompanyPost.FindAsync(id);
            if (companyPost != null)
            {
                _=_context.CompanyPost.Remove(companyPost);
            }

            _=await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        // GET: GetCompanyPosts
        public async Task<IActionResult> GetPost(int? companyID)
        {
            if (companyID == null)
            {
                return NotFound();
            }

            List<CompanyPost> companyPost = await _context.CompanyPost.Where(x => x.CompanyId == companyID).ToListAsync();

            return View(companyPost);
        }

        // GET: CompanyPost/AddReview/5
        public async Task<IActionResult> AddReview(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CompanyPost? company = await _context.CompanyPost.FindAsync(id);
            AddCompanyPostReviewDto dto = new()
            {
                Comments = "",
                Email = "",
                Name = "",
                Title = "",
                CompanyPostName = company.Title,
                CompanyPostId = company.Id
            };
            return company == null ? NotFound() : View(dto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddReview(AddCompanyPostReviewDto model)
        {
            if (!ModelState.IsValid)
            {
                // Re-render the form with the validation errors.
                return View(model);
            }

            CompanyPost? company = await _context.CompanyPost.FindAsync(model.CompanyPostId);
            if (company == null)
            {
                return NotFound();
            }

            PostReview review = new()
            {
                OverallRating = model.OverallRating,
                Title = model.Title,
                Comments = model.Comments,
                Name = model.Name,
                Email = model.Email,
                PostId = model.CompanyPostId,
                CreatedAt = DateTime.UtcNow
            };

            _=_context.PostReviews.Add(review);
            _=await _context.SaveChangesAsync();

            return RedirectToAction("Details", "CompanyPosts", new { id = model.CompanyPostId });
        }


        private bool CompanyPostExists(int id)
        {
            return _context.CompanyPost.Any(e => e.Id == id);
        }



    }
}
