using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Api.Models;
using System.Data.SqlClient;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckLoginController : ControllerBase
    {
        [Authorize]
        [HttpPost]
        [Route("")]
        public object CheckLogin([FromBody] Account account)
        {
            if (!string.IsNullOrWhiteSpace(account.UserName))
            {
                var username = account.UserName;

                using (SqlConnection connection = new SqlConnection(Constants.connectionString))
                {
                    connection.Open();

                    string query = @"SELECT HoVaTen FROM Account WHERE UserName = @UserName;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserName", username);

                        object result = command.ExecuteScalar(); // Lấy giá trị của HoVaTen từ câu truy vấn

                        connection.Close();

                        Account account2 = new Account();
                        account2.HoVaTen = result.ToString();

                        return account2;
                    }
                }
            }
            return null;
        }
    }
}
