using PTMK_TEST.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTMK_TEST.Extensions
{
    public static class EmployeeMapping
    {
        public static EmployeeDto toDto(this Employee emp, int Age)
        => new EmployeeDto(emp.Id, emp.FullName, emp.BirthdayDate, emp.Gender, Age);

        public static Employee toEmployee(this EmployeeDto empd)
            => new Employee(empd.Id, empd.FullName, empd.BirthdayDate, empd.Gender);
    }
}

