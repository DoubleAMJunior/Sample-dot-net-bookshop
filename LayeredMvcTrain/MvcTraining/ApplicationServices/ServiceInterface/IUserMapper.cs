using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationServices.ServiceInterface
{
    public interface IUserMapper
    {
        public Core.Entities.User MapUserToEntity(Models.User u);
        public Models.User MapEntityToUser(Core.Entities.User u);
        public void  mapEntityToEntity(Core.Entities.User u,Core.Entities.User o);

        public Models.UserResultModel mapUserToSearchModel(Models.User u);
    }
}
