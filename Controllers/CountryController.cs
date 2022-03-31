
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
	public class CountryController : ControllerBase
	{
		private readonly CountryRepo _repo;

        private readonly IMapper _mapper;

        public CountryController(CountryRepo repo, IMapper mapper)
		{
			_repo = repo;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<IActionResult> GetCountries()
		{
			var countries = await _repo.Get();
			return new JsonResult(_mapper.Map<IEnumerable<CountryListDTO>>(countries));
		}
	}
}