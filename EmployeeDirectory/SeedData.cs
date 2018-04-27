using System;
using System.Linq;
using EmployeeDirectory.Models;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeDirectory
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider){
            var context = serviceProvider.GetRequiredService<EmployeeDirContext>();
            context.Database.EnsureCreated();
            if(!context.Employees.Any()){
                context.Employees.Add(new Employee { Name = "Prath Kale", Email = "prathkale@headspring.com", JobTitle = "Consultnat 1", Location = "Austin", PhoneNumber = "1234561234" });
                context.Employees.Add(new Employee { Name = "Joe Buzz", Email = "joebuzz@headspring.com", JobTitle = "Sr. Consultant 3", Location = "Austin", PhoneNumber = "2342341234" });
                context.Employees.Add(new Employee { Name = "Jim Smith", Email = "jim@headspring.com", JobTitle = "Consultant 1", Location = "Huston", PhoneNumber = "7491239898" });
                context.Employees.Add(new Employee { Name = "Jane Doe", Email = "jane@headspring.com", JobTitle = "Pr. Consultant", Location = "Huston", PhoneNumber = "8471234565" });
                context.Employees.Add(new Employee { Name = "John Doe", Email = "johndoe@headspring.com", JobTitle = "Sr. Consultnat", Location = "New York", PhoneNumber = "9871234321" });
                context.Employees.Add(new Employee { Name = "Tim Smith", Email = "timsmith@headspring.com", JobTitle = "Jr. Consultnat", Location = "New York", PhoneNumber = "6758431923" });
                context.SaveChangesAsync();
            }
        }
    }
}
