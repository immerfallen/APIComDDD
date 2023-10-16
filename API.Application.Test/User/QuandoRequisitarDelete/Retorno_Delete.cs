using Api.application.Controllers;
using Api.Domain.DTOs.User;
using Api.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace API.Application.Test.User.QuandoRequisitarDelete
{
    public class Retorno_Delete
    {
        private UserController _controller;

        [Fact(DisplayName = "É possível realizar Delete")]
        public async Task E_Possivel_Invocar_Controller_Delete()
        {
            var serviceMock = new Mock<IUserService>();


            serviceMock.Setup(m => m
                                                        .Delete(It.IsAny<Guid>()))
                                                        .ReturnsAsync(true);

            _controller = new UserController(serviceMock.Object);

            var result = await _controller.Delete(Guid.NewGuid());
            Assert.True(result is OkObjectResult);

            var resultValue = ((OkObjectResult)result).Value;
            Assert.True((Boolean)resultValue);
            
        }
    }
}
