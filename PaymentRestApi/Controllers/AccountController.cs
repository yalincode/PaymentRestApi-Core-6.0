using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PaymentRestApi.Entities;
using PaymentRestApi.FakeDB;

namespace PaymentRestApi.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        [HttpPost("account")]
        public IActionResult AccountCreate(Account account)
        {
            FakeDb.accounts.Add(account);
            return Ok(FakeDb.accounts);
        }

        [HttpGet("account/{accountNumber}")]
        public IActionResult AccountInfo(int accountNumber)
        {
            var account=FakeDb.accounts.Find(c=>c.accountNumber==accountNumber);
            return Ok(account);
        }

    }
}
