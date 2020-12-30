using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace OracleCOEWorkTracking.Data
{
    public class WorkTrackingContextFactory : IDesignTimeDbContextFactory<WorkTrackingContext>
    {
        private string _connectionstring { get; set; }
        public WorkTrackingContextFactory()
        {

           _connectionstring = "Data Source=SGOFCORPSQL52;Initial Catalog=OracleWorkMgmt;Integrated Security=False;User ID=OracleWorkMgmtDBO;Password=8D5dAeqpU7F6&Zdy;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
           //_connectionstring = "Data Source=SDRSSHAREDSQLT1;Initial Catalog=OracleWorkMgmt_Stg;Integrated Security=False;User ID=OracleWorkMgmtDBO;Password=T3mpP@ssW0rd;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }

        public WorkTrackingContextFactory(string connectionstring)
        {
            _connectionstring = connectionstring;
        }

        public WorkTrackingContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<WorkTrackingContext>();
            builder.UseSqlServer(_connectionstring);
            return new WorkTrackingContext(builder.Options);
        }

    }
}
