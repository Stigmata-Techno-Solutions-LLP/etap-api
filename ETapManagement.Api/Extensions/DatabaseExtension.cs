using ETapManagement.Domain;
using ETapManagement.ViewModel.Dto;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ETapManagement.Api.Extensions {

    public static class DatabaseExtension {

        public static IServiceCollection AddApplicationDbContext (this IServiceCollection services, AppSettings app) {

            services.AddDbContextPool<ETapManagementContext> (o => {
                o.UseSqlServer (app.DBConn);
            });

            return services;
        }
    }
}