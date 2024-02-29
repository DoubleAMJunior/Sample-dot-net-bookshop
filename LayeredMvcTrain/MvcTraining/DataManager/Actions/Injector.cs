using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataManager.Actions
{
    public static class Injector
    {
        public static void AddADataManagerServices(this IServiceCollection service)
        {
            service.AddScoped<Core.ServiceInterface.IDbActions<Core.Entities.User>,UserEntityRepository>();
        }
    }
}
