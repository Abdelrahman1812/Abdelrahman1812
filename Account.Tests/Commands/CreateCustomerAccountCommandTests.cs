using Account.Application.CQRS.Commands.CreateCustomerAccountCommand;
using Account.Application.CQRS.Commands.CreateTransactionCommand;
using Account.Application.CQRS.Queries;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Account.Tests.Commands
{
    using static Testing;

    internal class CreateCustomerAccountCommandTests
    {
        [Test]
        public async void ShouldRequireCustomerId()
        {
            var command = new CreateCustomerAccountCommand();
            await FluentActions.Invoking(() =>
            SendAsync(command)).Should().ThrowAsync<ValidationException>();
        }


        [Test]
        public async Task ShouldCreateAccount()
        {

            var customer = await SendAsync(new GetCustomerQuery
            {
                CustomerNumber = "123"
            });
            var command = new CreateCustomerAccountCommand
            {
                CustomerID = customer.Id
            };
            var AccountNumber = await SendAsync(command);

            AccountNumber.Should().BeGreaterThan(0);

        }


    }
}
