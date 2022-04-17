
using Account.Application.Common.Extentions;
using MediatR;

namespace Account.Application.CQRS.Commands.CreateTransactionCommand

{
    public class CreateTransactionCommand : IRequest<bool>
    {
        public int AccountNumber { get; set; }
        public string CustomerNumber { get; set; }
        public decimal InitialCredit { get; set; }

    }


    public class CreateTransactionCommandHandler : IRequestHandler<CreateTransactionCommand, bool>
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public CreateTransactionCommandHandler(HttpClient httpClient, IConfiguration configuration) 
        {
            this._httpClient = httpClient;
            this._configuration = configuration;

        }

        public async Task<bool> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
        {
            // consume Transactions Api to post the transaction 
            // for real development we can use message broker 
            var result = await _httpClient.PostJsonAsync($"{_configuration["TransactionBaseUrl"]}/api/Transactions", new
            {
                CustomerNumber = request.CustomerNumber,
                AccountNumber = request.AccountNumber,
                Amount = request.InitialCredit

            }, cancellationToken: cancellationToken);

            return result.IsSuccessStatusCode;
        }

    }




}
