
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PTMK_TEST.Data;
using PTMK_TEST.Entity;
using PTMK_TEST.Extensions;
using PTMK_TEST.Interfaces;
using System.Diagnostics;
using System.Globalization;

namespace PTMK_TEST
{
    public class Program
    {
        public static void Main(string[] args)
        {
            foreach (var a in args)
            {
                Console.WriteLine(a);
            }
            var options = new DbContextOptionsBuilder().GetDatabaseContextOptions();
            var service = new Repository(new ApplicationDbContext(options));
            Stopwatch sw = new Stopwatch();
            string arg = args[0];
            switch (arg)
            {
                case "1":
                    DatabaseCreator.CreateDatabase();
                    TableCreator.CreateTable();
                    break;
                case "2":
                    
                    Employee emp = new Employee()
                    {
                        FullName = args[1],
                        BirthdayDate = DateTime.ParseExact(args[2], "yyyy-MM-dd", CultureInfo.InvariantCulture),
                        Gender = args[3],
                    };
                    service.CreateEmployee(emp);
                    Console.WriteLine("Сотрудник добавлен");
                    break; 
                case "3":
                    var employees = service.GetAllWithSort();
                    foreach (var employee in employees)
                    {
                        Console.WriteLine($"{employee.FullName}\t {employee.BirthdayDate.ToShortDateString()}\t {employee.Age}");
                    }
                    break; 
                case "4":
                    var emps = service.EmpoloyeesGenerator();
                    service.CreateEmployees(emps);
                    Console.WriteLine("Сотрудники добавлены");
                    break; 
                case "5":
                    sw.Start();
                    EmployeesSelector.GetEmployeesWithF();
                    sw.Stop();
                    Console.WriteLine($"Время выполнения метода: {sw.ElapsedMilliseconds} миллисекунд ");
                    break;
                case "6":
                    
                    sw.Start();
                    IndexCreator.CreateIndex();
                    EmployeesSelector.GetEmployeesWithF();
                    sw.Stop();
                    Console.WriteLine($"Время выполнения метода: {sw.ElapsedMilliseconds} миллисекунд ");
                    break;

                default:
                    break;
            }
            

        }
    }
}