
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
	public class CompanyController : ControllerBase
	{
		private readonly CompanyRepo _repo;

		private readonly IMapper _mapper;

		public CompanyController(CompanyRepo repo, IMapper mapper)
		{
			_repo = repo;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<IActionResult> GetCompanies()
		{
			var companies = await _repo.Get();
			return new JsonResult(_mapper.Map<IEnumerable<CompanyListDTO>>(companies));
		}
	}
}