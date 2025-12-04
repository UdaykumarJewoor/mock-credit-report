using System;
using Microsoft.EntityFrameworkCore;
using MockCreditReport.Data;
using MockCreditReport.Models;

namespace MockCreditReport.Repositories
{
    public class CreditReportRepository
    {
        private readonly AppDbContext _db;

        public CreditReportRepository(AppDbContext db)
        {
            _db = db;
        }

        // getById
        public async Task<CreditReport?> GetByIdAsync(int id)
        {
            return await _db.CreditReports
                .Include(x => x.PrimaryInsured!).ThenInclude(p => p.Address)
                .Include(x => x.SecondaryInsured!).ThenInclude(p => p.Address)
                .Include(x => x.Inquiries)
                .Include(x => x.PublicRecords)
                .Include(x => x.Collections)
                .Include(x => x.Trades!).ThenInclude(t => t.PaymentHistorySummary)
                .Include(x => x.Addresses)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        //save
        public async Task<CreditReport> SaveAsync(CreditReport report)
        {
            await _db.CreditReports.AddAsync(report);
            await _db.SaveChangesAsync();

            return await GetByIdAsync(report.Id) ?? report;
        }

        // getInquiries
        public async Task<List<Inquiry>> GetInquiriesAsync(int id)
        {
            var report = await _db.CreditReports
                .Include(x => x.Inquiries)
                .FirstOrDefaultAsync(x => x.Id == id);

            return report?.Inquiries ?? new List<Inquiry>();
        }

        //getTrades
        public async Task<List<Trade>> GetTradesAsync(int id)
        {
            var report = await _db.CreditReports
                .Include(x => x.Trades!)
                    .ThenInclude(t => t.PaymentHistorySummary)
                .FirstOrDefaultAsync(x => x.Id == id);

            return report?.Trades ?? new List<Trade>();
        }


        //getAddresses
        public async Task<List<Address>> GetAddressesAsync(int id)
        {
            var report = await _db.CreditReports
                .Include(x => x.Addresses)
                .FirstOrDefaultAsync(x => x.Id == id);

            return report?.Addresses ?? new List<Address>();
        }

        //getPrimaryInsured
        public async Task<Insured?> GetPrimaryInsuredAsync(int id)
        {
            var report = await _db.CreditReports
                .Include(x => x.PrimaryInsured).ThenInclude(p => p.Address)
                .FirstOrDefaultAsync(x => x.Id == id);

            return report?.PrimaryInsured;
        }
    }
}
