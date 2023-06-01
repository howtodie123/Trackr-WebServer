

using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using TestTestServer.Models;

namespace TestTestServer;

public class EsistAccountService
{
    private readonly IConfiguration _configuration;
    public EsistAccountService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public  async Task<LoginCheck> checkAccount(LoginCheck login)
    {
        var cus = new LoginCheck(); var CusCheck = new LoginCheck();

        await
        using (var connection = new SqlConnection(_configuration.GetConnectionString("ApiDatabase")))
        {
            // SqlParameter ID = new SqlParameter("@id", SqlDbType.Int);
            //  ID.Value = id;
            var sqlCus = "SELECT CusAccount,CusPassword FROM Customer Where CusAccount = '" + login.Account.ToString() + "'";
            connection.Open();
            using SqlCommand command = new SqlCommand(sqlCus, connection);
            using SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                var check = new LoginCheck()
                {
                    Account = reader["CusAccount"].ToString(),
                    Password = reader["CusPassword"].ToString(),
                };
                cus = check;
            }
            if (cus == CusCheck)
            {
                var sqlAd = "SELECT AdAccount FROM Admins Where AdAccount = '" + login.Account.ToString() + "'";
                using SqlCommand commandAd = new SqlCommand(sqlAd, connection);
                using SqlDataReader readerAd = command.ExecuteReader();
                while (readerAd.Read())
                {
                    var check = new LoginCheck()
                    {
                        Account = readerAd["AdAccount"].ToString(),
                        Password = reader["AdPassword"].ToString(),
                    };
                    cus = check;
                }
                if (cus == CusCheck)
                {
                    var sqlDeli = "SELECT ManAccount,ManPassword FROM DeliveryMan Where ManAccount = '" + login.Account.ToString() + "'";
                    using SqlCommand commandDeli = new SqlCommand(sqlAd, connection);
                    using SqlDataReader readerDeli = command.ExecuteReader();
                    while (readerDeli.Read())
                    {
                        var check = new LoginCheck()
                        {
                            Account = readerDeli["ManAccount"].ToString(),
                            Password = readerDeli["ManPassword"].ToString(),
                        };
                        cus = check;
                    }
                    if (cus == CusCheck) { return CusCheck; }
                }
            }
        }
        return cus;
    }
}
