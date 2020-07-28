using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DealForumAPI.DB
{
    public partial class DealForumlocalContext : DbContext
    {
        public DealForumlocalContext()
        {
        }

        public DealForumlocalContext(DbContextOptions<DealForumlocalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Commonsetting> Commonsetting { get; set; }
        public virtual DbSet<Menu> Menu { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Roleprivilege> Roleprivilege { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {    
                optionsBuilder.UseSqlServer("Server=192.168.43.91;Database=DealForum;Trusted_Connection=True;Integrated Security=False;uid=sa;pwd=Kaushal#123;MultipleActiveResultSets=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Menu>(entity =>
            {
                entity.Property(e => e.Action).IsUnicode(false);

                entity.Property(e => e.Controller).IsUnicode(false);

                entity.Property(e => e.Menuiconclass).IsUnicode(false);

                entity.Property(e => e.Menutitle).IsUnicode(false);

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Parentmenu)
                    .WithMany(p => p.InverseParentmenu)
                    .HasForeignKey(d => d.Parentmenuid)
                    .HasConstraintName("FK_menu_parentmenuid__menu_id");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Status).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Roleprivilege>(entity =>
            {
                entity.HasOne(d => d.Menu)
                    .WithMany(p => p.Roleprivilege)
                    .HasForeignKey(d => d.Menuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_roleprivilege_menuid__menu_id");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Roleprivilege)
                    .HasForeignKey(d => d.Roleid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_roleprivilege_roleid__role_id");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Emailverificationlink).IsFixedLength();

                entity.Property(e => e.Firstname).IsUnicode(false);

                entity.Property(e => e.Lastname).IsUnicode(false);

                entity.Property(e => e.Middlename).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
