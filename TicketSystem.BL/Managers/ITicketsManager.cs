using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.BL.Dtos.Tickets;

namespace TicketSystem.BL.Managers
{
    public interface ITicketsManager
    {
        List<TicketReadDto> GetAll();
        void Add(TicketAddDto ticket);
    }
}
