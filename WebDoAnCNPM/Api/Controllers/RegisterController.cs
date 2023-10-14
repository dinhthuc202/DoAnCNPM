using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Http;
using System.Data.SqlClient;
using Api.Models;
using Microsoft.AspNetCore.Authorization;

namespace Api.Controllers
{
    public class RegisterController : ControllerBase
    {
        
        [HttpPost]
        [Route("api/Register")]
        [AllowAnonymous]
        public string addAccount([FromBody] Account account)
        {
            using (SqlConnection connection = new SqlConnection(Constants.connectionString))
            {
                connection.Open();

                // Kiểm tra xem UserName đã tồn tại trong cơ sở dữ liệu chưa
                string checkQuery = "SELECT COUNT(*) FROM Account WHERE UserName = @UserName";
                using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                {
                    checkCommand.Parameters.AddWithValue("@UserName", account.UserName);
                    int existingUserCount = (int)checkCommand.ExecuteScalar();

                    if (existingUserCount > 0)
                    {
                        // UserName đã tồn tại
                        return "1";
                    }
                }

                // UserName không tồn tại, thêm tài khoản mới
                string insertQuery = "INSERT INTO Account (HoVaTen, Email, UserName, PassWord) VALUES (@HoVaTen, @Email, @UserName, @PassWord)";
                using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                {
                    insertCommand.Parameters.AddWithValue("@HoVaTen", account.HoVaTen);
                    insertCommand.Parameters.AddWithValue("@Email", account.Email);
                    insertCommand.Parameters.AddWithValue("@UserName", account.UserName);
                    insertCommand.Parameters.AddWithValue("@PassWord", account.PassWord);

                    insertCommand.ExecuteNonQuery();

                    // Trả về mã thành công
                    return "0";
                }
            }
        }
    }
}
