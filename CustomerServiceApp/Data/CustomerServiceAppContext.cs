using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CustomerServiceApp.Models;

namespace CustomerServiceApp.Data
{
    public class CustomerServiceAppContext : DbContext
    {
        public CustomerServiceAppContext (DbContextOptions<CustomerServiceAppContext> options)
            : base(options)
        {
        }

        public DbSet<CustomerServiceApp.Models.Company> Company { get; set; } = default!;
        public DbSet<CustomerServiceApp.Models.CompanyPost> CompanyPost { get; set; } = default!;
        public DbSet<CustomerServiceApp.Models.Review> Review { get; set; } = default!;
        public DbSet<CustomerServiceApp.Models.Login> Logins { get; set; } = default!;
    }
}
