using Api.Domain.DTOs.User;
using Api.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.CrossCutting.Mappings
{
    public class EntityToDTOProfile : Profile
    {
        public EntityToDTOProfile()
        {
            CreateMap<UserDTO, UserEntity>()
                .ReverseMap();

            CreateMap<UserDTOCreateResult, UserEntity>()
                .ReverseMap();

            CreateMap<UserDTOUpdateResult, UserEntity>()
                .ReverseMap();
        }
    }
}
