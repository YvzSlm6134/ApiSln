using ApiSln.Application.İnterface.Repositories;
using ApiSln.Application.İnterface.UnitOfWorks;
using ApiSln.Persistence.Context;
using ApiSln.Persistence.Repositories;
using ApiSln.Persistence.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSln.Persistence
{
    public static class Registration 
    {
        public static void AddPersistance(this IServiceCollection services, IConfiguration configuration ) 
        {
            services.AddDbContext<AppDbContext>(opt =>
            opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
            services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));


            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

    }
}

