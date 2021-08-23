using GloboTicket.Ticketmanagement.Application.Contract.Infrastructure;
using GloboTicket.Ticketmanagement.Application.Model;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Infrastructure.Mail
{
    public class EmailService : IEmailService
    {
        private EmailSetting _emailSetting { get; }

        public EmailService(IOptions<EmailSetting> EmailSetting)
        {
            _emailSetting = EmailSetting.Value;
        }

        public async Task<bool> SendEmail(Email email)
        {
            var client = new SendGridClient(_emailSetting.ApiKey);
            var From = new EmailAddress() { Email = _emailSetting.FromAddress, Name = _emailSetting.FromName };
            var To = new EmailAddress() { Email = email.To };
            var SendGridMessage = MailHelper.CreateSingleEmail(From, To, email.Subject, email.Body, email.Body);

            var response = await client.SendEmailAsync(SendGridMessage);

            if(response.StatusCode== System.Net.HttpStatusCode.Accepted || response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
