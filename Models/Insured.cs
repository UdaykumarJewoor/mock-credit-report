using System;

namespace MockCreditReport.Models
{
    public class Insured
{
    public string? Name { get; set; }
    public string? DateOfBirth { get; set; }
    public string? SsnLast4 { get; set; }
    public Address? Address { get; set; }
}

}
