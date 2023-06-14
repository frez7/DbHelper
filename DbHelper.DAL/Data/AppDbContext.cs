using DbHelper.DAL.Entities.DbHelper;
using DbHelper.DAL.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DbHelper.WebApi.AuthBL.Data
{
    public class AppDbContext : IdentityDbContext<Employee, Role, int>
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<ProjectEmployee> ProjectEmployees { get; set; }
        public DbSet<ProjectTask> Tasks { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = config.GetConnectionString("DbHelper")
                ?? throw new InvalidOperationException(
                    "Connection string 'DbHelper' not found.");

            optionsBuilder.UseSqlServer(connectionString, builder =>
            {
                builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
                builder.MigrationsAssembly("DbHelper.WebApi");
            });
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ProjectEmployee>()
                .HasKey(pe => new { pe.ProjectId, pe.EmployeeId });

            modelBuilder.Entity<ProjectEmployee>()
                .HasOne(a => a.Project)
                .WithMany(b => b.ProjectEmployees)
                .HasForeignKey(a => a.ProjectId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ProjectEmployee>()
                .HasOne(a => a.Employee)
                .WithMany(b => b.ProjectEmployees)
                .HasForeignKey(a => a.EmployeeId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ProjectTask>()
                .HasOne(t => t.Executor)
                .WithMany(e => e.Tasks)
                .HasForeignKey(t => t.ExecutorId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ProjectTask>()
                .HasOne(t => t.Project)
                .WithMany(p => p.Tasks)
                .HasForeignKey(t => t.ProjectId)
                .OnDelete(DeleteBehavior.NoAction);

            #region SeedData
            #region SeedIdentity
            modelBuilder.Entity<Role>().HasData(new Role { Id = 1, Name = "Employee", NormalizedName = "EMPLOYEE".ToUpper() });
            modelBuilder.Entity<Role>().HasData(new Role { Id = 2, Name = "Manager", NormalizedName = "MANAGER".ToUpper() });
            modelBuilder.Entity<Role>().HasData(new Role { Id = 3, Name = "Admin", NormalizedName = "ADMIN".ToUpper() });

            var hasher = new PasswordHasher<Employee>();
            
            modelBuilder.Entity<Employee>().HasData(new Employee 
            { 
                Id = 1, 
                UserName = "frez773", 
                NormalizedUserName = "FREZ773",
                Email = "freezedmail@gmail.com", 
                NormalizedEmail = "FREEZEDMAIL@GMAIL.COM",
                PasswordHash = hasher.HashPassword(null, "masterpass"), 
                EmailConfirmed = true,
                LockoutEnabled = false, 
                SecurityStamp = Guid.NewGuid().ToString(),
                FirstName = "Аширхан", 
                LastName = "Аутахунов", 
                FatherName = "Адылжанович"});
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                Id = 2,
                UserName = "test1",
                NormalizedUserName = "TEST1",
                Email = "test1@example.com",
                NormalizedEmail = "TEST1@EXAMPLE.COM",
                PasswordHash = hasher.HashPassword(null, "masterpass"),
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString(),
                FirstName = "Амантур",
                LastName = "Амантуров",
                FatherName = "Амантурович"
            });
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                Id = 3,
                UserName = "test2",
                NormalizedUserName = "TEST2",
                Email = "test2@example.com",
                NormalizedEmail = "TEST2@EXAMPLE.COM",
                PasswordHash = hasher.HashPassword(null, "masterpass"),
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString(),
                FirstName = "Атай",
                LastName = "Атаев",
                FatherName = "Атайбекович"
            });
            modelBuilder.Entity<IdentityUserRole<int>>().HasData(new IdentityUserRole<int>
            {
                RoleId = 3,
                UserId = 1,
            });
            modelBuilder.Entity<IdentityUserRole<int>>().HasData(new IdentityUserRole<int>
            {
                RoleId = 2,
                UserId = 2,
            });
            modelBuilder.Entity<IdentityUserRole<int>>().HasData(new IdentityUserRole<int>
            {
                RoleId = 1,
                UserId = 3,
            });
            #endregion
            #region ProjectSeeding
            modelBuilder.Entity<Project>().HasData(new Project
            {
                Id = 200,
                Name = "R-Keeper CRM",
                StartedAt = DateTime.UtcNow,
                CustomerName = "Timely-Soft",
                ExecutorName = "Sibers",
                OwnerId = 2,
                Priority = 2,
            });

            modelBuilder.Entity<Project>().HasData(new Project
            {
                Id = 201,
                Name = "VisualTrade",
                StartedAt = DateTime.UtcNow,
                CustomerName = "EPAM",
                ExecutorName = "Sibers",
                OwnerId = 2,
                Priority = 1,
            });

            modelBuilder.Entity<Project>().HasData(new Project
            {
                Id = 202,
                Name = "NASA",
                StartedAt = DateTime.UtcNow,
                CustomerName = "SpaceX",
                ExecutorName = "Sibers",
                OwnerId = 2,
                Priority = 1,
            });
            #endregion
            #region ProjectEmployeeSeeding
            modelBuilder.Entity<ProjectEmployee>().HasData(new ProjectEmployee 
            {
                EmployeeId = 3, 
                ProjectId = 200 
            });
            modelBuilder.Entity<ProjectEmployee>().HasData(new ProjectEmployee
            {
                EmployeeId = 3,
                ProjectId = 201
            });
            modelBuilder.Entity<ProjectEmployee>().HasData(new ProjectEmployee
            {
                EmployeeId = 1,
                ProjectId = 200
            });
            modelBuilder.Entity<ProjectEmployee>().HasData(new ProjectEmployee
            {
                EmployeeId = 1,
                ProjectId = 201
            });
            modelBuilder.Entity<ProjectEmployee>().HasData(new ProjectEmployee
            {
                EmployeeId = 1,
                ProjectId = 202
            });
            #endregion
            #region TaskSeeding
            modelBuilder.Entity<ProjectTask>().HasData(new ProjectTask
            {
                Id = 300,
                Name = "Разработать адронный коллайдер",
                Comment = "Надеюсь ты справишься, давай побыстрее",
                ExecutorId = 3,
                OwnerId = 2,
                ProjectId = 202,
                Priority = 1,
                Status = (DAL.Entities.Enums.TaskEnum)1
            });
            modelBuilder.Entity<ProjectTask>().HasData(new ProjectTask
            {
                Id = 301,
                Name = "Создание машины времени",
                Comment = "Надеюсь этого спринта тебе будет достаточно, удачи!",
                ExecutorId = 1,
                OwnerId = 2,
                ProjectId = 201,
                Priority = 1,
                Status = (DAL.Entities.Enums.TaskEnum)1
            });
            modelBuilder.Entity<ProjectTask>().HasData(new ProjectTask
            {
                Id = 302,
                Name = "Создание панацеи",
                Comment = "Разработай бессмертие, дедлайн 3 дня",
                ExecutorId = 1,
                OwnerId = 2,
                ProjectId = 200,
                Priority = 1,
                Status = (DAL.Entities.Enums.TaskEnum)1
            });
            #endregion
            #endregion
        }
    }
}
