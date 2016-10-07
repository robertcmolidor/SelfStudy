using DisplayProbeResults.EntityModels;

namespace DisplayProbeResults
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ProbeContext : DbContext
    {
        public ProbeContext()
            : base("name=ProbeContext")
        {
        }

        public virtual DbSet<Profile> Profiles { get; set; }
        public virtual DbSet<Result> Results { get; set; }
        public virtual DbSet<CheckType> CheckTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Profile>()
                .Property(e => e.ModifiedDate)
                .HasPrecision(3);

            modelBuilder.Entity<Profile>()
                .Property(e => e.LastTimeChecked)
                .HasPrecision(3);

            modelBuilder.Entity<Profile>()
                .HasMany(e => e.Results)
                .WithRequired(e => e.Profile)
                .HasForeignKey(e => e.ProfileID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Profile>()
                .HasMany(e => e.Results1)
                .WithRequired(e => e.Profile1)
                .HasForeignKey(e => e.ProfileID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Profile>()
                .HasMany(e => e.Results2)
                .WithRequired(e => e.Profile2)
                .HasForeignKey(e => e.ProfileID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Result>()
                .Property(e => e.HourStamp)
                .HasPrecision(0);

            modelBuilder.Entity<Result>()
                .Property(e => e.TimeStamp)
                .HasPrecision(0);

            modelBuilder.Entity<Result>()
                .Property(e => e.LocationDescription)
                .IsUnicode(false);

            modelBuilder.Entity<Result>()
                .Property(e => e.Message)
                .IsUnicode(false);
        }
    }
}
