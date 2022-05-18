using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using PaymentRestApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PaymentRestApi.UnitTest.System.Controllers;

public class TestAccountController
{
    [Fact]
    public void Get_OnSuccess_ReturnsStatusCode200()
    {
        //Arrange
        var sut = new AccountController();

        //Act=>Account info unit test return 200 status code for AccountNumber 100 
        var result = (OkObjectResult)sut.AccountInfo(100);


        //Assert
        result.StatusCode.Should().Be(200);
    }
}
