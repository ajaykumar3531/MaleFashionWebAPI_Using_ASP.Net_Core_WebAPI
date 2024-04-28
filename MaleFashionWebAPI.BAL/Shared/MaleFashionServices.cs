using MaleFashion_WebAPI.BAL.Shared.Auth;
using MaleFashion_WebAPI.BAL.UserMgmt.Contracts;
using MaleFashion_WebAPI.BAL.UserMgmt.Services;
using MaleFashoin_WebAPI.DAL.Generic_Repos;
using MaleFashoin_WebAPI.DAL.MaleFashionDB;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaleFashion_WebAPI.BAL.Shared
{
    public static class MaleFashionServices
    {
        public static IServiceCollection AddMale(this IServiceCollection services)
        {
            #region Db_Context
            services.AddDbContext<MaleFashionDbContext>();
            #endregion

            #region Repos
            services.AddScoped<IRepository<MaleFashionDbContext, User>, Repository<MaleFashionDbContext, User>>();
            services.AddScoped<IRepository<MaleFashionDbContext, Role>, Repository<MaleFashionDbContext, Role>>();
            services.AddScoped<IRepository<MaleFashionDbContext, Cart>, Repository<MaleFashionDbContext, Cart>>();
            services.AddScoped<IRepository<MaleFashionDbContext, Contact>, Repository<MaleFashionDbContext, Contact>>();
            services.AddScoped<IRepository<MaleFashionDbContext, Address>, Repository<MaleFashionDbContext, Address>>();
            #endregion

            #region BusinessRepos  
            services.AddScoped<IUserMgmtService,UserMgmtService>();
            #endregion

            #region Authentication

            #endregion

            #region Other
            services.AddScoped<ITokenManager, TokenManager>();
            #endregion

            return services;
        }
    }
}
