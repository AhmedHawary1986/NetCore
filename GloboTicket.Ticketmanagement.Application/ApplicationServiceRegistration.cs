using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using AutoMapper;
using GloboTicket.Ticketmanagement.Application.Features.Events.Command.CreateEvent;

namespace GloboTicket.Ticketmanagement.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
           // services.AddMediatR(typeof(CreateEventCommandHandler));
            return services;
        }
    }
}
