using Microsoft.AspNetCore.Mvc;
using UnionSecretariat.Data;
using UnionSecretariat.Helpers;
using UnionSecretariat.Models;

namespace UnionSecretariat.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LettersController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _config;

        public LettersController(AppDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        [HttpPost("send")]
        public IActionResult SendLetter([FromHeader] string Authorization, [FromBody] Letter letter)
        {
            // بررسی bearer
            if (string.IsNullOrEmpty(Authorization) || !Authorization.StartsWith("Bearer "))
                return Unauthorized("Bearer token is missing.");

            string token = Authorization.Substring("Bearer ".Length);

            // فرضاً از تنظیمات یا ثابت‌ها بخوایم
            string exchangeKey = "EX123";
            string lockSerial = "LOCK123";
            string provinceCode = "01";
            string cityCode = "001";
            string guildId = letter.GuildId.ToString();
            string secretKey = "SahaaSecretKey";

            string expectedToken = SecurityHelper.GenerateBearer(exchangeKey, lockSerial, provinceCode, cityCode, guildId, secretKey);

            if (token != expectedToken)
                return Unauthorized("Invalid Bearer token.");

            // ذخیره در دیتابیس
            _context.Letters.Add(letter);
            _context.SaveChanges();

            return Ok(new { message = "Letter saved successfully.", id = letter.Id });
        }


        [HttpGet("get/{guildId}")]
        public IActionResult GetLetterByGuild([FromHeader] string Authorization, int guildId)
        {
            try
            {
                // بررسی bearer
                if (string.IsNullOrEmpty(Authorization) || !Authorization.StartsWith("Bearer "))
                    return Unauthorized(ApiResponse<string>.Fail("Bearer token is missing."));

                string token = Authorization.Substring("Bearer ".Length);

                // تولید مجدد توکن مورد انتظار
                string exchangeKey = "EX123";
                string lockSerial = "LOCK123";
                string provinceCode = "01";
                string cityCode = "001";
                string secretKey = "SahaaSecretKey";
                string expectedToken = SecurityHelper.GenerateBearer(exchangeKey, lockSerial, provinceCode, cityCode, guildId.ToString(), secretKey);

                if (token != expectedToken)
                    return Unauthorized(ApiResponse<string>.Fail("Invalid Bearer token."));

                // واکشی رکورد از دیتابیس
                var letter = _context.Letters.FirstOrDefault(x => x.GuildId == guildId);

                if (letter == null)
                    return NotFound(ApiResponse<string>.Fail("No record found for this GuildId."));

                return Ok(ApiResponse<object>.Ok(letter));
            }
            catch (Exception ex)
            {
                // ثبت خطا در لاگ
                Console.WriteLine(ex.Message);
                return StatusCode(500, ApiResponse<string>.Fail("Server error occurred."));
            }
        }


    }

}
