using GloboTicket.Ticketmanagement.Application.Contract.Infrastructure;
using GloboTicket.Ticketmanagement.Application.Model;
using GloboTicket.TicketManagement.Infrastructure.FileExporter;
using GloboTicket.TicketManagement.Infrastructure.Mail;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices (this IServiceCollection services, IConfiguration configuration )
        {
            services.Configure<EmailSetting>(configuration.GetSection("EmailSetting"));
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<ICSVExporter, CSVExporter>();
            return services;
        }
    }
}
