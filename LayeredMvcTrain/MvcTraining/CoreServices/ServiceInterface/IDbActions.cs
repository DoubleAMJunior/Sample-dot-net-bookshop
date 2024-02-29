using System;
using System.Collections.Generic;
using System.Text;

namespace Core.ServiceInterface
{
    public interface IDbActions<T>
    {
        /*public void finalizeChanges();*/
        public IEnumerable<T> get(Func<T, bool> selector);
        public void Delete(IEnumerable<T> coll);
        public void Insert(IEnumerable<T> coll);
        public void Update(IEnumerable<T> coll);
    }
}
