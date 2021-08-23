using GloboTicket.Ticketmanagement.Application.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.Ticketmanagement.Application.Contract.Infrastructure
{
    public interface IEmailService
    {
        public Task<bool> SendEmail(Email email);
    }
}
