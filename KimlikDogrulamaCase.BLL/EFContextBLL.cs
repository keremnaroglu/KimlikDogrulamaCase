using KimlikDogrulamaCase.BLL.Abstract;
using KimlikDogrulamaCase.BLL.Concrete;
using KimlikDogrulamaCase.DAL;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace KimlikDogrulamaCase.BLL
{
    public static class EFContextBLL
    {
        public static void AddScopeBLL(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScopedDal();
            services.AddScoped<IUserService, UserService>();
        }
    }
}
