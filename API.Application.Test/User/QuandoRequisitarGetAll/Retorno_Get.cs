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

namespace API.Application.Test.User.QuandoRequisitarGetAll
{
    public class Retorno_GetAll
    {
        private UserController _controller;

        [Fact(DisplayName = "É possível realizar GetAll")]
        public async Task E_Possivel_Invocar_Controller_GetAll()
        {
            var serviceMock = new Mock<IUserService>();          ;

            serviceMock.Setup(m => m
                                                        .GetAll())
                                                        .ReturnsAsync(
                    new List<UserDTO>() {
                    new UserDTO()
                    {
                        Id = Guid.NewGuid(),
                        Name = Faker.Name.FullName(),
                        Email = Faker.Internet.Email(),
                        CreatedAt = DateTime.UtcNow
                    },
                    new UserDTO()
                    {
                        Id = Guid.NewGuid(),
                        Name = Faker.Name.FullName(),
                        Email = Faker.Internet.Email(),
                        CreatedAt = DateTime.UtcNow
                    },
                    new UserDTO()
                    {
                        Id = Guid.NewGuid(),
                        Name = Faker.Name.FullName(),
                        Email = Faker.Internet.Email(),
                        CreatedAt = DateTime.UtcNow
                    }
                    });

            _controller = new UserController(serviceMock.Object);

            var result = await _controller.GetAll();
            Assert.True(result is OkObjectResult);

            var resultValue = ((OkObjectResult)result).Value as List<UserDTO>;
            Assert.NotNull(resultValue);
            Assert.True(resultValue.Count == 3);          


        }
    }
}
