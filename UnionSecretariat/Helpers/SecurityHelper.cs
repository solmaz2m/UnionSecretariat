using System.Security.Cryptography;
using System.Text;

namespace UnionSecretariat.Helpers
{
    public static class SecurityHelper
    {
        // ساخت MD5 از یک رشته
        public static string CreateMD5(string input)
        {
            using (var md5 = MD5.Create())
            {
                var inputBytes = Encoding.UTF8.GetBytes(input);
                var hashBytes = md5.ComputeHash(inputBytes);

                var sb = new StringBuilder();
                foreach (var b in hashBytes)
                    sb.Append(b.ToString("x2"));
                return sb.ToString();
            }
        }

        // تولید Bearer از پارامترهای کلاینت
        public static string GenerateBearer(string exchangeKey, string lockSerial, string provinceCode, string cityCode, string guildId, string secretKey)
        {
            // رشته پایه
            string baseString = $"{exchangeKey}-{lockSerial}-{provinceCode}-{cityCode}-{guildId}-{secretKey}";
            // ساخت MD5
            return CreateMD5(baseString);
        }
    }
}
