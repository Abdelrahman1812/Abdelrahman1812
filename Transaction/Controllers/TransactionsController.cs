using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Transaction.Models;

namespace Transaction.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        /// <summary>
        /// Here I'm using static list for easy implmentation 
        /// </summary>
        public static List<TransactionVM> Transactions = new();


        [HttpPost]
        public IActionResult Post([FromBody] TransactionVM transaction)
        {

            Transactions.Add(transaction);
            return Ok(transaction);
        }

        [HttpGet]
        public IActionResult Get(string CustomerNumber)
        {
            var result =  Transactions.Where(p=>p.CustomerNumber == CustomerNumber);
            var Balance = result.Sum(p => p.Amount);
            return Ok(new { Transactions = result , Balance = Balance});
        }
    }
}
