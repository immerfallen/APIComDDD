using Api.Domain.DTOs.User;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services.User;
using Api.Domain.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Service.Services.UserService
{
    public class UserService : IUserService
    {

        private IRepository<UserEntity> _repository;

        private readonly IMapper _mapper;

        public UserService(IRepository<UserEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<UserDTO> Get(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<UserDTO>(entity);
        }

        public async Task<IEnumerable<UserDTO>> GetAll()
        {
            var entities = await _repository.SelectAsync();
            return _mapper.Map<List<UserDTO>>(entities);
        }

        public async Task<UserDTOCreateResult> Post(UserDTO user)
        {
            var userModel = _mapper.Map<UserModel>(user);
            var modelEntity = _mapper.Map<UserEntity>(userModel);
            var result = await _repository.InsertAsync(modelEntity);
            return _mapper.Map<UserDTOCreateResult>(result);
        }

        public async Task<UserDTOUpdateResult> Put(UserDTO user)
        {
            var userModel = _mapper.Map<UserModel>(user);
            var modelEntity = _mapper.Map<UserEntity>(userModel);
            var result = await _repository.InsertAsync(modelEntity);
            return _mapper.Map<UserDTOUpdateResult>(result);
        }
    }
}
