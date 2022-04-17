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

namespace Account.Tests.Queries
{
    using static Testing;

    public class GetCustomerQueryTests
    {
        [Test]
        public async Task ShouldReturnNotfoundException()
        {
            var query = new GetCustomerQuery() { CustomerNumber = "888"};
            await FluentActions.Invoking(() =>
           SendAsync(query)).Should().ThrowAsync<ValidationException>();
            
        }
        [Test]
        public async Task ShouldReturnCustomerInfo()
        {
            var query = new GetCustomerQuery() { CustomerNumber = "123"};

            var result = await SendAsync(query);

            result.Should().NotBeNull();
        }


    }
}
