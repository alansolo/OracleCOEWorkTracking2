using Microsoft.EntityFrameworkCore;
using OracleCOEWorkTracking.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OracleCOEWorkTracking.Data.Repositories
{
    public interface IDBContextRepository
    {
        bool SaveChanges();
        void AddEntity(object model);
        IEnumerable<Application> GetAppNames();
        IEnumerable<Request> GetRequests();
        IEnumerable<Region> GetRegions();
        IEnumerable<SBU> GetSBUs();
        IEnumerable<Module> GetModules();
        IEnumerable<OwningStream> GetOwningStreams();
        IEnumerable<ImpactedStream> GetImpactedStreams();
        IEnumerable<OwningSite> GetOwningSites();
        IEnumerable<BooleanDropDown> GetBooleanDropDowns();
        IEnumerable<DevelopmentTeam> GetDevelopmentTeams();
        IEnumerable<GateStatus> GetGateStatuses();
        IEnumerable<Gate> GetGates();
        IEnumerable<OraclePreProdEnvironment> GetOraclePreProdEnvironments();
        IEnumerable<Status> GetStatuses();
        IEnumerable<RequestView> GetRequestViews();
        IEnumerable<ApplicationAttribute> GetApplicationAttributes();

    }
}
