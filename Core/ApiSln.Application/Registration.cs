using ApiSln.Application.Bases;
using ApiSln.Application.Beheviors;
using ApiSln.Application.Exceptions;
using ApiSln.Application.Features.Products.Rules;
using FluentValidation;
using MediatR;
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

            services.AddTransient<ExceptionMiddleware>();
            
            services.AddRulseFromAssemblyContaining(assembly, typeof(BaseRules));

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly)); // bütün işlemnlere mediatr ı tanımlamış olduk.

            services.AddValidatorsFromAssembly(assembly);
            ValidatorOptions.Global.LanguageManager.Culture = new System.Globalization.CultureInfo("tr");

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(FluentValidationBehevior<,>));


        }

        private static IServiceCollection AddRulseFromAssemblyContaining(this IServiceCollection services, Assembly assembly, Type type)
        {
            var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t ).ToList();
            foreach (var item in types)
                services.AddTransient(item);
            return services;
            
        }

    }
}
