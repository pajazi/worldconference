
using System.Collections.Generic;
using System.Threading.Tasks;
using api.DTO;
using api.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class EmployeeController : ControllerBase
	{
		private readonly EmployeeRepo _repo;

        private readonly IMapper _mapper;

        public EmployeeController(EmployeeRepo repo, IMapper mapper)
		{
			_repo = repo;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<IActionResult> GetEmployees()
		{
			var employees = await _repo.Get();
			return new JsonResult(_mapper.Map<IEnumerable<EmployeeListDTO>>(employees));
		}
	}
}