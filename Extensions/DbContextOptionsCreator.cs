using Microsoft.EntityFrameworkCore;
using PTMK_TEST.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTMK_TEST.Extensions
{
    public static class DbContextOptionsCreator
    {
        public static DbContextOptions<ApplicationDbContext> GetDatabaseContextOptions(this DbContextOptionsBuilder builder)
        {

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlServer("Data Source=localhost;Initial Catalog=ptmk_test;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False")
                .Options;

            return options;
        }
    }
}
