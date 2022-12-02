using la_mia_pizzeria_static.Models;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace la_mia_pizzeria_static.Data
{
    
    public class PizzeriaContext : DbContext
    {
        public DbSet<Pizza> Pizzas { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=db-pizzeria;Integrated Security=True;Encrypt=false;");
        }
    }
}
