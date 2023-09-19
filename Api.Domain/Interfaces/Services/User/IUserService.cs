using Api.Domain.DTOs.User;
using Api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Domain.Interfaces.Services.User
{
    public interface IUserService
    {
        Task<UserDTO> Get(Guid id);
        Task<IEnumerable<UserDTO>> GetAll();
        Task<UserDTOCreateResult> Post(UserDTO user);
        Task<UserDTOUpdateResult> Put(UserDTO user);
        Task<bool> Delete(Guid id);
    }
}
