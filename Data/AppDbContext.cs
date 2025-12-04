using System;

using Microsoft.EntityFrameworkCore;
using MockCreditReport.Models;

namespace MockCreditReport.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        public DbSet<CreditReport> CreditReports { get; set; }
        public DbSet<Insured> Insureds { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Inquiry> Inquiries { get; set; }
        public DbSet<PublicRecord> PublicRecords { get; set; }
        public DbSet<CollectionItem> Collections { get; set; }
        public DbSet<Trade> Trades { get; set; }
        public DbSet<PaymentHistorySummary> PaymentHistorySummaries { get; set; }
    }
}

