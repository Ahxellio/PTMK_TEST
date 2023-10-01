using PTMK_TEST.Entity;
using PTMK_TEST.Extensions;
using PTMK_TEST.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTMK_TEST.Data
{
    public class Repository : IRepository
    {
        private readonly ApplicationDbContext _context;
        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateEmployee(Employee emp)
        {
            _context.Employees.Add(emp);
            _context.SaveChanges();
            return true;
        }

        public async Task<bool> CreateEmployees(List<Employee> emps)
        {
            _context.Employees.AddRange(emps);
            _context.SaveChanges();
            return true;
        }

        public List<EmployeeDto> GetAllWithSort()
        {
            var sortedEmployees = _context.Employees
            .GroupBy(x => new { x.FullName, x.BirthdayDate })
            .Select(x => x.First())
            .ToList();
            var dtoEmployees = sortedEmployees.OrderBy(x => x.FullName)
            .Select(x => x.toDto(CalculateAge(x.BirthdayDate)))
            .ToList();
            return dtoEmployees;
        }
        

        private static int CalculateAge(DateTime birthDate) => (DateTime.Now).Year - birthDate.Year;
        public List<Employee> EmpoloyeesGenerator()
        {
            List<Employee> employees = new List<Employee>();
            Parallel.ForEach(Enumerable.Range(0, 1000000), i =>
            {
                var randomGenderIndex = (i % 2) + 1;
                var gender = randomGenderIndex is 1 ? "Male" : "Female";
                var randomName = $"{Faker.Name.First()} " + $"{Faker.Name.Middle()} " + $"{Faker.Name.Last()}";
                var employee = new Employee(randomName, RandomDateGenerator(), gender);
                employees.Add(employee);
            });
            Parallel.ForEach(Enumerable.Range(0, 100), i =>
            {
                var randomGenderIndex = (i % 2) + 1;
                var gender = randomGenderIndex is 1 ? "Male" : "Female";
                var firstName = "F" + Faker.Name.First().ToLower();
                var randomName = $"{firstName} " + $"{Faker.Name.Middle()} " + $"{Faker.Name.Last()}";
                var employee = new Employee(randomName, RandomDateGenerator(), gender);
                employees.Add(employee);
            });

            return employees;
        }

        private static DateTime RandomDateGenerator()
        {
            Random rnd = new Random();
            var startDate = new DateTime(1970, 1, 1);
            int range = (DateTime.Today - startDate).Days;
            var newDate = startDate.AddDays(rnd.Next(range)).ToString("yyyy-MM-dd");
            return DateTime.ParseExact(newDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            
        }
    }
}
