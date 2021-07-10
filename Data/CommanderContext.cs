using Comandos.Models;
using Microsoft.EntityFrameworkCore;

namespace Comandos.Data
{
    public class CommanderContext : DbContext
    {
        public CommanderContext(DbContextOptions<CommanderContext> options) : base(options) {

        }

        public DbSet<Command> Commands {get; set;}
        public DbSet<Platform> Platforms {get; set;}
        
    }
}