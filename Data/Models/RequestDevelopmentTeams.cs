using System;
using System.Collections.Generic;

namespace OracleCOEWorkTracking.Data.Models
{
    public partial class RequestDevelopmentTeams
    {
        public int Id { get; set; }
        public int DevelopmentTeamId { get; set; }
        public int RequestId { get; set; }

        public virtual DevelopmentTeams DevelopmentTeam { get; set; }
        public virtual Requests Request { get; set; }
    }
}
