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

namespace API.Application.Test.User.QuandoRequisitarUpdate
{
    public class Retorno_Update
    {
        private UserController _controller;

        [Fact(DisplayName = "É possível realizar Update")]
        public async Task E_Possivel_Invocar_Controller_Update()
        {
            var serviceMock = new Mock<IUserService>();
            var nome = Faker.Name.FullName();
            var email = Faker.Internet.Email();

            serviceMock.Setup(m => m.Put(It.IsAny<UserDTOUpdate>())).ReturnsAsync(new UserDTOUpdateResult
            {
                Id = Guid.NewGuid(),
                Name = nome,
                Email = email,
                UpdatedAt = DateTime.UtcNow
            });

            _controller = new UserController(serviceMock.Object);

            var userDtoUpdate = new UserDTOUpdate
            {
                Id = Guid.NewGuid(),
                Name = nome,
                Email = email
            };

            var result = await _controller.Put(userDtoUpdate);
            Assert.True(result is OkObjectResult);

            var resultValue = ((OkObjectResult)result).Value as UserDTOUpdateResult;
            Assert.NotNull(resultValue);
            Assert.Equal(resultValue.Id, resultValue.Id);
            Assert.Equal(resultValue.Name, resultValue.Name);
            Assert.Equal(resultValue.Email, resultValue.Email);
        }
    }
}
