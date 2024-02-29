using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationServices.ServiceInterface
{
    public interface IUserModelDbActions
    {
        public void addOrInsertUser(Models.User u);

        public IEnumerable<Models.User> getUserEntity(Func<Core.Entities.User, bool> selector);
        public void Insertnew(IEnumerable<Models.User> coll);

        public void RemoveMissing(IEnumerable<Models.User> coll);
        public void bulkUpdate(IEnumerable<Models.User> coll);
    }
}
