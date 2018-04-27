using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeDirectory.Models
{
	public class Employee: IEntity
    {
        public long Id { get; set; }

        [Required]
		[MaxLength(10,ErrorMessage = "The maximum length of Name is 10.")]
        public string Name { get; set; }

		[Required]
        public string JobTitle { get; set; }

		[Required]
        public string Location { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string HashedPassword { get; set; }

    }
}

