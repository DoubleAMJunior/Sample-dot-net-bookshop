using System;
using System.Collections.Generic;
using System.Linq;

namespace ApplicationServices.InterfaceImplimentations
{
    class UserModelDbActions  : ServiceInterface.IUserModelDbActions
    {
        public Core.ServiceInterface.IDbActions<Core.Entities.User> _context;
        public UserMapper _mapper;

        public UserModelDbActions(Core.ServiceInterface.IDbActions<Core.Entities.User> c)
        {
            _context = c;
            _mapper = new UserMapper();
        }

        public void addOrInsertUser(Models.User u)
        {
            var du=_mapper.MapUserToEntity(u);
            
            var found = _context.get(s => s.Email == du.Email).ToList();
            if (found.Count==0)
            {
                List<Core.Entities.User> o = new List<Core.Entities.User>();
                o.Add(du);
                _context.Insert(o);
            }
            else
                _mapper.mapEntityToEntity(du, found[0]);
                
        }

        public IEnumerable<Models.User> getUserEntity(Func<Core.Entities.User, bool> selector)
        {
            List<Core.Entities.User> foundDbUsers =_context.get(selector).ToList();
            List<Models.User> foundUsers=new List<Models.User>();
            foreach(var dbu in foundDbUsers)
            {
                foundUsers.Add(_mapper.MapEntityToUser(dbu));
            }
            return foundUsers;
        }

        public void Insertnew(IEnumerable<Models.User> coll)
        {
            var dbUsers = _context.get((u)=>true).ToList();
            var uiUsers = convertListtoEntity(coll);
            var e = uiUsers.Except(dbUsers).ToList();
            _context.Insert(e);
        }

        public void RemoveMissing(IEnumerable<Models.User> coll)
        {
            var dbUsers = _context.get((u)=>true).ToList();
            var uiUsers = convertListtoEntity(coll);
            var d = dbUsers.Except(uiUsers).ToList();
            _context.Delete(d);
        }
        public void  bulkUpdate(IEnumerable<Models.User> coll)
        {
            var dbUsers = _context.get(u=>true).ToList();
            var uiUsers = convertListtoEntity(coll);
            dbUsers.Join(uiUsers, d => d.Email, u => u.Email, (o, u) => new { o, u }).ToList().ForEach(i => {_mapper.mapEntityToEntity(i.u, i.o); });
        }
        List<Core.Entities.User> convertListtoEntity(IEnumerable<Models.User> coll)
        {
            List<Core.Entities.User> uiUsers = new List<Core.Entities.User>();
            foreach (Models.User u in coll)
            {
                if (u.email != null)
                {
                    uiUsers.Add(_mapper.MapUserToEntity(u));
                }
            }
            return uiUsers;
        }

    }
}
