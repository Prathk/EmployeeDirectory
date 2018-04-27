using System;
using Microsoft.EntityFrameworkCore;

namespace EmployeeDirectory.Models
{
    public class EmployeeDirContext: DbContext
    {
        public EmployeeDirContext(DbContextOptions<EmployeeDirContext> options)
            :base(options)
        {            
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
