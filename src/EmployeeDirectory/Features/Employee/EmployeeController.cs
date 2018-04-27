using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EmployeeDirectory.Models;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace EmployeeDirectory.Features.Employee
{
	public class EmployeeController : Controller
	{
		private readonly IMediator _mediator;

		public EmployeeController(IMediator mediator) => _mediator = mediator;
	      
		public async Task<IActionResult> Index()
		{
			var courses = await _mediator.Send<Index.Result>(new Index.Query());
			return View(courses.AllEmployees);
		}

		[HttpGet]
		public async Task<IActionResult> Edit(Edit.Query query) =>  View(await _mediator.Send(query));
        

		[HttpPost]
		[ActionName("Edit")]
        public async Task<IActionResult> Edit(EmployeeViewModel command)
        {

			if (!ModelState.IsValid)
            {
				return View("Edit", command);
            }
            
			await _mediator.Send(command);
   
			return RedirectToAction("Index");
        }


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
