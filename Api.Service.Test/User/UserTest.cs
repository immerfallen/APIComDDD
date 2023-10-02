using Api.Domain.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Service.Test.User
{
    public class UserTest
    {
        public static string NomeUsuario { get; set; }
        public static string EmailUsuario { get; set; }
        public static string NomeUsuarioAlterado { get; set; }
        public static string EmailUsuarioAlterado { get; set; }
        public static Guid IdUsuario { get; set; }
        public List<UserDTO> listaUserDto = new List<UserDTO>();
        public UserDTO userDto = new UserDTO();
        public UserDTOCreate userDTOCreate = new UserDTOCreate();
        public UserDTOCreateResult userDTOCreateResult = new UserDTOCreateResult();
        public UserDTOUpdate userDTOUpdate = new UserDTOUpdate();
        public UserDTOUpdateResult userDTOUpdateResult = new UserDTOUpdateResult();

        public UserTest()
        {
            IdUsuario = Guid.NewGuid();
            NomeUsuario = Faker.Name.FullName();
            EmailUsuario = Faker.Internet.Email();
            NomeUsuarioAlterado = Faker.Name.FullName();
            EmailUsuarioAlterado = Faker.Internet.Email();

            for (int i = 0; i < 10; i++)
            {
                var dto = new UserDTO()
                {
                    Id = Guid.NewGuid(),
                    Name = Faker.Name.FullName(),
                    Email = Faker.Internet.Email()
                };
                listaUserDto.Add(dto);
            }

            userDto = new UserDTO
            {
                Id = IdUsuario,
                Name = NomeUsuario,
                Email = EmailUsuario
            };

            userDTOCreate = new UserDTOCreate
            {                
                Name = NomeUsuario,
                Email = EmailUsuario
            };

            userDTOCreateResult = new UserDTOCreateResult
            {
                Id = IdUsuario,
                Name = NomeUsuario,
                Email = EmailUsuario,
                CreatedAt = DateTime.UtcNow
            };

            userDTOUpdate = new UserDTOUpdate
            {
                Id = IdUsuario,
                Name = NomeUsuarioAlterado,
                Email = EmailUsuarioAlterado
            };

            userDTOUpdateResult = new UserDTOUpdateResult
            {
                Id = IdUsuario,
                Name = NomeUsuarioAlterado,
                Email = EmailUsuarioAlterado,
                UpdatedAt = DateTime.UtcNow
            };

        }
    }
}
