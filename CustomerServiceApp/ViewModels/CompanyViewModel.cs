namespace CustomerServiceApp.ViewModels
{
    public class CompanyViewModel
    {
        public string CompanyName { get; set; } = null!;
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? ZipCode { get; set; }
        public string? County { get; set; }
        public string? Description { get; set; } // TEXT field
        public string? WebsiteURL { get; set; }
        public string? Telephone { get; set; }
        public string? Fax { get; set; }
        public string? YourName { get; set; }
        public string? Title { get; set; }
        public string? AddressAtCompany { get; set; }
        public string? AddressLine2 { get; set; }
        public string? UserCity { get; set; }
        public string? UserState { get; set; }
        public string? UserPostalCode { get; set; }
        public string? Country { get; set; }
        public string EmailAddress { get; set; } = null!;
        public string? DayTelephone { get; set; }
        public string? FaxNumber { get; set; }
    }
}
