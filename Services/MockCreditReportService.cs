using MockCreditReport.Models;

namespace MockCreditReport.Services
{
    public class MockCreditReportService
    {
        private static readonly Random _rand = new Random();

        public CreditReport GetMockCreditReport()
        {
            return new CreditReport
            {
                PrimaryInsured = RandomInsured(),
                SecondaryInsured = RandomInsured(),
                Inquiries = RandomInquiries(),
                PublicRecords = RandomPublicRecords(),
                Collections = RandomCollections(),
                Trades = RandomTrades(),
                Addresses = RandomAddresses()
            };
        }

        // Generate Random Insured 
        private Insured RandomInsured()
        {
            return new Insured
            {
                Name = RandomName(),
                DateOfBirth = RandomDate(1970, 2000),
                SsnLast4 = _rand.Next(1000, 9999).ToString(),
                Address = RandomAddress()
            };
        }

        // Random Address
        private Address RandomAddress()
        {
            string[] labels = { "Home", "Office", "Permanent", "Temporary" };

            return new Address
            {
                Label = labels[_rand.Next(labels.Length)],
                Street = $"{_rand.Next(100, 999)} {RandomStreetName()}",
                City = RandomCity(),
                State = RandomState(),
                Zip = (_rand.Next(80000, 80999)).ToString()
            };
        }

        // Random Inquiries
        private List<Inquiry> RandomInquiries()
        {
            return new List<Inquiry>
            {
                new Inquiry
                {
                    Date = RandomFutureDate(),
                    Inquirer = RandomBankName(),
                    Type = RandomType()
                },
                new Inquiry
                {
                    Date = RandomFutureDate(),
                    Inquirer = RandomBankName(),
                    Type = RandomType()
                }
            };
        }

        // Random Public Records
        private List<PublicRecord> RandomPublicRecords()
        {
            string[] types = { "Bankruptcy", "Tax Lien", "Judgment" };
            string[] statuses = { "Open", "Closed", "Discharged" };

            return new List<PublicRecord>
            {
                new PublicRecord
                {
                    Type = types[_rand.Next(types.Length)],
                    FileDate = RandomPastDate(2000, 2020),
                    Status = statuses[_rand.Next(statuses.Length)],
                    Court = RandomCourtName()
                }
            };
        }

        // Random Collections
        private List<CollectionItem> RandomCollections()
        {
            return new List<CollectionItem>
            {
                new CollectionItem
                {
                    Agency = RandomAgency(),
                    Amount = _rand.Next(100, 5000),
                    Status = RandomStatus(),
                    OpenedDate = RandomPastDate(2010, 2020),
                    ClosedDate = RandomPastDate(2021, 2024)
                }
            };
        }

        // Random Trades
        private List<Trade> RandomTrades()
        {
            return new List<Trade>
            {
                new Trade
                {
                    TradeId = $"T{_rand.Next(100,999)}",
                    CreditorName = RandomBankName(),
                    AccountType = RandomAccountType(),
                    OpenedDate = RandomPastDate(2015, 2020),
                    ClosedDate = RandomOptionalDate(),
                    Status = RandomStatus(),
                    Balance = _rand.Next(0, 10000),
                    CreditLimit = _rand.Next(1000, 20000),
                    OriginalAmount = _rand.Next(500, 20000),
                    Terms = RandomTerms(),
                    PaymentHistorySummary = new PaymentHistorySummary
                    {
                        OnTimePayments = _rand.Next(10, 100),
                        LatePayments = _rand.Next(0, 5),
                        LastLatePaymentDate = RandomOptionalDate()
                    }
                }
            };
        }

        // Random Address List
        private List<Address> RandomAddresses()
        {
            return new List<Address>
            {
                RandomAddress(),
                RandomAddress()
            };
        }


        // ------------------ Helper Random Functions ------------------

        private string RandomName()
        {
            string[] first = { "John", "Jane", "Alex", "Sam", "Chris", "Jordan" };
            string[] last = { "Doe", "Smith", "Johnson", "Williams" };

            return $"{first[_rand.Next(first.Length)]} {last[_rand.Next(last.Length)]}";
        }

        private string RandomStreetName()
        {
            string[] names = { "Main St", "Elm St", "Pine Ave", "Maple Dr", "Cedar Lane" };
            return names[_rand.Next(names.Length)];
        }

        private string RandomCity()
        {
            string[] cities = { "Denver", "Boulder", "Aurora", "Lakewood" };
            return cities[_rand.Next(cities.Length)];
        }

        private string RandomState()
        {
            return "CO";
        }

        private string RandomBankName()
        {
            string[] banks = { "Chase Bank", "Wells Fargo", "Capital One", "Bank of America" };
            return banks[_rand.Next(banks.Length)];
        }

        private string RandomAgency()
        {
            string[] agencies = { "ABC Collections", "XYZ Recovery", "Debt Pro", "CollectCo" };
            return agencies[_rand.Next(agencies.Length)];
        }

        private string RandomCourtName()
        {
            string[] courts =
            {
                "Colorado District Court",
                "US Bankruptcy Court - Colorado",
                "Denver County Court"
            };
            return courts[_rand.Next(courts.Length)];
        }

        private string RandomAccountType()
        {
            string[] types = { "Credit Card", "Auto Loan", "Mortgage", "Student Loan" };
            return types[_rand.Next(types.Length)];
        }

        private string RandomStatus()
        {
            string[] status = { "Open", "Closed", "Paid", "In Progress" };
            return status[_rand.Next(status.Length)];
        }

        private string RandomType()
        {
            string[] types = { "Hard", "Soft" };
            return types[_rand.Next(types.Length)];
        }

        private string RandomTerms()
        {
            string[] terms = { "Revolving", "60 months fixed", "36 months fixed" };
            return terms[_rand.Next(terms.Length)];
        }

        private string RandomDate(int startYear, int endYear)
        {
            return $"{_rand.Next(startYear, endYear)}-{_rand.Next(1, 13):D2}-{_rand.Next(1, 28):D2}";
        }

        private string RandomFutureDate()
        {
            int year = _rand.Next(2024, 2030);
            int month = _rand.Next(1, 12);
            int day = _rand.Next(1, 28);

            return $"{year}-{month:D2}-{day:D2}";
        }

        private string RandomPastDate(int startYear, int endYear)
        {
            return $"{_rand.Next(startYear, endYear)}-{_rand.Next(1, 12):D2}-{_rand.Next(1, 28):D2}";
        }

        private string? RandomOptionalDate()
        {
            return _rand.Next(0, 2) == 0 ? null : RandomPastDate(2018, 2024);
        }
    }
}
