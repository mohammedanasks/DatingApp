using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.interfaces;
using API.Services;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions
{
    public static class ApplicationServiceExtentsion
    {
       public static IServiceCollection AddApplicationServices(this IServiceCollection services,
       IConfiguration config)
       {
            services.AddDbContext<DataContext>(opt=>{

            opt.UseSqlite(config.GetConnectionString("DefaultConnectionString"));
            });
            services.AddCors();
            services.AddScoped<ITokenService ,TokenService>();
            services.AddScoped<IuserRepository,UserRepository>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            return services;
       } 

       
    }
}