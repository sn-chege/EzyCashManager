using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ATMService;
using ATMService.Models;

namespace ATMService.Controllers
{
    [Route("api/atm")]
    [ApiController]
    public class ATMController : ControllerBase
    {
        private readonly ATMDbContext _dbContext;

        public ATMController(ATMDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET /atm
        [HttpGet]
        public IActionResult GetAllATMs()
        {
            var allATMs = _dbContext.ATMs.ToList();
            return Ok(allATMs);
        }

        // GET /atm/{id}/balance
        [HttpGet("{id}/balance")]
        public IActionResult GetATMBalance(int id)
        {
            var atm = _dbContext.ATMs.Find(id);

            if (atm == null)
            {
                return NotFound();
            }

            return Ok(atm.Balance);
        }        

        // POST /atm/{id}/withdraw
        [HttpPost("{id}/withdraw")]
        public IActionResult WithdrawFromATM(int id, [FromBody] WithdrawRequest withdrawRequest)
        {
            var atm = _dbContext.ATMs.Find(id);

            if (atm == null)
            {
                return NotFound();
            }

            if (atm.Balance < withdrawRequest.Amount)
            {
                return BadRequest("Insufficient funds");
            }

            atm.Balance -= withdrawRequest.Amount;
            _dbContext.SaveChanges();

            return Ok($"Withdrawn {withdrawRequest.Amount} from ATM {id}");
        }

        // POST /atm/create
        [HttpPost("create")]
        public IActionResult CreateATM([FromBody] ATM newATM)
        {
            _dbContext.ATMs.Add(newATM);
            _dbContext.SaveChanges();

            return Ok(newATM);
        }

        // POST /atm/fund
        [HttpPost("fund")]
        public IActionResult FundATM([FromBody] FundRequest fundRequest)
        {
            var atm = _dbContext.ATMs.Find(fundRequest.Id);

            if (atm == null)
            {
                return NotFound();
            }

            atm.Balance += fundRequest.Amount;
            _dbContext.SaveChanges();

            return Ok(atm);
        }
    }

    public class FundRequest
    {
        public int Id { get; set; }
        public double Amount { get; set; }
    }

    public class WithdrawRequest
    {
        public double Amount { get; set; }
    }
}
