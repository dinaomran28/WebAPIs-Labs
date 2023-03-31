using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketSystem.BL.Dtos.Tickets;
using TicketSystem.BL.Managers;

namespace TicketSystem.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketsManager _ticketsManager;
        public TicketsController(ITicketsManager ticketsManager)
        {
            _ticketsManager = ticketsManager;
        }
        [HttpGet]
        public ActionResult<List<TicketReadDto>> GetAll()
        {
            return _ticketsManager.GetAll();
        }
        [HttpPost]
        public ActionResult Add(TicketAddDto ticket)
        {
            _ticketsManager.Add(ticket);
            return NoContent();
        }
    }
}
