using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.Ticketmanagement.Application.Execeptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string name, object key): base($"({name}{key}) not found")
        {

        }
    }
}
