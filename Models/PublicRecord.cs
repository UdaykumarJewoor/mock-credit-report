using System;
namespace MockCreditReport.Models
{
    public class PublicRecord
    {
        public int Id { get; set; }

        public string? Type { get; set; }
        public string? FileDate { get; set; }
        public string? Status { get; set; }
        public string? Court { get; set; }
    }
}
