using ApplicationServices.Models;
using ApplicationServices.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Text;
namespace ApplicationServices.InterfaceImplimentations
{
    class UserMapper : IUserMapper
    {
        private AutoMapper.Mapper mapper;
        private AutoMapper.Mapper reverseMapper;
        private AutoMapper.Mapper entityMapper;
        private AutoMapper.Mapper searchResultMapper;

        public UserMapper()
        {
            var mapConfig = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<Models.User, Core.Entities.User>().BeforeMap((src, dest) => {
                dest.addresses = new List<Core.Entities.Address>();
                dest.addresses.Add(new Core.Entities.Address(src.address1));
                dest.addresses.Add(new Core.Entities.Address(src.address2));
            }));
            
            var reverseCofig = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<Core.Entities.User, Models.User>().BeforeMap((src, dest) => {
                // DataManager.Entities.Address[] list = src.addresses.ToArray();
                //dest.address1 = list[0].address;
                //dest.address2 = list[1].address;
            }));
            var entityConfig = new AutoMapper.MapperConfiguration(cfg=> cfg.CreateMap<Core.Entities.User,Core.Entities.User>());
            var searchConfig = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<Models.User,Models.UserResultModel>());
            mapper = new AutoMapper.Mapper(mapConfig);
            reverseMapper = new AutoMapper.Mapper(reverseCofig);
            entityMapper = new AutoMapper.Mapper(entityConfig);
            searchResultMapper = new AutoMapper.Mapper(searchConfig);
        }

        public void mapEntityToEntity(Core.Entities.User u, Core.Entities.User o)
        {
            entityMapper.Map<Core.Entities.User, Core.Entities.User>(u,o);
        }

        public Models.User MapEntityToUser(Core.Entities.User u)
        {
            return reverseMapper.Map<Models.User>(u);
        }

        public Core.Entities.User MapUserToEntity(Models.User u)
        {
            return mapper.Map<Core.Entities.User>(u);
        }

        public UserResultModel mapUserToSearchModel(User u)
        {
            return searchResultMapper.Map<Models.UserResultModel>(u);
        }
    }
}