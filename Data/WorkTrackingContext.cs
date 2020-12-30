using Microsoft.EntityFrameworkCore;
using OracleCOEWorkTracking.Data.Entities;
using OracleCOEWorkTracking.Data.Interfaces;
using System;
using Environment = OracleCOEWorkTracking.Data.Entities.EnvironmentSettings;

namespace OracleCOEWorkTracking.Data
{
    public partial class WorkTrackingContext : DbContext
    {
        public WorkTrackingContext(DbContextOptions<WorkTrackingContext> options) : base(options)
        {
            authenticatedUserNetworkId = "SYSTEM";
        }
        public string authenticatedUserNetworkId { get; set; }

        public DbSet<Application> Applications { get; set; }
        
        public DbSet<Request> Requests { get; set; }

        public DbSet<SBU> SBUs { get; set; }

        public DbSet<Region> Regions { get; set; }

        public DbSet<OwningSite> OwningSites { get; set; }

        public DbSet<OwningStream> OwningStreams { get; set; }
        public DbSet<ImpactedStream> ImpactedStreams { get; set; }

        public DbSet<RequestRegion> RequestRegions { get; set; }
        public DbSet<RequestAttachment> RequestAttachments { get; set; }

        public DbSet<RequestSBU> RequestSBUs { get; set; }
        public DbSet<RequestImpactedStream> RequestImpactedStreams { get; set; }
        public DbSet<RequestModule> RequestModules { get; set; }

        public DbSet<RequestDevelopmentTeam> RequestDevelopmentTeams { get; set; }
        public DbSet<RequestOraclePreProdEnvironment> RequestOraclePreProdEnvironments { get; set; }

        public DbSet<RequestView> RequestViews { get; set; }

        public DbSet<RequestNote> RequestNotes { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<GateStatus> GateStatuses { get; set; }
        public DbSet<Gate> Gates { get; set; }

        public DbSet<Module> Modules { get; set; }
        public DbSet<DevelopmentTeam> DevelopmentTeams { get; set; }
        public DbSet<OraclePreProdEnvironment> OraclePreProdEnvironments { get; set; }
        public DbSet<BooleanDropDown> BooleanDropDownValues { get; set; }
        public DbSet<EnvironmentSettings> EnvironmentSettings { get; set; }
        public DbSet<ApplicationAttribute> ApplicationAttributes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationRegion>().HasKey(ar => new { ar.AppId , ar.RegionId });
            modelBuilder.Entity<ApplicationOwningSite>().HasKey(ar => new { ar.AppId, ar.OwningSiteId });
            modelBuilder.Entity<ApplicationModule>().HasKey(ar => new { ar.AppId, ar.ModuleId  });

            //modelBuilder.Entity<ApplicationRegion>()
            //.HasOne(bc => bc.App )
            //    .WithMany(b => b.AppRegions)
            //    .HasForeignKey(bc => bc.AppId );

            modelBuilder.Entity<ApplicationRegion>()
                .HasOne(bc => bc.Region)
                .WithMany(c => c.AppRegions)
                .HasForeignKey(bc => bc.RegionId );

            modelBuilder.Entity<ApplicationOwningSite>()
            .HasOne(bc => bc.OwningSite)
            .WithMany(c => c.AppOwningSites)
            .HasForeignKey(bc => bc.OwningSiteId);


            modelBuilder.Entity<ApplicationModule>()
                .HasOne(bc => bc.Module)
                .WithMany(c => c.AppModules)
                .HasForeignKey(bc => bc.ModuleId);


        }



        public void SetMetadata()
        {
            foreach (var entityEntry in ChangeTracker.Entries())
            {
                if (entityEntry.Entity is ITrack trackable)
                {
                    var now = DateTime.Now;
                    var user = authenticatedUserNetworkId;
                    switch (entityEntry.State)
                    {
                        case EntityState.Added:
                            trackable.CreatedBy = user;
                            trackable.CreatedOn = now;
                            trackable.ModifiedBy = user;
                            trackable.ModifiedOn = now;
                            trackable.DeleteMark = false;
                            break;

                        case EntityState.Modified:
                            trackable.ModifiedBy = user;
                            trackable.ModifiedOn = now;
                            break;

                        case EntityState.Deleted:
                            trackable.ModifiedBy = user;
                            trackable.ModifiedOn = now;
                            trackable.DeleteMark = true;
                            entityEntry.State = EntityState.Modified;
                            break;
                    }
                }


            }
        }

        public override int SaveChanges()
        {
            SetMetadata();
            return base.SaveChanges();
        }

        public void SetCurrentUser(string user)
        {
            authenticatedUserNetworkId = user;
        }

    }
}
