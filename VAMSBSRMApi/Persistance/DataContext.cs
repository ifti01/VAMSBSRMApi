using Microsoft.EntityFrameworkCore;
using VAMSBSRMApi.Persistance.Models;

namespace VAMSBSRMApi.Persistance
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleCategory> VehicleCategories { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Vehicle>()
            .HasOne(v => v.Category)
            .WithMany(vc => vc.Vehicles)
            .HasForeignKey(v => v.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);

        }









    }
}
