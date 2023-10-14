using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    public class AccountController : ControllerBase
    {
        [HttpPost]
        [Route("api/Login")]
        [AllowAnonymous]
        public IActionResult Login([FromBody] AuthenticationRequest authenticationRequest)
        {
            // Kiểm tra xem dữ liệu được gửi từ body của yêu cầu có hợp lệ không
            if (authenticationRequest == null || string.IsNullOrEmpty(authenticationRequest.UserName) || string.IsNullOrEmpty(authenticationRequest.Password))
            {
                return BadRequest("Invalid data"); // Trả về mã lỗi Bad Request (400) nếu dữ liệu không hợp lệ
            }

            var jwtAuthenticationManager = new JwtAuthenticationManager();
            var authResult = jwtAuthenticationManager.Authenticate(authenticationRequest.UserName, authenticationRequest.Password);

            if (authResult == null)
            {
                return Unauthorized(); // Nếu xác thực không thành công, trả về mã lỗi Unauthorized (401)
            }
            else
            {
                return Ok(authResult); // Nếu xác thực thành công, trả về mã trạng thái OK (200) kèm theo thông tin xác thực (token, tên người dùng và thời gian hết hạn của token)
            }
        }

    }
}
