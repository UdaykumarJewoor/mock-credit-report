using System;

using Microsoft.AspNetCore.Mvc;
using MockCreditReport.Services;

namespace MockCreditReport.Rest
{
    [ApiController]
    [Route("api/[controller]")]
    public class CreditReportController : ControllerBase
    {
        private readonly MockCreditReportService _service;

        public CreditReportController(MockCreditReportService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetFullReport()
        {
            return Ok(_service.GetMockCreditReport());
        }

        [HttpGet("inquiries")]
        public IActionResult GetInquiries()
        {
            return Ok(_service.GetMockCreditReport().Inquiries);
        }

        [HttpGet("trades")]
        public IActionResult GetTrades()
        {
            return Ok(_service.GetMockCreditReport().Trades);
        }

        [HttpGet("addresses")]
        public IActionResult GetAddresses()
        {
            return Ok(_service.GetMockCreditReport().Addresses);
        }

        [HttpGet("primary-insured")]
        public IActionResult GetPrimaryInsured()
        {
            return Ok(_service.GetMockCreditReport().PrimaryInsured);
        }
    }
}
