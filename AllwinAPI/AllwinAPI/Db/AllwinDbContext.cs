using AllwinAPI.Db.DbModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace AllwinAPI.Db
{
    public partial class AllwinDbContext : DbContext
    {
        private readonly IOptions<AppSettings> _settings;

        public AllwinDbContext()
        {
        }

        public AllwinDbContext(DbContextOptions<AllwinDbContext> options, IOptions<AppSettings> settings) : base(options)
        {
            _settings = settings;
        }

        public virtual DbSet<AllwinAPI.Db.DbModel.Route> Routes { get; set; }
        public virtual DbSet<Town> Towns { get; set; }
        public virtual DbSet<Stop> Stops { get; set; }
        public virtual DbSet<StopInRoute> StopInRoutes { get; set; }
        public virtual DbSet<Job> Jobs { get; set; }
        public virtual DbSet<JobStop> JobStops { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Finnish_Swedish_CI_AI");

            modelBuilder.Entity<AllwinAPI.Db.DbModel.Route>(entity =>
            {
                entity.HasKey(e => e.RouteId);
                entity.ToTable("Route");
            });
            modelBuilder.Entity<Town>(entity =>
            {
                entity.HasKey(e => e.TownId);
                entity.ToTable("Town");
                entity.HasMany(t => t.Routes).WithOne(r => r.Town);
            });
            modelBuilder.Entity<Stop>(entity =>
            {
                entity.HasKey(e => e.StopId);
                entity.ToTable("Stop");
                entity.HasOne(s => s.Town).WithMany(t => t.Stops);
            });
            modelBuilder.Entity<StopInRoute>(entity =>
            {
                entity.HasKey(e => new { e.StopId, e.RouteId });
                entity.ToTable("StopInRoute");
                entity.HasOne(s => s.Route).WithMany(r => r.Stops);
                entity.HasOne(s => s.Stop).WithMany(r => r.Routes);
            });

            modelBuilder.Entity<Job>(entity =>
            {
                entity.HasKey(e => e.JobId);
                entity.ToTable("Job");
                entity.HasOne(s => s.Route).WithMany(r => r.Jobs);
            });

            modelBuilder.Entity<JobStop>(entity =>
            {
                entity.HasKey(e => e.JobId);
                entity.ToTable("Job");
                entity.HasOne(s => s.Stop).WithMany(r => r.JobStops);
                entity.HasOne(s => s.Job).WithMany(r => r.JobStops);
            });

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
