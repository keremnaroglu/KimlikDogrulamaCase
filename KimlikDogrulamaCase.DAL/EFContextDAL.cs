using KimlikDogrulamaCase.DAL.Abstract;
using KimlikDogrulamaCase.DAL.Concrete;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KimlikDogrulamaCase.DAL
{
    public static class EFContextDAL
    {
        public static void AddScopedDal(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>()
                .AddScoped<IUserRepository, UserRepository>();
        }
    }
}
