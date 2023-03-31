using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem.DAL.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        // 1 to M Relation
        public ICollection<Ticket> Tickets { get; set; } = new HashSet<Ticket>();
    }
}
