using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskApi.Entities;
using TaskApi.Infrastructure.Repositories.Configuration;

namespace TaskApi.Infrastructure.Repositories;

public class ApplicationContext : IdentityDbContext<User>
{

    public ApplicationContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new DepartmentConfiguration());

        SeedUserAndRole(modelBuilder);

    }

    void SeedUserAndRole(ModelBuilder builder)
    {
        const string USER_ADMIN_ID = "00000000–0000–0000-0000-000000000001";
        const string ROLE_ADMIN_ID = "00000000–0000–0000-0000-000000000001";

        //seed roles
        builder.Entity<IdentityRole>().HasData(new IdentityRole
        {
            Name = "Admin",
            NormalizedName = "ADMIN",
            Id = ROLE_ADMIN_ID,
            ConcurrencyStamp = ROLE_ADMIN_ID
        },
       new IdentityRole
       {
           Name = "Trabajador",
           NormalizedName = "TRABAJADOR",
           Id = "00000000–0000–0000-0000-000000000002",
           ConcurrencyStamp = "00000000–0000–0000-0000-000000000002"
       },
       new IdentityRole
       {
           Name = "J.Depto",
           NormalizedName = "J.DEPTO",
           Id = "00000000–0000–0000-0000-000000000003",
           ConcurrencyStamp = "00000000–0000–0000-0000-000000000003"
       });

        //seed user
        var user = new User
        {
            Id = USER_ADMIN_ID,
            FName = "Administrator",
            LName = "Administrator",
            UserName= "Administrator",
            Email = "admin@localhost.com",
            NormalizedUserName="ADMINISTRATOR",
            NormalizedEmail="ADMIN@LOCALHOST.COM",
            SecurityStamp=USER_ADMIN_ID,
            ConcurrencyStamp=USER_ADMIN_ID
        };

        //set user password
        PasswordHasher<User> ph = new PasswordHasher<User>();
        user.PasswordHash = ph.HashPassword(user, "Cl@v3pr0");

        //seed user 
        builder.Entity<User>().HasData(user);

        //set user role to admin
        builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
        {
            RoleId = ROLE_ADMIN_ID,
            UserId = USER_ADMIN_ID
        });
    }

    public DbSet<WorkerTask> WorkerTasks { get; set; }
    public DbSet<Department> Departments { get; set; }
}