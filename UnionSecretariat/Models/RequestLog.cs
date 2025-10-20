namespace UnionSecretariat.Models
{
    public class RequestLog
    {
        public int Id { get; set; }
        public DateTime LogDate { get; set; } = DateTime.Now;

        public string Method { get; set; }       // GET, POST, ...
        public string Path { get; set; }         // مسیر API
        public string RequestBody { get; set; }  // بدنه درخواست
        public string ResponseBody { get; set; } // پاسخ برگردانده‌شده
        public int StatusCode { get; set; }      // وضعیت پاسخ (200, 400, 500)
        public string? ErrorMessage { get; set; } // اگر خطایی بود
    }
}
