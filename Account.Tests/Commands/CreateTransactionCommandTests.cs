using Account.Application.CQRS.Commands.CreateTransactionCommand;
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

    public class CreateTransactionCommandTests 
    {

        [Test]
        public  async void ShouldRequireInitialCredit()
        {
           var command = new CreateTransactionCommand() { CustomerNumber = "123", AccountNumber = 12 };
           await FluentActions.Invoking(() =>
           SendAsync(command)).Should().ThrowAsync<ValidationException>();
        }


    }
}
