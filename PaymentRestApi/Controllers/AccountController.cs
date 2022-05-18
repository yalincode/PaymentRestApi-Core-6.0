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
            if (Validation.Validation.AccountValidation(account).Item1)
            {
                account.Id = Helper.Helper.createIDNumber();
                FakeDb.accounts.Add(account);
                return Ok(FakeDb.accounts);
            }
            else
            {
                return BadRequest(Validation.Validation.AccountValidation(account).Item2);
            }
            
            
        }

        [HttpGet("account/{accountNumber}")]
        public IActionResult AccountInfo(int accountNumber)
        {
            var account = FakeDb.accounts.Find(c => c.accountNumber == accountNumber);
            if (account!=null)
            {
                return Ok(account);
            }
            else
            {
                return BadRequest("Account number is not a valid number.");
            }
            
           
        }

    }
}
