
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace PTMK_TEST.Extensions
{
    public static class TableCreator
    {
        public static void CreateTable()
        {
            var conString = "Data Source=localhost;Initial Catalog=ptmk_test;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
            using (SqlConnection connection = new SqlConnection(conString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "IF OBJECT_ID(N'Employees') IS NULL CREATE TABLE Employees (Id INT PRIMARY KEY IDENTITY, FullName NVARCHAR(100) NOT NULL, BirthdayDate DATE NOT NULL,Gender NVARCHAR(15) NOT NULL) ;";
                cmd.Connection = connection;
                cmd.ExecuteNonQuery();
                Console.WriteLine("Таблица Employees создана");
                connection.Close();
            }
        }


    }
}
