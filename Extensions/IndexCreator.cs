using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTMK_TEST.Extensions
{
    public static class IndexCreator
    {
        public static void CreateIndex()
        {
            var conString = "Data Source=localhost;Initial Catalog=ptmk_test;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
            using (SqlConnection connection = new SqlConnection(conString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "IF OBJECT_ID('Employees') IS NOT NULL AND INDEXPROPERTY(OBJECT_ID('Employees'), 'FullName_idx', 'IndexId') IS NULL BEGIN CREATE INDEX FullName_idx ON Employees (FullName, Gender); END;";
                cmd.Connection = connection;
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
