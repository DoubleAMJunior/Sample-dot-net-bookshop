using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SampleShop.Models;
namespace SampleShop.ServiceAndMiddleware
{
    public interface IUserManager
    {
        void setUser(User u);
        User getUser();

        void setNoUser();

        bool isSigned();
    }
    public class UserManager : IUserManager
    {
        User currentUser;
        bool signedin;

        public User getUser()
        {
            return currentUser;
        }

        public bool isSigned()
        {
            return signedin;
        }

        public void setNoUser()
        {
            signedin = false;
        }

        public void setUser(User u)
        {
            currentUser = u;
            signedin = true;
        }
    }
}
