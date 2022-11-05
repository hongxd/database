//using database.Entities;
//using Microsoft.EntityFrameworkCore;

//namespace database.Data
//{
//    public class RoutineDbcontext: DbContext
//    {
//        public RoutineDbcontext(DbContextOptions<RoutineDbcontext> options): base(options)
//        {

//        }
//        public DbSet<Company> Companies { get; set; }
//        public DbSet<Employee> Employees { get; set; }

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            modelBuilder.Entity<Company>()
//                .Property(x => x.Name).IsRequired().HasMaxLength(100);
//            modelBuilder.Entity<Company>()
//                .Property(x => x.Introduction).IsRequired().HasMaxLength(500);
//            modelBuilder.Entity<Employee>()
//                .Property(x => x.EmployeeNo).IsRequired().HasMaxLength(10);
//            modelBuilder.Entity<Employee>()
//                .Property(x => x.FirstName).IsRequired().HasMaxLength(50);
//            modelBuilder.Entity<Employee>()
//                .Property(x => x.LastName).IsRequired().HasMaxLength(50);
//            modelBuilder.Entity<Employee>().HasOne(x=>x.Company)
//                .WithMany(x=>x.Employees)
//                .HasForeignKey(x => x.CompanyId).OnDelete(DeleteBehavior.Restrict);
//            modelBuilder.Entity<Company>().HasData(new Company { 
//                Id = 0,
//                Name = "microsoft",
//                Introduction = "ms"
//            },
//            new Company
//            {
//                Id = 1,
//                Name = "google",
//                Introduction = "go"
//            },
//            new Company
//            {
//                Id = 2,
//                Name = "ali",
//                Introduction = "ali"
//            });
//        }
//    }
//}
