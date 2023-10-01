using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTMK_TEST.Extensions
{
    public static class DatabaseCreator
    {
        public static void CreateDatabase()
        {
            var conString = "Data Source=localhost;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
            using (SqlConnection connection = new SqlConnection(conString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "BEGIN TRY CREATE DATABASE ptmk_test; END TRY BEGIN CATCH IF ERROR_NUMBER() <> 1801 BEGIN THROW; END; END CATCH;";
                cmd.Connection = connection;
                cmd.ExecuteNonQuery();
                Console.WriteLine("База данных ptmk_test создана");
                connection.Close();
            }
        }
    }
}
