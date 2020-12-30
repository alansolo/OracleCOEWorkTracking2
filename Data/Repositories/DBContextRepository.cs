using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using OracleCOEWorkTracking.Data.Entities;

namespace OracleCOEWorkTracking.Data.Repositories
{
    public partial class DBContextRepository : IDBContextRepository
    {
        private readonly WorkTrackingContext _ctx;
               

        public DBContextRepository(WorkTrackingContext ctx)
        {

            _ctx = ctx;
            _ctx.authenticatedUserNetworkId = "SYSTEM";

        }

        public void SetCurrentUser(string user)
        {
            _ctx.authenticatedUserNetworkId = user;
        }

        public bool SaveChanges()
        {
            try
            {
                _ctx.SetMetadata();
                return _ctx.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public void AddEntity(object model)
        {
            _ctx.Add(model);
        }

        public IEnumerable<Application> GetAppNames()
        {
            return _ctx.Applications.Where(x => x.DeleteMark == false);
        }

        public IEnumerable<Request> GetRequests()
        {
            return _ctx.Requests.Where(x => x.DeleteMark == false);
        }

        public IEnumerable<Region> GetRegions()
        {
            return _ctx.Regions.Include(i=>i.AppRegions).Where(x => x.DeleteMark == false);
        }

        public IEnumerable<SBU> GetSBUs()
        {
            return _ctx.SBUs.Where(x => x.DeleteMark == false);
        }

        public IEnumerable<OwningSite> GetOwningSites()
        {
            return _ctx.OwningSites.Include(i=>i.AppOwningSites).Where(x => x.DeleteMark == false);
        }

        public IEnumerable<BooleanDropDown> GetBooleanDropDowns()
        {
            return _ctx.BooleanDropDownValues.ToList();
        }

        public IEnumerable<DevelopmentTeam> GetDevelopmentTeams()
        {
            return _ctx.DevelopmentTeams.Where(x => x.DeleteMark == false);
        }
        public IEnumerable<GateStatus> GetGateStatuses()
        {
            return _ctx.GateStatuses.Where(x => x.DeleteMark == false);
        }
        public IEnumerable<Gate> GetGates()
        {
            return _ctx.Gates.Where(x => x.DeleteMark == false);
        }
        public IEnumerable<OwningStream> GetOwningStreams()
        {
            return _ctx.OwningStreams.Where(x => x.DeleteMark == false);
        }
        public IEnumerable<ImpactedStream> GetImpactedStreams()
        {
            return _ctx.ImpactedStreams.Where(x => x.DeleteMark == false);
        }
        public IEnumerable<Module> GetModules()
        {
            return _ctx.Modules.Include(i=>i.AppModules).Where(x => x.DeleteMark == false);
        }
        public IEnumerable<OraclePreProdEnvironment> GetOraclePreProdEnvironments()
        {
            return _ctx.OraclePreProdEnvironments.Where(x => x.DeleteMark == false);
        }
        public IEnumerable<Status> GetStatuses()
        {
            return _ctx.Statuses.Where(x => x.DeleteMark == false);
        }
        public IEnumerable<RequestView> GetRequestViews()
        {
            return _ctx.RequestViews;
        }
        public IEnumerable<ApplicationAttribute> GetApplicationAttributes()
        {
            return _ctx.ApplicationAttributes.Where(x => x.DeleteMark == false);
        }
        public void OnModelCreating(ModelBuilder modelBuilder)
        {
            throw new NotImplementedException();
        }
    }
}
