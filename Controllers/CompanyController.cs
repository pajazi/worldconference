
using System.Collections.Generic;
using System.Threading.Tasks;
using api.DTO;
using api.Repository;
using api.Search;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using api.Helpers;

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

		[HttpGet("table")]
		public async Task<IActionResult> GetCompanyTable([FromQuery] CompanySearchCriteria searchCriteria)
		{
			var companies = await _repo.GetCompanyTable(searchCriteria);

			Response.AddPagination(companies.CurrentPage, companies.PageSize, companies.ItemCount, companies.TotalPages);

			return Ok(_mapper.Map<IEnumerable<CompanyTableListDTO>>(companies));
		}
	}
}