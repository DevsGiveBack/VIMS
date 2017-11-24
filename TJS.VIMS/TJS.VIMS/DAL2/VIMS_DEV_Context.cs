namespace TJS.VIMS.DAL2
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class VIMS_DEV_Context : DbContext
    {
        public VIMS_DEV_Context()
            : base("name=VIMS_DEV_Context")
        {
        }

        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
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

            modelBuilder.Entity<Organization>()
                .Property(e => e.OrganizationName)
                .IsUnicode(false);

            modelBuilder.Entity<State>()
                .Property(e => e.StateName)
                .IsUnicode(false);

            modelBuilder.Entity<VolunteerClockInOutInfo>()
                .Property(e => e.ClockInProfilePhotoPath)
                .IsUnicode(false);

            modelBuilder.Entity<VolunteerClockInOutInfo>()
                .Property(e => e.ClockOutProfilePhotoPath)
                .IsUnicode(false);

            modelBuilder.Entity<VolunteerInfo>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<VolunteerInfo>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<VolunteerInfo>()
                .Property(e => e.UserName)
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

            modelBuilder.Entity<VolunteerProfileInfo>()
                .Property(e => e.CaseNumber)
                .IsUnicode(false);

            modelBuilder.Entity<VolunteerProfileInfo>()
                .Property(e => e.Skill)
                .IsUnicode(false);

            modelBuilder.Entity<VolunteerProfileInfo>()
                .Property(e => e.WorkInfo)
                .IsUnicode(false);

            modelBuilder.Entity<VolunteerProfilePhotoInfo>()
                .Property(e => e.VolunteerProfilePhotoPath)
                .IsUnicode(false);
        }
    }
}
