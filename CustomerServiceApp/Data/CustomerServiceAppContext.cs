using Microsoft.EntityFrameworkCore;

namespace CustomerServiceApp.Data
{
    public class CustomerServiceAppContext : DbContext
    {
        public CustomerServiceAppContext(DbContextOptions<CustomerServiceAppContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Company> Company { get; set; } = default!;
        public DbSet<Models.CompanyPost> CompanyPost { get; set; } = default!;
        public DbSet<Models.Login> Logins { get; set; } = default!;
        public DbSet<Models.CompanyReview> CompanyReviews { get; set; } = default!;
        public DbSet<Models.PostReview> PostReviews { get; set; } = default!;
    }
}
