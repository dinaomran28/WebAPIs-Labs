using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TicketSystem.DAL.Models;

namespace TicketSystem.DAL.Context
{
    public class TicketContext : DbContext
    {
        public DbSet<Ticket> Tickets => Set<Ticket>(); //Give it class Ticket to get u the Table Data
        public DbSet<Developer> Developers => Set<Developer>();
        public DbSet<Department> Departments => Set<Department>();

        public TicketContext(DbContextOptions<TicketContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Seeding Tickets
            var tickets = JsonSerializer.Deserialize<List<Ticket>>("""[{"Id":1,"Description":"Cumque unde dolores placeat reprehenderit et porro minima sit.","Severity":0,"EstimationCost":100,"DepartmentId":1},{"Id":2,"Description":"reprehenderit et porro minima sit.","Severity":1,"EstimationCost":200,"DepartmentId":2}]""") ?? new();
            #endregion

            #region Seeding Departments
            var departments = JsonSerializer.Deserialize<List<Department>>("""[{"Id":1,"Name":"Automotive \u0026 Baby"},{"Id":2,"Name":"Beauty \u0026 Health"},{"Id":3,"Name":"Electronics"}]""") ?? new();
            #endregion

            #region Seeding Developers
            var developers = JsonSerializer.Deserialize<List<Developer>>("""[{"Id":1,"Name":"Angela McClure"},{"Id":2,"Name":"Jamie Berge"},{"Id":3,"Name":"Freddie Johnson"}]""") ?? new();
            #endregion

            modelBuilder.Entity<Ticket>().HasData(tickets);
            modelBuilder.Entity<Department>().HasData(departments);
            modelBuilder.Entity<Developer>().HasData(developers);
        }
    }
}
