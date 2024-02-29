using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace ApplicationServices.ServiceInterface
{
    public static class Injector
    {
        public static void AddAppliactionServices(this IServiceCollection service)
        {
            service.AddScoped<IUserMapper, InterfaceImplimentations.UserMapper>();
            service.AddScoped<IUserModelDbActions, InterfaceImplimentations.UserModelDbActions>();
        }
    }
}
