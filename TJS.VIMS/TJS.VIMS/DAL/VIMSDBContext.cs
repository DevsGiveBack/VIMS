namespace TJS.VIMS.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class VIMSDBContext : DbContext
    {
        public VIMSDBContext()
            : base("name=VIMSDBContext")
        {
        }

        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Organization> Organizations { get; set; }
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<VolunteerClockInOutInfo> VolunteerClockInOutInfoes { get; set; }
        public virtual DbSet<VolunteerInfo> VolunteerInfoes { get; set; }
        public virtual DbSet<VolunteerProfileInfo> VolunteerProfileInfoes { get; set; }
        public virtual DbSet<VolunteerProfilePhotoInfo> VolunteerProfilePhotoInfoes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>()
                .Property(e => e.CountryName)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.UpdatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Countries)
                .WithOptional(e => e.Employee)
                .HasForeignKey(e => e.CreatedBy);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Locations)
                .WithOptional(e => e.Employee)
                .HasForeignKey(e => e.CreatedBy);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Organizations)
                .WithOptional(e => e.Employee)
                .HasForeignKey(e => e.CreatedBy);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Organizations1)
                .WithOptional(e => e.Employee1)
                .HasForeignKey(e => e.UpdatedBy);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.States)
                .WithOptional(e => e.Employee)
                .HasForeignKey(e => e.CreatedBy);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.VolunteerProfileInfoes)
                .WithOptional(e => e.Employee)
                .HasForeignKey(e => e.CreatedBy);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.VolunteerProfilePhotoInfoes)
                .WithOptional(e => e.Employee)
                .HasForeignKey(e => e.CreatedBy);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.VolunteerClockInOutInfoes)
                .WithOptional(e => e.Employee)
                .HasForeignKey(e => e.CreatedBy);

            modelBuilder.Entity<Location>()
                .Property(e => e.LocationName)
                .IsUnicode(false);

            modelBuilder.Entity<Location>()
                .Property(e => e.Address1)
                .IsUnicode(false);

            modelBuilder.Entity<Location>()
                .Property(e => e.Address2)
                .IsUnicode(false);

            modelBuilder.Entity<Location>()
                .Property(e => e.ZipCode)
                .IsUnicode(false);

            modelBuilder.Entity<Location>()
                .Property(e => e.Notes)
                .IsUnicode(false);

            modelBuilder.Entity<Location>()
                .HasMany(e => e.VolunteerClockInOutInfoes)
                .WithOptional(e => e.Location)
                .HasForeignKey(e => e.ClockInOutLocationId);

            modelBuilder.Entity<Organization>()
                .Property(e => e.OrganizationName)
                .IsUnicode(false);

            modelBuilder.Entity<State>()
                .Property(e => e.StateName)
                .IsUnicode(false);

            modelBuilder.Entity<VolunteerInfo>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<VolunteerInfo>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<VolunteerInfo>()
                .Property(e => e.Address1)
                .IsUnicode(false);

            modelBuilder.Entity<VolunteerInfo>()
                .Property(e => e.Address2)
                .IsUnicode(false);

            modelBuilder.Entity<VolunteerInfo>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<VolunteerInfo>()
                .Property(e => e.ZipCode)
                .IsUnicode(false);

            modelBuilder.Entity<VolunteerInfo>()
                .Property(e => e.PhoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<VolunteerInfo>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<VolunteerInfo>()
                .Property(e => e.Emrgncy_Cntct_Name)
                .IsUnicode(false);

            modelBuilder.Entity<VolunteerInfo>()
                .Property(e => e.Emrgncy_Cntct_Phn)
                .IsUnicode(false);

            modelBuilder.Entity<VolunteerInfo>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<VolunteerInfo>()
                .Property(e => e.UpdatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<VolunteerProfileInfo>()
                .Property(e => e.CaseNumber)
                .IsUnicode(false);

            modelBuilder.Entity<VolunteerProfileInfo>()
                .Property(e => e.Skill)
                .IsUnicode(false);

            modelBuilder.Entity<VolunteerProfileInfo>()
                .Property(e => e.MedicalInfo)
                .IsUnicode(false);

            modelBuilder.Entity<VolunteerProfileInfo>()
                .Property(e => e.UpdatedBy)
                .IsUnicode(false);
        }
    }
}
