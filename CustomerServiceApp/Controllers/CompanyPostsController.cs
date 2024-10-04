using CustomerServiceApp.Data;
using CustomerServiceApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CustomerServiceApp.Controllers
{
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

        // GET: CompanyPosts/Create
        public IActionResult Create()
        {
            ViewData["CompanyId"] = new SelectList(_context.Company, "CompanyID", "CompanyName");
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

            var companyPost = await _context.CompanyPost.Where(x => x.CompanyId == companyID).ToListAsync();

            return View(companyPost);
        }


        private bool CompanyPostExists(int id)
        {
            return _context.CompanyPost.Any(e => e.Id == id);
        }



    }
}
