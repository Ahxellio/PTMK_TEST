using Microsoft.EntityFrameworkCore;
using PTMK_TEST.Data;
using PTMK_TEST.Entity;
using PTMK_TEST.Extensions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTMK_TEST.Interfaces
{
    public interface IRepository
    {
        public Task<bool> CreateEmployee(Employee emp);
        public List<EmployeeDto> GetAllWithSort();
        public Task<bool> CreateEmployees(List<Employee> emps);
        public List<Employee> EmpoloyeesGenerator();
    }
}
