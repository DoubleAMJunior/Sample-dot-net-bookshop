using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataManager.Actions
{
    class UserEntityRepository : Core.ServiceInterface.IDbActions<User>
    {
        Data.AppDbContext _context;
        public UserEntityRepository(Data.AppDbContext c)
        {
            _context = c;
        }

        public void Delete(IEnumerable<User> coll)
        {
            _context.Users.RemoveRange(coll);
            _context.SaveChanges();
        }

        public IEnumerable<User> get(Func<User, bool> selector)
        {
            return _context.Users.Where(selector);
            _context.SaveChanges();
        }

        public void Insert(IEnumerable<User> coll)
        {
            _context.Users.AddRange(coll);
            _context.SaveChanges();
        }

        public void Update(IEnumerable<User> coll)
        {
            _context.Users.UpdateRange(coll);
            _context.SaveChanges();
        }
    }
}
