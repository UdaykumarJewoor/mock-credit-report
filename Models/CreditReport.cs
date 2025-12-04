using System;
namespace MockCreditReport.Models
{
    public class CreditReport
    {
        public int Id { get; set; }

        public Insured? PrimaryInsured { get; set; }
        public Insured? SecondaryInsured { get; set; }

        public List<Inquiry>? Inquiries { get; set; }
        public List<PublicRecord>? PublicRecords { get; set; }
        public List<CollectionItem>? Collections { get; set; }
        public List<Trade>? Trades { get; set; }
        public List<Address>? Addresses { get; set; }
    }
}

