using System;
namespace MockCreditReport.Models
{
    public class Trade
    {
        public int Id { get; set; }

        public string? TradeId { get; set; }
        public string? CreditorName { get; set; }
        public string? AccountType { get; set; }
        public string? OpenedDate { get; set; }
        public string? ClosedDate { get; set; }
        public string? Status { get; set; }
        public decimal Balance { get; set; }
        public decimal CreditLimit { get; set; }
        public decimal OriginalAmount { get; set; }
        public string? Terms { get; set; }
        public PaymentHistorySummary? PaymentHistorySummary { get; set; }
    }

    public class PaymentHistorySummary
    {
        public int Id { get; set; }

        public int OnTimePayments { get; set; }
        public int LatePayments { get; set; }
        public string? LastLatePaymentDate { get; set; }
    }
}
