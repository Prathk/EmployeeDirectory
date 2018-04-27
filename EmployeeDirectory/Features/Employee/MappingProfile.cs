using System;
using AutoMapper;

namespace EmployeeDirectory.Features.Employee
{
	public class MappingProfile: Profile
    {
        public MappingProfile()
        {
			CreateMap<EmployeeViewModel, Models.Employee>();
        }
    }
}
