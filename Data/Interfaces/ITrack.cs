using System;
using System.Collections.Generic;
using System.Text;

namespace OracleCOEWorkTracking.Data.Interfaces
{
    public interface ITrack
    {
        int Id { get; set; }
        string CreatedBy { get; set; }
        DateTime CreatedOn { get; set; }
        string ModifiedBy { get; set; }
        DateTime? ModifiedOn { get; set; }
        bool DeleteMark { get; set; }
    }

}
