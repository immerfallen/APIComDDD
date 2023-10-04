using Api.Domain.DTOs;
using Api.Domain.Interfaces.Services.User;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Api.Service.Test.Login
{
    public class QuandoForExecutadoFindByLogin
    {

        private ILoginService _loginService;
        private Mock<ILoginService> _serviceMock;

        [Fact(DisplayName = "É possível executar o FindByLogin.")]
        public async Task E_Possivel_Executar_FindByLogin()
        {
            var email = Faker.Internet.Email();
            var objeto = new
            {
                authenticated = true,
                created = DateTime.UtcNow,
                expiration = DateTime.UtcNow.AddHours(8),
                accessToken = Guid.NewGuid(),
                userName = email,
                message = "Usuário logado com sucesso"
            };

            var loginDto = new LoginDTO
            {
                Email = email
            };

            _serviceMock = new Mock<ILoginService>();
            _serviceMock.Setup(m => m.FindByLogin(loginDto)).ReturnsAsync(objeto);
            _loginService = _serviceMock.Object;

            var result = await _loginService.FindByLogin(loginDto);
            Assert.NotNull(result);
        }
    }

}
