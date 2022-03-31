
using System.Threading.Tasks;
using api.Repository;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class CompanyController : ControllerBase
	{
		private readonly CompanyRepo _repo;

		public CompanyController(CompanyRepo repo)
		{
			_repo = repo;
		}

		[HttpGet]
		public async Task<IActionResult> GetCompanies()
		{
			var companies = await _repo.Get();
			return new JsonResult(companies);
		}
	}
}