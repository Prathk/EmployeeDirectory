using System;
using System.Threading.Tasks;
using EmployeeDirectory.Models;
using MediatR;
using AutoMapper;
using System.Linq;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using FluentValidation;

namespace EmployeeDirectory.Features.Employee
{
    public class Edit
    {
		public class Query: IRequest<EmployeeViewModel>
		{
			public int? Id { get; set; }	
		}

		public class QueryValidator: AbstractValidator<Query>
		{
		
			public QueryValidator(){
				RuleFor(m => m.Id).NotNull();
			}
		}

		public class QueryHandler: AsyncRequestHandler<Query,EmployeeViewModel>
		{
			private readonly EmployeeDirContext _dbContext;

			public QueryHandler(EmployeeDirContext dirContext) => _dbContext = dirContext;
            
			protected override Task<EmployeeViewModel> HandleCore(Query request)
			{
				return _dbContext.Employees
					             .Where(x =>  x.Id == request.Id)
					             .ProjectTo<EmployeeViewModel>()
					             .SingleOrDefaultAsync();
			}
		}

		public class CommandHandler : AsyncRequestHandler<EmployeeViewModel>
		{
			private readonly EmployeeDirContext _dbContext;

			public CommandHandler(EmployeeDirContext dirContext) => _dbContext = dirContext;

			protected override async Task HandleCore(EmployeeViewModel request)
			{
				var employee = await _dbContext.Employees.FindAsync(request.Id);

               employee = Mapper.Map(request, employee);
                
               await _dbContext.SaveChangesAsync();              
			}
            
		}
	}
}
