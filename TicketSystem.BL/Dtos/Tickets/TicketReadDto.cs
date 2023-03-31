using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.DAL.Models;

namespace TicketSystem.BL.Dtos.Tickets
{
    public class TicketReadDto
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public Severity? Severity { get; set; }
        public int DepartmentId { get; set; }
    }
}
