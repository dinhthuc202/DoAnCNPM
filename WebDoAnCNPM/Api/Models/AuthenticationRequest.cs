using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Data.SqlClient;


namespace Api
{
    [Serializable]
    public class AuthenticationRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public static bool checkUser(string UserName, string PassWord)
        {
            using (SqlConnection connection = new SqlConnection(Constants.connectionString))
            {
                //Tạo kết nối
                connection.Open();
                //Câu truy vấn
                string query = @"SELECT COUNT(*) FROM Account WHERE Username = @UserName AND PassWord = @Password";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Thay thế các tham số trong câu truy vấn
                    command.Parameters.AddWithValue("@UserName",UserName);
                    command.Parameters.AddWithValue("@Password",PassWord);

                    int count = (int)command.ExecuteScalar(); // Lấy số lượng bản ghi từ câu truy vấn

                    connection.Close(); // Đóng kết nối sau khi sử dụng

                    // Kiểm tra giá trị trả về và trả về kết quả tương ứng
                    if (count == 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

    }
}
