using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Extensions
{
    public class IdentityServiceExtension
    {
        
       public static IServiceCollection AddIdentityServiceExtensions(this IServiceCollection services,
       IConfiguration config)
       {
          

            return services;
       } 
    }
}