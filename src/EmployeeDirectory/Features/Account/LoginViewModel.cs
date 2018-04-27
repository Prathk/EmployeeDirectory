using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using FluentValidation;
using FluentValidation.Results;
using EmployeeDirectory.Models;
using EmployeeDirectory.Infrastructure;


namespace EmployeeDirectory.Features.Account
{

    public class Login
    {
    
        public class LoginViewModel: IRequest
        {
            public string UserName { get; set; }

            [DataType(DataType.Password)]
            public string Password { get; set; }
            
        }

        public class Validator : AbstractValidator<LoginViewModel>
        {
            public Validator(EmployeeDirContext dbContext){
                Custom(vm =>
                {
                    if (string.IsNullOrEmpty(vm.UserName) || string.IsNullOrEmpty(vm.Password))
                        return new ValidationFailure("", "The username or password was invalid. Please try again.");

                    var employee = dbContext.Employees.SingleOrDefault(x => x.UserName == vm.UserName);

                    if(employee == null)
                        return new ValidationFailure("", "The username or password was invalid. Please try again.");

                    if (!PasswordService.Verify(vm.Password, employee.HashedPassword))
                        return new ValidationFailure("", "The password is invlaid.");

                    return null;

                });
            }
        }
    }

}