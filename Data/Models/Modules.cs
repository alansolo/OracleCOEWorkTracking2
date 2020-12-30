using System;
using System.Collections.Generic;

namespace OracleCOEWorkTracking.Data.Models
{
    public partial class Modules
    {
        public Modules()
        {
            ApplicationModule = new HashSet<ApplicationModule>();
            RequestModules = new HashSet<RequestModules>();
        }

        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool DeleteMark { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ApplicationModule> ApplicationModule { get; set; }
        public virtual ICollection<RequestModules> RequestModules { get; set; }
    }
}
