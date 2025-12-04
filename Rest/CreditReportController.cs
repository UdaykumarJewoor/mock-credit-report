using System;
using Microsoft.AspNetCore.Mvc;
using MockCreditReport.Services;
using MockCreditReport.Repositories;

namespace MockCreditReport.Rest
{
    [ApiController]
    [Route("api/[controller]")]
    public class CreditReportController : ControllerBase
    {
        private readonly MockCreditReportService _service;
        private readonly CreditReportRepository _repo;

        public CreditReportController(
            MockCreditReportService service,
            CreditReportRepository repo)
        {
            _service = service;
            _repo = repo;
        }



        // POST - Generate & Save
        [HttpPost]
        public async Task<IActionResult> CreateRandomReport()
        {
            var generated = _service.GetMockCreditReport();
            var saved = await _repo.SaveAsync(generated);

            return Ok(saved);   // FULL JSON with ID
        }





        // GET full report by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetReportById(int id)
        {
            var report = await _repo.GetByIdAsync(id);
            return report == null ? NotFound() : Ok(report);
        }

        // GET inquiries by report ID
        [HttpGet("{id}/inquiries")]
        public async Task<IActionResult> GetInquiries(int id)
        {
            return Ok(await _repo.GetInquiriesAsync(id));
        }

        // GET trades by report ID
        [HttpGet("{id}/trades")]
        public async Task<IActionResult> GetTrades(int id)
        {
            return Ok(await _repo.GetTradesAsync(id));
        }

        // GET addresses by report ID
        [HttpGet("{id}/addresses")]
        public async Task<IActionResult> GetAddresses(int id)
        {
            return Ok(await _repo.GetAddressesAsync(id));
        }

        // GET primary insured by report ID
        [HttpGet("{id}/primary-insured")]
        public async Task<IActionResult> GetPrimaryInsured(int id)
        {
            var result = await _repo.GetPrimaryInsuredAsync(id);
            return result == null ? NotFound() : Ok(result);
        }
    }
}
