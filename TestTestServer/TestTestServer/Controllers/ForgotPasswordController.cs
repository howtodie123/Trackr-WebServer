using TestTestServer.Data;
using Microsoft.AspNetCore.Mvc;
using TestTestServer.Models;
using Microsoft.EntityFrameworkCore;
using MailKit.Net.Smtp;
using MimeKit;
using static System.Net.Mime.MediaTypeNames;

namespace TestTestServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ForgotPasswordController :Controller
    {
        private readonly EsistAccountService _esistAccountService;
        public ForgotPasswordController( EsistAccountService esistAccountService)
        {
            _esistAccountService = esistAccountService;
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(LoginCheck login)
        {
            //kiểm tra xem account có tồn tại hay không
            var loginCheck = new LoginCheck();
            var check = await _esistAccountService.checkAccount(login);
            if (check == loginCheck) { return NotFound(); }
            // gửi mail trả về mật khẩu cho ng dùng
            var client = new SmtpClient();
            client.Connect("smtp.gmail.com", 465, true); // smtp host, port, use ssl.
            client.Authenticate("TrackrService@gmail.com", "dtwvjgfkeyypoliw"); // gmail account, app password
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Trackr", "TrackrService@gmail.com"));
            message.To.Add(new MailboxAddress("", login.Account));
            message.Subject = "Lấy Lại Mật Khẩu Trackr";
            message.Body = new TextPart("plain")
            {
                Text = "Mật Khẩu của bạn là: " //+ check.Password
            };
            client.Send(message);

            return Ok("Đã gửi mail");
        }
    }
}
