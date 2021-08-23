using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.Ticketmanagement.Application.Contract.Persistence
{
    public interface ILoggedinUserService
    {
        public string UserId { get; set; }
    }
}
