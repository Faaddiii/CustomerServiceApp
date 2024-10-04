using CustomerServiceApp.Dtos;
using CustomerServiceApp.Models;
using CustomerServiceApp.ViewModels;

namespace CustomerServiceApp.Utilities
{
    public class ModelMapper
    {
        #region Company
        public CreateCompanyDto MapCreateCompanyDto(Company company)
        {
            return new CreateCompanyDto
            {
                CompanyName = company.CompanyName,
                Address = company.Address,
                City = company.City,
                State = company.State,
                ZipCode = company.ZipCode,
                County = company.County,
                Description = company.Description,
                WebsiteURL = company.WebsiteURL,
                Telephone = company.Telephone,
                Fax = company.Fax,
                YourName = company.YourName,
                Title = company.Title,
                AddressAtCompany = company.AddressAtCompany,
                AddressLine2 = company.AddressLine2,
                UserCity = company.UserCity,
                UserState = company.UserState,
                UserPostalCode = company.UserPostalCode,
                Country = company.Country,
                EmailAddress = company.EmailAddress,
                DayTelephone = company.DayTelephone,
                FaxNumber = company.FaxNumber,
                ConfirmPassword = company.ConfirmPassword,
                Password = company.Password,
            };
        }

        public Company MapCreateCompany(CreateCompanyDto company)
        {
            return new Company
            {
                CompanyName = company.CompanyName,
                Address = company.Address,
                City = company.City,
                State = company.State,
                ZipCode = company.ZipCode,
                County = company.County,
                Description = company.Description,
                WebsiteURL = company.WebsiteURL,
                Telephone = company.Telephone,
                Fax = company.Fax,
                YourName = company.YourName,
                Title = company.Title,
                AddressAtCompany = company.AddressAtCompany,
                AddressLine2 = company.AddressLine2,
                UserCity = company.UserCity,
                UserState = company.UserState,
                UserPostalCode = company.UserPostalCode,
                Country = company.Country,
                EmailAddress = company.EmailAddress,
                DayTelephone = company.DayTelephone,
                FaxNumber = company.FaxNumber,
                ConfirmPassword = company.ConfirmPassword,
                Password = company.Password,
            };
        }

        public CompanyViewModel MapCreateCompanyViewModel(Company company)
        {
            return new CompanyViewModel
            {
                CompanyName = company.CompanyName,
                Address = company.Address,
                City = company.City,
                State = company.State,
                ZipCode = company.ZipCode,
                County = company.County,
                Description = company.Description,
                WebsiteURL = company.WebsiteURL,
                Telephone = company.Telephone,
                Fax = company.Fax,
                YourName = company.YourName,
                Title = company.Title,
                AddressAtCompany = company.AddressAtCompany,
                AddressLine2 = company.AddressLine2,
                UserCity = company.UserCity,
                UserState = company.UserState,
                UserPostalCode = company.UserPostalCode,
                Country = company.Country,
                EmailAddress = company.EmailAddress,
                DayTelephone = company.DayTelephone,
                FaxNumber = company.FaxNumber
            };
        }
        #endregion
    }
}
