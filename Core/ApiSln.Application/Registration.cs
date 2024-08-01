using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ApiSln.Application
{
    public static  class Registration
    {
        public static void AddApplication(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly(); // isim hakları alır.

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly)); // bütün işlemnlere mediatr ı tanımlamış olduk.

        }

    }
}
