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
            //modelBuilder.Entity<FsdAktivitet>(entity =>
            //{
            //    entity.HasKey(e => e.AktivitetId);
            //    entity.ToTable("FsdAktivitet");
            //});
            //modelBuilder.Entity<FsdFil>(entity =>
            //{
            //    entity.HasKey(e => e.FilId);
            //    entity.ToTable("FsdFil");
            //    entity.Property(e => e.Storlek)
            //      .HasColumnType("decimal(18, 0)");
            //});
            //modelBuilder.Entity<FbEventMediaList>(entity =>
            //{
            //    entity.ToView("FbEventMediaList");
            //    entity.HasNoKey();
            //});
            //modelBuilder.Entity<FbEventHanterat>(entity =>
            //{
            //    entity.HasKey(e => new { e.EventId, e.SystemNamn });
            //    entity.ToTable("FbEventHanterat");
            //});

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
