using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.BL.Dtos.Tickets;
using TicketSystem.DAL.Models;
using TicketSystem.DAL.Repos.TicketRepo;

namespace TicketSystem.BL.Managers
{
    public class TicketsManager : ITicketsManager
    {
        private readonly ITicketsRepo _ticketsRepo;
        public TicketsManager(ITicketsRepo ticketsRepo)
        {
            _ticketsRepo = ticketsRepo;
        }
        public List<TicketReadDto> GetAll()
        {
            List<Ticket> ticketsFromDb = _ticketsRepo.GetAll();
            return ticketsFromDb
                .Select(t => new TicketReadDto
                {
                    Id = t.Id,
                    Description = t.Description,
                    Severity = t.Severity,
                    DepartmentId = t.DepartmentId
                }).ToList();
        }
        public void Add(TicketAddDto ticketDto)
        {
            Ticket ticketToAdd = new Ticket
            {
                Description = ticketDto.Description,
                DepartmentId = ticketDto.DepartmentId
            };
            _ticketsRepo.Add(ticketToAdd);
            _ticketsRepo.SaveChanges();
        }

    }
}
