using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem.DAL.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        [Required]
        public string Description { get; set; } = string.Empty;
        public Severity? Severity { get; set; }
        public int EstimationCost { get; set; }

        // M to M Relation
        public ICollection<Developer> Developers { get; set; } = new HashSet<Developer>();
        // 1 to M Relation
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
    }
    public enum Severity
    {
        Low,
        Medium,
        High
    }
}
