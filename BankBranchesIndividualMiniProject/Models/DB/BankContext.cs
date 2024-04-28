
using Microsoft.EntityFrameworkCore;

namespace BankBranchesIndividualMiniProject.Models.DB
{
    public class BankContext : DbContext
    {
        public BankContext(DbContextOptions<BankContext> options) : base(options)
        {

        }
        public DbSet<BankBranch> BankBranches { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BankBranch>().HasData(
                new BankBranch
                {
                    BranchId = 1,
                    Name = "Head office",
                    Location = "https://maps.app.goo.gl/3LTYnjuK7YzeyAD46",
                    BranchManager = "Omar Ali",
                    EmployeeCount = 35
                },
                new BankBranch
                {
                    BranchId = 2,
                    Name = "Avenues",
                    Location = "https://maps.app.goo.gl/3hvBso457K9ZrReNA",
                    BranchManager = "Majid Al-Shuwaiee",
                    EmployeeCount = 12
                });

            modelBuilder.Entity<Employee>().HasData(
                new 
                {
                    Id = 1,
                    Name = "Saleh",
                    CivilId = "299022600558",
                    Position = "DP1",
                    WorkplaceId = 1
                },
                new 
                {
                    Id = 2,
                    Name = "Ahmad",
                    CivilId = "299072600558",
                    Position = "DP2",
                    WorkplaceId = 2
                });
        }
    }
}
