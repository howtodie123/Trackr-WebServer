/*
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
using System.Diagnostics.Tracing;


namespace TestTestServer.Controllers
{
    [ApiController]
    [Route("api/CheckAccount")]
    public class EsistAccountController : Controller
    {
        private readonly APIData dbContext;
        private readonly IConfiguration _configuration;

        public EsistAccountController(APIData dbContext, IConfiguration configuration)
        {
            this.dbContext = dbContext;
            _configuration = configuration;
        }
        public int check = 0;
        public int check1 = 0;
        public int check2 = 0;
        [HttpPost]
        public async Task<IActionResult> Get(string acc, string pas)
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
                    if (check2 != 0)
                    {
                        check2 = 0;
                        return DeliMan;
                    }
                    else
                    {
                        return NotFound();
                        // return (IEnumerable<Login>)NotFound("Sai mật khẩu hoặc tài khoản");
                    }
                }
            }
        }
        private async Task<IActionResult> GetAd(string acc, string pas)
        {
            var Admins = new Login(); var AdminCheck = new Login();
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
                        role = "Admin"`
                    };
                    Admins = admin;
                    check++;
                }
            }
            if (Admins == AdminCheck)
                check = 0;
            return Ok(Admins);
        }
        private async Task<IActionResult> GetCus(string acc, string pas)
        {
            var Cuss = new Login(); var CusCheck = new Login();
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
                    Cuss = Login;
                    check1++;
                }
            }
            if (Cuss == CusCheck)
                check1 = 0;
            return Ok(Cuss);
        }
        private async Task<IActionResult> GetDeli(string acc, string pas)
        {
            var deli = new Login(); var delicheck = new Login();
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
                    deli = login;
                    check2++;
                }
            }
            if (deli == delicheck)
                check2 = 0;
            return Ok(deli);
        }
    }
}
*/