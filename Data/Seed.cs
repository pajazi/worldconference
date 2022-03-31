using System.Collections.Generic;
using System.Linq;
using api.DTO;
using api.Models;
using Newtonsoft.Json;

namespace api.Data
{
    public class Seed
    {
        public static void SeedData(DataContext context)
        {
            if (!context.Countries.Any())
            {
                var countryData = System.IO.File.ReadAllText("Data/CountrySeed.json");
                var countries = JsonConvert.DeserializeObject<List<Country>>(countryData);

                foreach (var country in countries)
                {
                    context.Countries.Add(country);
                }

                context.SaveChanges();
            }

            if (!context.Companies.Any())
            {
                var companyData = System.IO.File.ReadAllText("Data/CompanySeed.json");
                var companies = JsonConvert.DeserializeObject<List<CompanySeedDTO>>(companyData);

                foreach (var company in companies)
                {
                    var country = context.Countries.FirstOrDefault(c => c.Id == company.CountryId);
                    context.Companies.Add(new Company
                    {
                        Name = company.Name,
                        Address = company.Address,
                        Type = company.Type,
                        City = company.City,
                        Website = company.Website,
                        Email = company.Email,
                        Phone = company.Phone,
                        Status = company.Status,
                        Created = company.Created,
                        Modified = company.Modified,
                        Country = country
                    });
                }

                context.SaveChanges();
            }

            if (!context.Employees.Any())
            {
                var employeeData = System.IO.File.ReadAllText("Data/EmployeeSeed.json");
                var employees = JsonConvert.DeserializeObject<List<EmployeeSeedDTO>>(employeeData);

                foreach (var employee in employees)
                {
                    var company = context.Companies.FirstOrDefault(c => c.Id == employee.CompanyId);
                    context.Employees.Add(new Employee
                    {
                        Name = employee.Name,
                        Address = employee.Address,
                        Role = employee.Role,
                        Phone = employee.Phone,
                        Status = employee.Status,
                        Created = employee.Created,
                        Modified = employee.Modified,
                        Company = company
                    });
                }

                context.SaveChanges();
            }
        }
    }
}