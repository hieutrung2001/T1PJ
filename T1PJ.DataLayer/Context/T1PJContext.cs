using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using T1PJ.DataLayer.Config;
using T1PJ.DataLayer.Entity;
using T1PJ.DataLayer.Entity.Identity;

namespace T1PJ.DataLayer.Context
{
    public class T1PJContext : IdentityDbContext<User>
    {
        public T1PJContext (DbContextOptions<T1PJContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new ClassConfig());
            builder.ApplyConfiguration(new StudentConfig());
            builder.Entity<Student>()
                .HasMany(s => s.Classes)
                .WithMany(c => c.Students)
                .UsingEntity(j => j.ToTable("StudentClass"));
        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Class> Classes { get; set; }
    }
}
