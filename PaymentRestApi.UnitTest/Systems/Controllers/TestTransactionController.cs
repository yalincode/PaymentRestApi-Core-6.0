using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using PaymentRestApi.Controllers;
using PaymentRestApi.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PaymentRestApi.UnitTest.Systems.Controllers
{
    public class TestTransactionController
    {
        [Fact]
        public void Get_OnSuccess_ReturnsStatusCode200()
        {
            //Arrange
            var sut = new TransactionController();

            //Act=>Account info unit test return 200 status code for AccountNumber 100 
            var deposit = new DepositDTO()
            {
                accountNumber = 100,
                amount =50,
                
            };
            var result = (OkObjectResult)sut.Deposit(deposit);


            //Assert
            result.StatusCode.Should().Be(200);
        }
    }
}
