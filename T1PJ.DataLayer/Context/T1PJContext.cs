using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
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
            builder.ApplyConfiguration(new StudentClassConfig());

            builder.Entity<StudentClass>().HasKey(sc => new
            {
                sc.StudentId,
                sc.ClassId
            });
            builder.Entity<StudentClass>()
                .HasOne<Student>(sc => sc.Student)
                .WithMany(s => s.StudentClasses)
                .HasForeignKey(sc => sc.StudentId);


            builder.Entity<StudentClass>()
                .HasOne<Class>(sc => sc.Class)
                .WithMany(s => s.StudentClasses)
                .HasForeignKey(sc => sc.ClassId);
        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Class> Classes { get; set; }

        public DbSet<StudentClass> StudentClasses { get; set; }
    }
}
