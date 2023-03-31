using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.DAL.Context;
using TicketSystem.DAL.Models;
using TicketSystem.DAL.Repos.GenericRepo;

namespace TicketSystem.DAL.Repos.TicketRepo
{
    public class TicketsRepo : GenericRepo<Ticket>, ITicketsRepo
    {
        private readonly TicketContext _context;
        public TicketsRepo(TicketContext context):base(context)
        {
            _context = context;
        }
    }
}
