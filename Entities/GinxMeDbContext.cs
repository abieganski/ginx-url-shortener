using Microsoft.EntityFrameworkCore;

namespace ginx.me.Entities
{
    public class GinxMeDbContext : DbContext
    {
        public GinxMeDbContext(DbContextOptions<GinxMeDbContext> options)
            : base(options)
        { }

       protected override void OnModelCreating(ModelBuilder builder)
       {
            base.OnModelCreating(builder);

            builder.Entity<ShortenedUrlInstance>()
                .Property(c => c.WhenCreated)
                .HasDefaultValueSql("getdate()");

            builder.Entity<ShortenedUrlInstance>()
                .HasIndex(b => b.UniqueId)
                .IsUnique();
       }

       public DbSet<ShortenedUrlInstance> ShortenedUrlInstances { get; set; }
    }
}