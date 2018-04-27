using System;
using System.Threading.Tasks;
using EmployeeDirectory.Models;
using MediatR;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using FluentValidation;

namespace EmployeeDirectory.Features.Employee
{
    public class Index
    {
		public class Query: IRequest<Result>
		{
			
		}

		public class Result
		{
			public List<EmployeeViewModel> AllEmployees { get; set; }
		}

		public class QueryHandler : AsyncRequestHandler<Query,Result>
		{

			private EmployeeDirContext _db;

			public QueryHandler(EmployeeDirContext dirContext) => _db = dirContext;

			protected override async Task<Result> HandleCore(Query request)
			{
				var employees = await _db.Employees.ProjectTo<EmployeeViewModel>().ToListAsync();
				return new Result() {AllEmployees = employees};
			}
            
		}


	}
}
