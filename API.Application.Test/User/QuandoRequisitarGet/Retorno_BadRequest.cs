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

namespace API.Application.Test.User.QuandoRequisitarGet
{
    public class Retorno_BadRequest
    {
        private UserController _controller;

        [Fact(DisplayName = "É possível realizar Get")]
        public async Task E_Possivel_Invocar_Controller_Get()
        {
            var serviceMock = new Mock<IUserService>();
            var nome = Faker.Name.FullName();
            var email = Faker.Internet.Email();

            serviceMock.Setup(m => m
                                                        .Get(It.IsAny<Guid>()))
                                                        .ReturnsAsync(
                    new UserDTO
                    {
                        Id = Guid.NewGuid(),
                        Name = nome,
                        Email = email, 
                        CreatedAt = DateTime.UtcNow
                    });

            _controller = new UserController(serviceMock.Object);
            _controller.ModelState.AddModelError("Email", "O e-mail é obrigatório" );

            var result = await _controller.Get(Guid.NewGuid());
            Assert.True(result is BadRequestObjectResult);
        }
    }
}
