using Api.Domain.Interfaces.Services.User;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Api.Service.Test.User
{
   public class QuandoForExecutadoUpdate : UserTest
    {
        private IUserService _userService;
        private Mock<IUserService> _userServiceMock;

        [Fact(DisplayName = "É possivel executar o método Update.")]
        public async Task E_Possivel_Executar_GetAll()
        {
            _userServiceMock = new Mock<IUserService>();
            _userServiceMock.Setup(m => m.Post(userDTOCreate)).ReturnsAsync(userDTOCreateResult);
            _userService = _userServiceMock.Object;

            var result = await _userService.Post(userDTOCreate);
            Assert.NotNull(result);
            Assert.Equal(NomeUsuario, result.Name);
            Assert.Equal(EmailUsuario, result.Email);


            _userServiceMock = new Mock<IUserService>();
            _userServiceMock.Setup(m => m.Put(userDTOUpdate)).ReturnsAsync(userDTOUpdateResult);
            _userService = _userServiceMock.Object;

            var resultUpdate = await _userService.Put(userDTOUpdate);
            Assert.NotNull(resultUpdate);
            Assert.Equal(result.Id, resultUpdate.Id);
            Assert.Equal(NomeUsuarioAlterado, resultUpdate.Name);
            Assert.Equal(EmailUsuarioAlterado, resultUpdate.Email);

        }
    }
}
