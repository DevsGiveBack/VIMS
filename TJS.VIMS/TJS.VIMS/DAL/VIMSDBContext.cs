namespace TJS.VIMS
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
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Organization> Organizations { get; set; }
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<Volunteer> Volunteers { get; set; }
        public virtual DbSet<VolunteerPhoto> VolunteerPhotoes { get; set; }
        public virtual DbSet<VolunteerProfile> VolunteerProfiles { get; set; }
        public virtual DbSet<VolunteerTimeClock> VolunteerTimeClocks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>()
                .Property(e => e.Name)
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
                .HasMany(e => e.VolunteerPhotoes)
                .WithOptional(e => e.Employee)
                .HasForeignKey(e => e.CreatedBy);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.VolunteerProfiles)
                .WithOptional(e => e.Employee)
                .HasForeignKey(e => e.CreatedBy);

            modelBuilder.Entity<Location>()
                .Property(e => e.Name)
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
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<State>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Volunteer>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Volunteer>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Volunteer>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<Volunteer>()
                .Property(e => e.Address1)
                .IsUnicode(false);

            modelBuilder.Entity<Volunteer>()
                .Property(e => e.Address2)
                .IsUnicode(false);

            modelBuilder.Entity<Volunteer>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<Volunteer>()
                .Property(e => e.ZipCode)
                .IsUnicode(false);

            modelBuilder.Entity<Volunteer>()
                .Property(e => e.PhoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Volunteer>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Volunteer>()
                .Property(e => e.Emrgncy_Cntct_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Volunteer>()
                .Property(e => e.Emrgncy_Cntct_Phn)
                .IsUnicode(false);

            modelBuilder.Entity<VolunteerPhoto>()
                .Property(e => e.Path)
                .IsUnicode(false);

            modelBuilder.Entity<VolunteerProfile>()
                .Property(e => e.CaseNumber)
                .IsUnicode(false);

            modelBuilder.Entity<VolunteerProfile>()
                .Property(e => e.Skill)
                .IsUnicode(false);

            modelBuilder.Entity<VolunteerProfile>()
                .Property(e => e.WorkInfo)
                .IsUnicode(false);

            modelBuilder.Entity<VolunteerTimeClock>()
                .Property(e => e.ClockInPhoto)
                .IsUnicode(false);

            modelBuilder.Entity<VolunteerTimeClock>()
                .Property(e => e.ClockOutPhoto)
                .IsUnicode(false);
        }
    }
}
