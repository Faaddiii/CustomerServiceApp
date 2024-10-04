using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CustomerServiceApp.Models
{
    [Table("Review")]
    public class Review
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Range(1, 5)]  // Assuming the rating is between 1 and 5
        public int OverallRating { get; set; }

        [StringLength(100)]
        public string? Title { get; set; }

        public string? ReviewText { get; set; }  // No specific length since it's text

        [StringLength(100)]
        public string? ReviewerName { get; set; }

        [EmailAddress]
        [StringLength(100)]
        public string? ReviewerEmail { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        [ForeignKey("Post")]
        public int PostId { get; set; }
        public CompanyPost? Post { get; set; }
    }
}
