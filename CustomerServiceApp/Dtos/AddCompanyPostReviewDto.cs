using System.ComponentModel.DataAnnotations;

namespace CustomerServiceApp.Dtos
{
    public class AddCompanyPostReviewDto
    {
        [Range(1, 5)]
        [Required]
        public int OverallRating { get; set; }

        [Required]
        [MaxLength(255)]
        public required string Title { get; set; }

        public required string Comments { get; set; }

        [Required]
        [MaxLength(100)]
        public required string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public required string Email { get; set; }

        [Required]
        public int CompanyPostId { get; set; }
        public string? CompanyPostName { get; set; }
    }
}
