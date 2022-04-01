using api.DTO;
using api.Models;
using AutoMapper;

namespace api.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Country, CountryListDTO>();
            CreateMap<Employee, EmployeeListDTO>();
            CreateMap<Company, CompanyListDTO>();
			CreateMap<Company, CompanyTableListDTO>()
				.ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country.CountryName));
        }
    }
}
