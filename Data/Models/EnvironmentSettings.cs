using System;
using System.Collections.Generic;

namespace OracleCOEWorkTracking.Data.Models
{
    public partial class EnvironmentSettings
    {
        public int Id { get; set; }
        public string EnvironmentName { get; set; }
        public string ManageRequestsAdgroup { get; set; }
        public string AddRequestsAdgroup { get; set; }
    }
}
