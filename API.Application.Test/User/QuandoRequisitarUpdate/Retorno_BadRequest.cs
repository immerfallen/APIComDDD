﻿using Api.application.Controllers;
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
    public class Retorno_BadRequest
    {
        private UserController _controller;

        [Fact(DisplayName = "É possível realizar Delete")]
        public async Task E_Possivel_Invocar_Controller_Delete()
        {
            var serviceMock = new Mock<IUserService>();
            var nome = Faker.Name.FullName();
            var email = Faker.Internet.Email();

            serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(false);

            _controller = new UserController(serviceMock.Object);
            _controller.ModelState.AddModelError("Id", "Formato inválido");
                        

            var result = await _controller.Delete(default(Guid));
            Assert.True(result is BadRequestObjectResult);
            Assert.False(_controller.ModelState.IsValid);
        }
    }
}
