using Api.Domain.DTOs.User;
using Api.Domain.Entities;
using Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Api.Service.Test.AutoMapper
{
    public class UserMapper: BaseTestService
    {
        [Fact(DisplayName ="É possível mapear todos os modelos")]

        public void E_Possivel_Mapear_Modelos()
        {
            var model = new UserModel() {
            Id = Guid.NewGuid(),
            Name = Faker.Name.FullName(),
            Email = Faker.Internet.Email(),
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
            };

            var listaEntity = new List<UserEntity>();

            for (int i = 0; i < 10; i++)
            {
                var adicionar = new UserEntity
                {
                    Id = Guid.NewGuid(),
                    Name = Faker.Name.FullName(),
                    Email = Faker.Internet.Email(),
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };
                listaEntity.Add(adicionar);
            }

            //Model ->  Entity
            var entity = Mapper.Map<UserEntity>(model);
            Assert.Equal(entity.Id, model.Id);
            Assert.Equal(entity.Name, model.Name);
            Assert.Equal(entity.Email, model.Email);
            Assert.Equal(entity.CreatedAt, model.CreatedAt);
            Assert.Equal(entity.UpdatedAt, model.UpdatedAt);

            // Entity -> Dto
            var userDto = Mapper.Map<UserDTO>(entity);
            Assert.Equal(entity.Id, userDto.Id);
            Assert.Equal(entity.Name, userDto.Name);
            Assert.Equal(entity.Email, userDto.Email);
            Assert.Equal(entity.CreatedAt, userDto.CreatedAt);

            //List<UserEntity> -> List<UserDto>
            var listaDto = Mapper.Map<List<UserDTO>>(listaEntity);
            Assert.True(listaDto.Count() == listaEntity.Count());

            for (int i = 0; i < listaDto.Count(); i++)
            {
                Assert.Equal(listaDto[i].Id, listaEntity[i].Id);
                Assert.Equal(listaDto[i].Name, listaEntity[i].Name);
                Assert.Equal(listaDto[i].Email, listaEntity[i].Email);
                Assert.Equal(listaDto[i].CreatedAt, listaEntity[i].CreatedAt);               
            }

            //Entity -> UserDtoCreateResult
            var userDtoCreateResult = Mapper.Map<UserDTOCreateResult>(entity);
            Assert.Equal(entity.Id, userDtoCreateResult.Id);
            Assert.Equal(entity.Name, userDtoCreateResult.Name);
            Assert.Equal(entity.Email, userDtoCreateResult.Email);
            Assert.Equal(entity.CreatedAt, userDtoCreateResult.CreatedAt);

            //Entity -> UserDtoUpdateResult
            var userDtoUpdateResult = Mapper.Map<UserDTOUpdateResult>(entity);
            Assert.Equal(entity.Id, userDtoUpdateResult.Id);
            Assert.Equal(entity.Name, userDtoUpdateResult.Name);
            Assert.Equal(entity.Email, userDtoUpdateResult.Email);
            Assert.Equal(entity.UpdatedAt, userDtoUpdateResult.UpdatedAt);

            //Dto -> Model
            var userModel = Mapper.Map<UserModel>(userDto);
            Assert.Equal(userDto.Id, userModel.Id);
            Assert.Equal(userDto.Name, userModel.Name);
            Assert.Equal(userDto.Email, userModel.Email);
            Assert.Equal(userDto.CreatedAt, userModel.CreatedAt);


            //DtoCreate -> Model
            var userDtoCreate = Mapper.Map<UserDTOCreate>(userModel);            
            Assert.Equal(userDtoCreate.Name, userModel.Name);
            Assert.Equal(userDtoCreate.Email, userModel.Email);

            //DtoUpdate -> Model
            var userDtoUpdate = Mapper.Map<UserDTOUpdate>(userModel);
            Assert.Equal(userDtoUpdate.Id, userModel.Id);
            Assert.Equal(userDtoUpdate.Name, userModel.Name);
            Assert.Equal(userDtoUpdate.Email, userModel.Email);


        }
    }
}
