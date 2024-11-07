using FazendaUrbanaApi.Models;
using FazendaUrbanaApi.Models.Cliente;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace FazendaUrbanaApi.Data
{
    public class AppDbContext : DbContext
    {
        
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { 
           
        }

        
        // Tables
        public DbSet<ClienteModel> Cliente { get; set; }

    }
}
