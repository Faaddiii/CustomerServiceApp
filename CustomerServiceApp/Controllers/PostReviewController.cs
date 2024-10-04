using CustomerServiceApp.Data;
using Microsoft.AspNetCore.Mvc;

namespace CustomerServiceApp.Controllers
{
    public class PostReviewController : Controller
    {
        private readonly CustomerServiceAppContext _context;
        public PostReviewController(CustomerServiceAppContext customerServiceAppContext)
        {
            _context = customerServiceAppContext;
        }

        // GET: PostReviewController
        public ActionResult Index()
        {
            return View();
        }

        // GET: PostReviewController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PostReviewController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PostReviewController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PostReviewController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PostReviewController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PostReviewController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PostReviewController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
