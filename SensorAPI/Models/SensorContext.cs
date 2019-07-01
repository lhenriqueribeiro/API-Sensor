using Microsoft.EntityFrameworkCore;

namespace SensorAPI.Models

{
    public class SensorContext : DbContext
    {
        public SensorContext(DbContextOptions<SensorContext> options) : base(options){
        }

        public DbSet<SensorItem> SensorItems { get; set; }
    }
}
