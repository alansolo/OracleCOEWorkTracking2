using OracleCOEWorkTracking.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OracleCOEWorkTracking.Data.Entities
{
    public class EnvironmentSettings
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int Id { get; set; }
        public string EnvironmentName { get; set; }
        public string AddRequestsADGroup { get; set; }
        public string ManageRequestsADGroup { get; set; }

    }
}
