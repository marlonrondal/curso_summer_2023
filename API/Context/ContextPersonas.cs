using Entidades;
using Microsoft.EntityFrameworkCore;

namespace Context
{
    public class ContextPersonas : DbContext
    {
        public ContextPersonas(DbContextOptions<ContextPersonas> options) : base(options)
        {

        }

        public DbSet<Personas> personas { get; set; }
    }
}