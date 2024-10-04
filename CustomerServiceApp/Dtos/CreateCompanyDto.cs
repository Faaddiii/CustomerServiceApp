using System.ComponentModel.DataAnnotations;

namespace CustomerServiceApp.Dtos
{
    public class CreateCompanyDto
    {
        [Required(ErrorMessage = "Company Name is required")]
        [MaxLength(255)]
        public string CompanyName { get; set; } = null!;

        [MaxLength(255)]
        public string? Address { get; set; }

        [MaxLength(100)]
        public string? City { get; set; }

        [MaxLength(100)]
        public string? State { get; set; }

        [MaxLength(20)]
        public string? ZipCode { get; set; }

        [MaxLength(100)]
        public string? County { get; set; }

        public string? Description { get; set; } // TEXT field

        [MaxLength(255)]
        public string? WebsiteURL { get; set; }

        [MaxLength(20)]
        public string? Telephone { get; set; }

        [MaxLength(20)]
        public string? Fax { get; set; }

        // User Information
        [MaxLength(255)]
        public string? YourName { get; set; }

        [MaxLength(100)]
        public string? Title { get; set; }

        [MaxLength(255)]
        public string? AddressAtCompany { get; set; }

        [MaxLength(255)]
        public string? AddressLine2 { get; set; }

        [MaxLength(100)]
        public string? UserCity { get; set; }

        [MaxLength(100)]
        public string? UserState { get; set; }

        [MaxLength(20)]
        public string? UserPostalCode { get; set; }

        [MaxLength(100)]
        public string? Country { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(255)]
        public string EmailAddress { get; set; } = null!;

        // Use [DataType(DataType.Password)] for password input fields.
        [Required]
        [DataType(DataType.Password)]
        [MaxLength(255)]
        public string Password { get; set; } = null!;

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        [MaxLength(255)]
        public string? ConfirmPassword { get; set; }

        [MaxLength(20)]
        public string? DayTelephone { get; set; }

        [MaxLength(20)]
        public string? FaxNumber { get; set; }
    }
}
