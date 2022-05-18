using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaymentRestApi.DTO;
using PaymentRestApi.Entities;
using PaymentRestApi.FakeDB;
using PaymentRestApi.Validation;

namespace PaymentRestApi.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        [HttpPost("deposit")]
        public IActionResult Deposit(DepositDTO depositDto)
        {
            if (depositDto != null)
            {
                var account = FakeDb.accounts.Find(c => c.accountNumber == depositDto.accountNumber);
                if (account != null)
                {
                    if (Validation.Validation.IndividualAccountTypeValidation(account))
                    {
                        account.balance += depositDto.amount;
                        var transaction = Helper.Helper.AddDepositTransaction(account, depositDto.amount);
                        return Ok(transaction);
                    }
                    return BadRequest("Account type is not an individual account.");
                }
                return BadRequest("Account number is not a valid account.");
            }
            return BadRequest("There are missing parameters.");
        }

        [HttpPost("withdraw")]
        public IActionResult Withdraw(WithdrawDTO withdrawDto)
        {
            if (withdrawDto != null)
            {
                var account = FakeDb.accounts.Find(c => c.accountNumber == withdrawDto.accountNumber);
                if (account != null)
                {
                    if (Validation.Validation.IndividualAccountTypeValidation(account))
                    {
                        if (Validation.Validation.WithdrawAccountBalanceValidation(account, withdrawDto.amount))
                        {
                            account.balance -= withdrawDto.amount;
                            var transaction = Helper.Helper.AddWithdrawTransaction(account, withdrawDto.amount);
                            return Ok(transaction);
                        }
                        else
                        {
                            return BadRequest("Insufficient balance for transaction.");
                        }

                    }
                    return BadRequest("Account type is not an individual account.");
                }
                return BadRequest("Account number is not a valid account.");
            }
            return BadRequest("There are missing parameters.");
        }

        [HttpGet("accounting /{accountNumber}")]
        public IActionResult TransactionHistory(int accountNumber)
        {
            var account = FakeDb.accounts.Find(c => c.accountNumber == accountNumber);
            if (account != null)
            {
                List<Transaction> transectionsByAccountNumber = FakeDb.transactions.FindAll(c => c.accountNumber == accountNumber);

                return Ok(transectionsByAccountNumber);
            }
            return BadRequest("Account number is not a valid account.");

        }

        [HttpPost("payment")]
        public IActionResult Payment(PaymentDTO paymentDTO)
        {
            var sender = FakeDb.accounts.Find(c => c.accountNumber == paymentDTO.senderAccount);
            var receiver = FakeDb.accounts.Find(c => c.accountNumber == paymentDTO.receiverAccount);
            if (sender != null && receiver != null)
            {
                if (Validation.Validation.IndividualAccountTypeValidation(sender))
                {
                    if (Validation.Validation.CorporateAccountTypeValidation(receiver))
                    {
                        if (Validation.Validation.CurrencyCodeTypeValidation(sender, receiver))
                        {
                            if (Validation.Validation.WithdrawAccountBalanceValidation(sender, paymentDTO.amount))
                            {
                                sender.balance -= paymentDTO.amount;
                                receiver.balance += paymentDTO.amount;
                                var senderTransaction = Helper.Helper.AddWithdrawTransaction(sender, paymentDTO.amount);
                                var receiverTransaction = Helper.Helper.AddDepositTransaction(receiver, paymentDTO.amount);
                                return Ok("Payment transaction completed successfully.");
                            }
                            else
                            {
                                return BadRequest("Insufficient balance for transaction.");
                            }

                        }
                        else
                        {
                            return BadRequest("Sender account and receiver account currency types do not match.");
                        }

                    }
                    else
                    {
                        return BadRequest("Sender account number is not a corporate account.");
                    }
                }
                else
                {
                    return BadRequest("Sender account number is not a individual account.");
                }
            }
            return BadRequest("Account numbers is not valid account.");
        }
    }
}
