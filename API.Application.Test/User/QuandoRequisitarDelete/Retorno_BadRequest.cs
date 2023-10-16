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
    public class Retorno_BadRequest
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
            _controller.ModelState.AddModelError("Name", "O nome está inválido");
            

            var userDtoUpdate = new UserDTOUpdate
            {
                Id = Guid.NewGuid(),
                Name = nome,
                Email = email
            };

            var result = await _controller.Put(userDtoUpdate);
            Assert.True(result is BadRequestObjectResult);
            Assert.False(_controller.ModelState.IsValid);
        }
    }
}
