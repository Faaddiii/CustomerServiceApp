using System.ComponentModel.DataAnnotations;

namespace CustomerServiceApp.ViewModels
{
    public class CompanyReviewViewModel
    {
        public int ReviewID { get; set; }

        public int OverallRating { get; set; }

        public string Title { get; set; }

        public string Comments { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public int CompanyId { get; set; }

        public string CompanyName { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
