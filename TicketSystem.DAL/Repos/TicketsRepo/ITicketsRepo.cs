using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.DAL.Models;
using TicketSystem.DAL.Repos.GenericRepo;

namespace TicketSystem.DAL.Repos.TicketRepo
{
    public interface ITicketsRepo : IGenericRepo<Ticket>
    {
        //To avoid copy & paste all crud functions, inherit from generic repo
    }
}
