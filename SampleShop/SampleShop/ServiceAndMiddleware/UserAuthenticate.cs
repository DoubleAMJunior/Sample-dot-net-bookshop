using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using SampleShop.Data;
using SampleShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleShop.ServiceAndMiddleware
{
    public class UserAuthenticate
    {
        private readonly RequestDelegate _next;
        private readonly IUserManager _manager;

        public UserAuthenticate(RequestDelegate next,IUserManager manager)
        {
            _next = next;
            _manager = manager;
        }

        public async Task Invoke(HttpContext context, ApplicationDbContext db)
        {
            if (context.Request.Cookies.ContainsKey("user_id"))
            {
                int id=Int32.Parse(context.Request.Cookies["user_id"]);
                User u = db.Users.SingleOrDefault(d => d.Id == id);
                if (u != null)
                {
                    _manager.setUser(u);
                }
                else
                {
                    _manager.setNoUser();
                }
            }
            else
            {
                _manager.setNoUser();
            }
            await _next(context);
        }
    }

    public static class UserAuthenticateExtension 
    {
        public static IApplicationBuilder CustomAuthenticate(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<UserAuthenticate>();
        }
    }
}
