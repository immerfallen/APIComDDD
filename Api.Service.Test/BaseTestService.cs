using Api.CrossCutting.Mappings;
using AutoMapper;
using System;
using Xunit;

namespace Api.Service.Test
{
    public class BaseTestService
    {
       
        public IMapper Mapper { get; set; }
        public BaseTestService()
        {
            Mapper = new AutoMapperFixture().GetMapper();
        }

        public class AutoMapperFixture : IDisposable
        {
            public IMapper GetMapper()
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile(new ModelToEntityProfile());
                    cfg.AddProfile(new DTOToModelProfile());
                    cfg.AddProfile(new EntityToDTOProfile());
                });
                return config.CreateMapper();
            }
            public void Dispose()
            {
               
            }
        }
    }
}
