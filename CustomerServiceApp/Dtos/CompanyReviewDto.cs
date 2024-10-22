using System.ComponentModel.DataAnnotations;

namespace CustomerServiceApp.Dtos
{
    public class CompanyReviewDto
    {
        public decimal Rating { get; set; }
        public int CompanyId { get; set; }
        public string ReviewTitle { get; set; }
        public string ReviewContent { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool IsFeatured { get; set; }
        //public IFormFile Photo { get; set; } // This should be fine for file uploads
    }

}
