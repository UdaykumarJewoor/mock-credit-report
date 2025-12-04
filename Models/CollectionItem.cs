using System;

namespace MockCreditReport.Models
{
   public class CollectionItem
{
    public string? Agency { get; set; }
    public decimal Amount { get; set; }
    public string? Status { get; set; }
    public string? OpenedDate { get; set; }
    public string? ClosedDate { get; set; }
}

}
