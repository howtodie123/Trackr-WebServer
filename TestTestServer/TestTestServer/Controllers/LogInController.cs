using TestTestServer.Data;
using Microsoft.AspNetCore.Mvc;
using TestTestServer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using System.Security.Principal;

namespace TestTestServer.Controllers
{
    [ApiController]
    [Route("api/Login")]
    public class LogInController : Controller
    {
        private readonly IConfiguration _configuration;
        public LogInController( IConfiguration _configuration)
        {
            this._configuration = _configuration;
        }
        public int check = 0;
        public int check1 = 0;
        [HttpGet]
        public async Task<IEnumerable<Login>> Get(string acc, string pas)
        {
            var admin = await GetAd(acc, pas);
            if (check != 0)
            {
                check = 0;
                return admin;
            }
            else
            {
                var customer = await GetCus(acc, pas);
                if (check1 != 0)
                {
                    check1 = 0;
                    return customer;
                }
                else
                {
                    var DeliMan = await GetDeli(acc, pas);
                    return DeliMan;
                }

            }
        }
        private async Task<IEnumerable<Login>> GetAd(string acc, string pas)
        {
            var Admins = new List<Login>();
            await
            using (var connection = new SqlConnection(_configuration.GetConnectionString("ApiDatabase")))
            {
                // SqlParameter ID = new SqlParameter("@id", SqlDbType.Int);
                //  ID.Value = id;
                var sql = "SELECT AdID, AdName, AdAccount, AdPassword FROM Admins Where AdAccount = '" + acc.ToString() + "' and AdPassword = '" + pas.ToString() + "'";
                connection.Open();
                using SqlCommand command = new SqlCommand(sql, connection);
                using SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var admin = new Login()
                    {  //
                        ID = (int)reader["AdID"],
                        Name = reader["AdName"].ToString(),
                        Account = reader["AdAccount"].ToString(),
                        Password = reader["AdPassword"].ToString(),
                        role = "Admin"
                    };
                    Admins.Add(admin);
                    check++;
                }
            }
            if (check > Admins.Count())
                check = 0;
            return Admins;
        }
        private async Task<IEnumerable<Login>> GetCus(string acc, string pas)
        {
            var Cuss = new List<Login>();
            await
            using (var connection = new SqlConnection(_configuration.GetConnectionString("ApiDatabase")))
            {
                // SqlParameter ID = new SqlParameter("@id", SqlDbType.Int);
                //  ID.Value = id;
                var sql = "SELECT CusID, CusName, CusAccount, CusPassword FROM Customer Where CusAccount = '" + acc.ToString() + "' and CusPassword = '" + pas.ToString() + "'";
                connection.Open();
                using SqlCommand command = new SqlCommand(sql, connection);
                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var Login = new Login()
                    {  
                        ID = (int)reader["CusID"],
                        Name = reader["CusName"].ToString(),
                        Account = reader["CusAccount"].ToString(),
                        Password = reader["CusPassword"].ToString(),
                        role = "Customer"
                    };
                    Cuss.Add(Login);
                    check1++;
                }
            }
            if (check1 > Cuss.Count())
                check1 = 0;
            return Cuss;
        }
        private async Task<IEnumerable<Login>> GetDeli(string acc, string pas)
        {
            var deli = new List<Login>();
            await
            using (var connection = new SqlConnection(_configuration.GetConnectionString("ApiDatabase")))
            {
                // SqlParameter ID = new SqlParameter("@id", SqlDbType.Int);
                //  ID.Value = id;
                var sql = "SELECT ManID, ManName, ManAccount, ManPassword FROM DeliveryMan Where ManAccount = '" + acc.ToString() + "' and ManPassword = '" + pas.ToString() + "'";
                connection.Open();
                using SqlCommand command = new SqlCommand(sql, connection);
                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var login = new Login()
                    {  //
                        ID = (int)reader["ManID"],
                        Name = reader["ManName"].ToString(),
                        Account = reader["ManAccount"].ToString(),
                        Password = reader["ManPassword"].ToString(),
                        role = "DeliveryMan"
                    };
                    deli.Add(login);
                }
                reader.Close();
                connection.Close();

            }
            return deli;
        }

    }
}

