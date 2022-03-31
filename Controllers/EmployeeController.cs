
using System.Threading.Tasks;
using api.Repository;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class EmployeeController : ControllerBase
	{
		private readonly EmployeeRepo _repo;

		public EmployeeController(EmployeeRepo repo)
		{
			_repo = repo;
		}

		[HttpGet]
		public async Task<IActionResult> GetEmployees()
		{
			var employees = await _repo.Get();
			return new JsonResult(employees);
		}
	}
}