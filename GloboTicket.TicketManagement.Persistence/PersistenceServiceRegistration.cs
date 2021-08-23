using GloboTicket.Ticketmanagement.Application.Persistence;
using GloboTicket.TicketManagement.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPresistenceServices(this IServiceCollection services , IConfiguration configuration)
        {
            services.AddDbContext<GloboTicketDBContext>(options => options.UseSqlServer(configuration.GetConnectionString("GloboTicketManagmentConnectionString")));

            services.AddScoped(typeof(IAsyncRepository<>),typeof(BaseRepository<>));

            services.AddScoped<IEventRepository, EventRepository>();

            

            services.AddScoped<ICategoryRepository, CategoryRepository>();

           

           services.AddScoped<IOrderRepository, OrderRepository>();

            services.AddScoped<OrderRepository>();

            return services;
        }
    }
}
