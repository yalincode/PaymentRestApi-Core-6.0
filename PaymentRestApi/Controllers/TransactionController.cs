using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaymentRestApi.DTO;
using PaymentRestApi.Entities;
using PaymentRestApi.FakeDB;

namespace PaymentRestApi.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        [HttpPost("deposit")]
        public IActionResult Deposit(DepositDTO depositDto)
        {
            if (depositDto!=null)
            {
                var account=FakeDb.accounts.Find(c=>c.accountNumber==depositDto.accountNumber);
                if (account != null)
                {
                    if (account.accountType==(AccountType)0)
                    {
                        account.balance += depositDto.amount;
                        var transaction = new Transaction()
                        {
                            Id = (FakeDb.transactions.Count),
                            amount = depositDto.amount,
                            accountNumber = account.accountNumber,
                            transactionType = (TransactionType)1,
                            createdAt = DateTime.Now,

                        };
                        FakeDb.transactions.Add(transaction);
                        return Ok(transaction);
                    }
                    return BadRequest("Account type is not an individual account");
                }
                return BadRequest("Account number is not valid");
            }
            return BadRequest("There are missing parameters");
        }

        [HttpPost("withdraw")]
        public IActionResult Withdraw(WithdrawDTO withdrawDto)
        {
            if (withdrawDto != null)
            {
                var account = FakeDb.accounts.Find(c => c.accountNumber == withdrawDto.accountNumber);
                if (account != null)
                {
                    if (account.accountType == (AccountType)0)
                    {
                        account.balance -= withdrawDto.amount;
                        var transaction = new Transaction()
                        {
                            Id = (FakeDb.transactions.Count),
                            amount = withdrawDto.amount,
                            accountNumber = account.accountNumber,
                            transactionType = (TransactionType)2,
                            createdAt = DateTime.Now,

                        };
                        FakeDb.transactions.Add(transaction);
                        return Ok(transaction);
                    }
                    return BadRequest("Account type is not an individual account");
                }
                return BadRequest("Account number is not valid");
            }
            return BadRequest("There are missing parameters");
        }

        [HttpGet("accounting /{accountNumber}")]
        public IActionResult TransactionHistory(int accountNumber)
        {
            var account=FakeDb.accounts.Find(c => c.accountNumber == accountNumber);
            if (account!=null)
            {
                List<Transaction> transectionsByAccountNumber =FakeDb.transactions.FindAll(c => c.accountNumber == accountNumber);
                
                return Ok(transectionsByAccountNumber);
            }
            return BadRequest("Account number is not valid");
            
        }
    }
}
