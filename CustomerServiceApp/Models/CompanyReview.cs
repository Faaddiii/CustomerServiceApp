using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerServiceApp.Models
{
    [Table("CompanyReviews")]
    public class CompanyReview
    {
        [Key]
        public int ReviewID { get; set; }

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
        public int CompanyId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
