using Api.Domain.DTOs.User;
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
    public class QuandoForExecutadoGetAll : UserTest
    {
        private IUserService _userService;
        private Mock<IUserService> _userServiceMock;

        [Fact(DisplayName = "É possivel executar o método GETALL.")]
        public async Task E_Possivel_Executar_GetAll()
        {
            _userServiceMock = new Mock<IUserService>();
            _userServiceMock.Setup(m => m.GetAll()).ReturnsAsync(listaUserDto);
            _userService = _userServiceMock.Object;

            var result = await _userService.GetAll();
            Assert.NotNull(result);
            Assert.True(result.Count() == 10);

            var _listResult = new List<UserDTO>();

            _userServiceMock = new Mock<IUserService>();
            _userServiceMock.Setup(m => m.GetAll()).ReturnsAsync(_listResult.AsEnumerable);
            _userService = _userServiceMock.Object;

            var _resultEmpty = await _userService.GetAll();
            Assert.Empty(_resultEmpty);
            Assert.True(_resultEmpty.Count() == 0);
        }
    }
}
