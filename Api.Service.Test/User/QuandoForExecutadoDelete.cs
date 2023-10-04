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
    public class QuandoForExecutadoDelete : UserTest
    {
        private IUserService _userService;
        private Mock<IUserService> _userServiceMock;

        [Fact(DisplayName = "É possivel executar o método Delete.")]
        public async Task E_Possivel_Executar_Delete()
        {
            _userServiceMock = new Mock<IUserService>();
            _userServiceMock.Setup(m => m.Delete(IdUsuario)).ReturnsAsync(true);
            _userService = _userServiceMock.Object;

            var result = await _userService.Delete(IdUsuario);
            Assert.True(result);

            _userServiceMock = new Mock<IUserService>();
            _userServiceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(false);
            _userService = _userServiceMock.Object;

            result = await _userService.Delete(Guid.NewGuid());
            Assert.False(result);

        }
    }
}
