using System;
namespace MockCreditReport.Models
{
    public class Inquiry
    {
        public int Id { get; set; }

        public string? Date { get; set; }
        public string? Inquirer { get; set; }
        public string? Type { get; set; }
    }
}
