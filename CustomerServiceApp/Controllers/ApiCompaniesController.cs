using CustomerServiceApp.Data;
using CustomerServiceApp.Models;
using CustomerServiceApp.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CustomerServiceApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiCompaniesController : ControllerBase
    {
        private readonly CustomerServiceAppContext _context;

        public ApiCompaniesController(CustomerServiceAppContext context)
        {
            _context = context;
        }

        // GET: api/ApiCompanies
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<Company>>> GetCompany()
        {
            return await _context.Company.ToListAsync();
        }


        // GET: api/ApiCompanies/5
        [HttpGet("GetAllCompanyPost/{id}")]
        public async Task<ActionResult<IEnumerable<CompanyPost>>> GetAllCompanyPost(int id)
        {
            var posts = await _context.CompanyPost.Include(x => x.Company).Where(c => c.CompanyId == id).ToListAsync();

            return posts == null ? (ActionResult<IEnumerable<CompanyPost>>)NotFound() : (ActionResult<IEnumerable<CompanyPost>>)posts;
        }

        // GET: api/ApiCompanies/5
        [HttpGet("GetAllCompanyReviews/{id}")]
        public async Task<ActionResult<IEnumerable<CompanyReviewViewModel>>> GetAllCompanyReviews(int id)
        {
            var companyReviews = from cr in _context.CompanyReviews
                                 join c in _context.Company on cr.CompanyId equals c.CompanyID
                                 where c.CompanyID == id
                                 select new CompanyReviewViewModel
                                 {
                                     ReviewID = cr.ReviewID,
                                     OverallRating = cr.OverallRating,
                                     Title = cr.Title,
                                     Comments = cr.Comments,
                                     Name = cr.Name,
                                     Email = cr.Email,
                                     CompanyId = c.CompanyID,
                                     CompanyName = c.CompanyName,
                                     CreatedAt = cr.CreatedAt
                                 };


            return await companyReviews.ToListAsync() == null ?
                (ActionResult<IEnumerable<CompanyReviewViewModel>>)NotFound() :
                (ActionResult<IEnumerable<CompanyReviewViewModel>>)await companyReviews.ToListAsync();
        }

        // PUT: api/ApiCompanies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompany(int id, Company company)
        {
            if (id != company.CompanyID)
            {
                return BadRequest();
            }

            _context.Entry(company).State = EntityState.Modified;

            try
            {
                _=await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ApiCompanies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Company>> PostCompany(Company company)
        {
            _=_context.Company.Add(company);
            _=await _context.SaveChangesAsync();

            return CreatedAtAction("GetCompany", new { id = company.CompanyID }, company);
        }

        // DELETE: api/ApiCompanies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            Company? company = await _context.Company.FindAsync(id);
            if (company == null)
            {
                return NotFound();
            }

            _=_context.Company.Remove(company);
            _=await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CompanyExists(int id)
        {
            return _context.Company.Any(e => e.CompanyID == id);
        }
    }
}
