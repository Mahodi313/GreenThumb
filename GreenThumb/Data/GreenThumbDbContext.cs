using GreenThumb.Models;
using Microsoft.EntityFrameworkCore;

namespace GreenThumb.Data
{
    public class GreenThumbDbContext : DbContext
    {
        public GreenThumbDbContext()
        {

        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<GardenModel> Gardens { get; set; }
        public DbSet<PlantModel> Plants { get; set; }
        public DbSet<InstructionModel> Instruction { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=GreenThumbDb;Trusted_Connection=True;");
        }
    }
}
