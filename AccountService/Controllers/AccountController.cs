using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AccountService;
using AccountService.Models;
using TransactionService;
using NuGet.Protocol.Plugins;

namespace AccountService.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly AccountDbContext _accountContext;

        public AccountController(AccountDbContext accountContext)
        {
            _accountContext = accountContext;
        }

        // GET: api/account
        [HttpGet]
        public IActionResult GetAccounts()
        {
            var accounts = _accountContext.Accounts.ToList();
            return Ok(accounts);
        }

        [HttpPost("create")]
        public IActionResult CreateAccount([FromBody] Account account)
        {
            if (account == null)
            {
                return BadRequest("Invalid account data");
            }

            _accountContext.Accounts.Add(account);
            _accountContext.SaveChanges();
            return Ok("Account created successfully");
        }

        [HttpPost("{id}/fund")]
        public IActionResult FundAccount(int id, [FromBody] FundRequest fundRequest)
        {
            if (fundRequest == null || fundRequest.Amount <= 0)
            {
                return BadRequest("Invalid fund request");
            }

            var account = _accountContext.Accounts.Find(id);
            if (account == null)
            {
                return NotFound("Account not found");
            }

            account.Balance += fundRequest.Amount;

            // Create and save a transaction
            var fundTransaction = new Transaction
            {
                ReferenceCode = Guid.NewGuid().ToString(),
                Amount = fundRequest.Amount,
                SenderAccountId = id,
                RecipientAccountId = null,
                TransactionAction = "Fund",
                CreatedOn = DateTime.UtcNow
            };

            _accountContext.Transactions.Add(fundTransaction);
            _accountContext.SaveChanges();

            return Ok("Funds added successfully");
        }

        [HttpPost("{id}/withdraw")]
        public IActionResult WithdrawFromAccount(int id, [FromBody] WithdrawRequest withdrawRequest)
        {
            if (withdrawRequest == null || withdrawRequest.Amount <= 0)
            {
                return BadRequest("Invalid withdrawal request");
            }

            var account = _accountContext.Accounts.Find(id);
            if (account == null)
            {
                return NotFound("Account not found");
            }

            if (account.Balance < withdrawRequest.Amount)
            {
                return BadRequest("Insufficient funds");
            }

            account.Balance -= withdrawRequest.Amount;

            // Create and save a transaction
            var fundTransaction = new Transaction
            {
                ReferenceCode = Guid.NewGuid().ToString(),
                Amount = withdrawRequest.Amount,
                SenderAccountId = id,
                RecipientAccountId = null,
                TransactionAction = "Withdraw",
                CreatedOn = DateTime.UtcNow
            };

            _accountContext.Transactions.Add(fundTransaction);
            _accountContext.SaveChanges();

            return Ok("Withdrawal successful");
        }

        [HttpPost("{senderAccountId}/transferfunds")]
        public IActionResult TransferFunds(int senderAccountId, [FromBody] TransferRequest transferRequest)
        {
            if (transferRequest == null || transferRequest.Amount <= 0)
            {
                return BadRequest("Invalid transfer request");
            }

            var senderAccount = _accountContext.Accounts.Find(senderAccountId);
            if (senderAccount == null)
            {
                return NotFound("Sender account not found");
            }

            var recipientAccount = _accountContext.Accounts.Find(transferRequest.RecipientAccountId);
            if (recipientAccount == null)
            {
                return NotFound("Recipient account not found");
            }

            if (senderAccount.Balance < transferRequest.Amount)
            {
                return BadRequest("Insufficient funds for transfer");
            }

            senderAccount.Balance -= transferRequest.Amount;
            recipientAccount.Balance += transferRequest.Amount;

            var transaction = new Transaction
            {
                ReferenceCode = Guid.NewGuid().ToString(),
                Amount = transferRequest.Amount,
                SenderAccountId = senderAccountId,
                RecipientAccountId = transferRequest.RecipientAccountId,
                TransactionAction = "Transfer",
                CreatedOn = DateTime.UtcNow
            };

            _accountContext.Transactions.Add(transaction);
            _accountContext.SaveChanges();

            return Ok("Funds transferred successfully");
        }


        [HttpGet("{id}/getbalance")]
        public IActionResult GetBalance(int id)
        {
            var account = _accountContext.Accounts.Find(id);
            if (account == null)
            {
                return NotFound("Account not found");
            }

            return Ok(account.Balance);
        }

        [HttpGet("{id}/gettransactionhistory")]
        public IActionResult GetTransactionHistory(int id)
        {
            var account = _accountContext.Accounts.Find(id);
            if (account == null)
            {
                return NotFound("Account not found");
            }

            var transactions = _accountContext.Transactions
                .Where(t => t.SenderAccountId == id || t.RecipientAccountId == id)
                .OrderByDescending(t => t.CreatedOn)
                .ToList();

            return Ok(transactions);
        }


    }
}
