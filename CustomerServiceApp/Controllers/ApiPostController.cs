using CustomerServiceApp.Data;
using CustomerServiceApp.Dtos;
using CustomerServiceApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace CustomerServiceApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiPostController : ControllerBase
    {
        private readonly CustomerServiceAppContext _context;

        public ApiPostController(CustomerServiceAppContext context)
        {
            _context = context;
        }

        [HttpPost("CompanyPostReview")]
        public async Task<ActionResult<PostReview>> CompanyPostReview(PostReviewDto review)
        {
            // Create a new PostReview object
            PostReview postReview = new PostReview()
            {
                Comments = review.ReviewContent,
                Email = review.Email,
                Name = review.Name,
                Title = review.ReviewTitle,
                CreatedAt = DateTime.Now,
                OverallRating = review.Rating,
                PostId = review.PostId, // Set the PostId
            };

            // Add the review to the database and save changes
            _context.PostReviews.Add(postReview);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReview", new { id = postReview.ReviewID }, postReview);

            //// Check if a file was uploaded
            //if (review.Photo != null)
            //{
            //    // Define the directory path
            //    var uploadDir = Path.Combine("Uploads/Postreviews");

            //    // Check if the directory exists, create it if it doesn't
            //    if (!Directory.Exists(uploadDir))
            //    {
            //        Directory.CreateDirectory(uploadDir);
            //    }

            //    // Save the file
            //    var fileName = Path.GetFileName(review.Photo.FileName);
            //    fileName = fileName +"-"+ DateTime.Now.ToString();
            //    var filePath = Path.Combine(uploadDir, fileName); // Specify your path

            //    using (var stream = new FileStream(filePath, FileMode.Create))
            //    {
            //        await review.Photo.CopyToAsync(stream);
            //    }

            //    // Store the filename in the PostReview object
            //    postReview.Attachment = fileName;
            //}

        }

        [HttpPost("CompanyReview")]
        public async Task<ActionResult<CompanyReview>> CompanyReview(CompanyReviewDto review)
        {
            // Create a new PostReview object
            CompanyReview companyReview = new CompanyReview()
            {
                Comments = review.ReviewContent,
                Email = review.Email,
                Name = review.Name,
                Title = review.ReviewTitle,
                CreatedAt = DateTime.Now,
                OverallRating = review.Rating,
                CompanyId = review.CompanyId, // Set the PostId
            };

            // Add the review to the database and save changes
            _context.CompanyReviews.Add(companyReview);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReview", new { id = companyReview.ReviewID }, companyReview);

            //// Check if a file was uploaded
            //if (review.Photo != null)
            //{
            //    // Define the directory path
            //    var uploadDir = Path.Combine("Uploads/Postreviews");

            //    // Check if the directory exists, create it if it doesn't
            //    if (!Directory.Exists(uploadDir))
            //    {
            //        Directory.CreateDirectory(uploadDir);
            //    }

            //    // Save the file
            //    var fileName = Path.GetFileName(review.Photo.FileName);
            //    fileName = fileName +"-"+ DateTime.Now.ToString();
            //    var filePath = Path.Combine(uploadDir, fileName); // Specify your path

            //    using (var stream = new FileStream(filePath, FileMode.Create))
            //    {
            //        await review.Photo.CopyToAsync(stream);
            //    }

            //    // Store the filename in the PostReview object
            //    postReview.Attachment = fileName;
            //}

        }
    }
}
