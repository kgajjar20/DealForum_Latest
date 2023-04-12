using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DealForumAPI.DB
{
    public partial class DealForumContext : DbContext
    {
        public DealForumContext()
        {
        }

        public DealForumContext(DbContextOptions<DealForumContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Apiactiontracking> Apiactiontracking { get; set; }
        public virtual DbSet<Apiexceptiontracking> Apiexceptiontracking { get; set; }
        public virtual DbSet<Apilogtracking> Apilogtracking { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Commonsetting> Commonsetting { get; set; }
        public virtual DbSet<Coupon> Coupon { get; set; }
        public virtual DbSet<Couponcategory> Couponcategory { get; set; }
        public virtual DbSet<Deal> Deal { get; set; }
        public virtual DbSet<Dealcategory> Dealcategory { get; set; }
        public virtual DbSet<Forum> Forum { get; set; }
        public virtual DbSet<Menu> Menu { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Roleprivilege> Roleprivilege { get; set; }
        public virtual DbSet<Store> Store { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Usermapping> Usermapping { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Apiactiontracking>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Apiactiontracking)
                    .HasForeignKey(d => d.Userid)
                    .HasConstraintName("FK_apiactiontracking_userid__user_id");
            });

            modelBuilder.Entity<Apiexceptiontracking>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Apiexceptiontracking)
                    .HasForeignKey(d => d.Userid)
                    .HasConstraintName("FK_Apiexceptiontracking_userid__user_id");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Status).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Coupon>(entity =>
            {
                entity.Property(e => e.Status).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Couponcategory>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<Deal>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Dealcategory>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<Forum>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Forumname).IsUnicode(false);

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");
            });

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

            modelBuilder.Entity<Store>(entity =>
            {
                entity.Property(e => e.Status).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Firstname).IsUnicode(false);

                entity.Property(e => e.Lastname).IsUnicode(false);

                entity.Property(e => e.Middlename).IsUnicode(false);
            });

            modelBuilder.Entity<Usermapping>(entity =>
            {
                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Usermapping)
                    .HasForeignKey(d => d.Roleid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_usermapping_roleid__role_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Usermapping)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_usermapping_userid__user_id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
