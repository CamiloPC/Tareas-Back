using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskApi.Entities;

namespace TaskApi.Infrastructure.Repositories.Configuration
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {

        public void Configure(EntityTypeBuilder<Department> builder)
        {

            var departments = new List<Department>();

            for (int i = 1; i <= 5; i++)
            {
                var department = new Department
                {
                    Active = true,
                    Id = i,
                    Name = $"Departamento {i}",
                    Workers = new List<User>()
                };

                departments.Add(department);
            }

            builder.HasData(departments);
        }
    }
}
