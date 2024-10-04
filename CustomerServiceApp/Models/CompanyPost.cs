using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CustomerServiceApp.Models
{
    [Table("CompanyPost")]
    public class CompanyPost
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(50)]
        public string? Title { get; set; }
        public string? Description { get; set; }
        public bool IsFeature { get; set; }
        public DateTime? CreatedOn { get; set; } = DateTime.Now;

        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public Company? Company { get; set; }
    }
}
