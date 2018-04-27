using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using FluentValidation;
using MediatR;

namespace  EmployeeDirectory.Features.Employee
{
	public class EmployeeViewModel: IRequest
    {
        public long? Id { get; set; }

        public string Name { get; set; }
              
        [DisplayName("Job Title")]
        public string JobTitle { get; set; }

        public string Location { get; set; }

        public string Email { get; set; }

        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }    
    }

	public class EmployeeValidator : AbstractValidator<EmployeeViewModel>
	{
		public EmployeeValidator()
		{
			RuleFor(x => x.Name).MaximumLength(10).WithMessage("The maximum length of Name is 10");
			RuleFor(x => x.PhoneNumber).MaximumLength(10);
			RuleFor(x => x.Email).EmailAddress();
		}
	}
}
