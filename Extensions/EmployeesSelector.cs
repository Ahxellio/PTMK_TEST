using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PTMK_TEST.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTMK_TEST.Extensions
{
    public static class EmployeesSelector
    {
        public static void GetEmployeesWithF()
        {
            var conString = "Data Source=localhost;Initial Catalog=ptmk_test;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
            using (SqlConnection connection = new SqlConnection(conString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM Employees WHERE FullName LIKE 'F%'";
                cmd.Connection = connection;
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
