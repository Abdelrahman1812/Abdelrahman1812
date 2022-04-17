using Account.Application.CQRS.Commands.CreateCustomerAccountCommand;
using Account.Application.CQRS.Commands.CreateTransactionCommand;
using Account.Application.CQRS.Queries;
using Account.VM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Account.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : ApiControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> Info(string CustomerNumber)
        {
            //get customer info
            var customer = await Mediator.Send(new GetCustomerQuery() { CustomerNumber = CustomerNumber });
            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> NewAccount(OpenNewAccountVM request)
        {
            // Check Customer Exists 
            Tuple<bool , Guid> ExistingCustomer = await Mediator.Send(new CheckCustomerExistsQuery() { CustomerNumber = request.CustomerNumber });
            if (!ExistingCustomer.Item1) return NotFound();
            // Create new Account
            var AccountNumber = await Mediator.Send(new CreateCustomerAccountCommand() { CustomerID = ExistingCustomer.Item2 });
            if(AccountNumber == 0) return StatusCode(500 , "Invalid Operation");
            // if 0 then return 
            if (request.InitalCredit <= 0) 
                return Ok("Account has successfully created without any transactions");
            // check if credit > 0 Create new transaction
            bool TransactionResult = await Mediator.Send(new CreateTransactionCommand() { CustomerNumber = request.CustomerNumber , 
                AccountNumber = AccountNumber , InitialCredit = request.InitalCredit });
            if(!TransactionResult) return Ok("Account has successfully created without any transactions");
            return Ok($"Account has successfully created with {request.InitalCredit} transaction");
        }
    }

}
