using Dapper;
using Microsoft.Extensions.Configuration;
using ShopOnline.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ShopOnline.Web.Produce
{
    public class ReportSerVice: IReportSerVice
    {
        private readonly IConfiguration _configuration;
        public ReportSerVice(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        public async Task<IEnumerable<RevenueReportViewModel>> GetReportAsync(string fromDate, string toDate)
        {
            using (var sqlConnection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                var now = DateTime.Now;

                var firstDayOfMonth = new DateTime(now.Year, now.Month, 1);
                var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
                dynamicParameters.Add("@fromDate", string.IsNullOrEmpty(fromDate) ? firstDayOfMonth.ToString("MM/dd/yyyy") : fromDate);
                dynamicParameters.Add("@toDate", string.IsNullOrEmpty(toDate) ? lastDayOfMonth.ToString("MM/dd/yyyy") : toDate);
                var test = await sqlConnection.QueryAsync<RevenueReportViewModel>(
                      "GetRevenueDaily", dynamicParameters, commandType: CommandType.StoredProcedure);
                return test;
            }
        }
        public async Task<IEnumerable<Product>> GetAllProduct()
        {
            using (var sqlConnection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                await sqlConnection.OpenAsync();
                var now = DateTime.Now;
                var firstDayOfMonth = new DateTime(now.Year, now.Month, 1);
                var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
               
                var test = await sqlConnection.QueryAsync<Product>(
                      "GetAllProductTest", commandType: CommandType.StoredProcedure);
                return test;
            }
        }

        public async Task<IEnumerable<RevenueReportViewModel>> GetTest(string fromDate, string toDate)
        {
            using (var sqlConnection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                var now = DateTime.Now;

                var firstDayOfMonth = new DateTime(now.Year, now.Month, 1);
                var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
                dynamicParameters.Add("@fromDate", string.IsNullOrEmpty(fromDate) ? firstDayOfMonth.ToString("MM/dd/yyyy") : fromDate);
                dynamicParameters.Add("@toDate", string.IsNullOrEmpty(toDate) ? lastDayOfMonth.ToString("MM/dd/yyyy") : toDate);
                var test = await sqlConnection.QueryAsync<RevenueReportViewModel>(
                      "GetRevent", dynamicParameters, commandType: CommandType.StoredProcedure);
                return test;
            }
        }
    }
}
