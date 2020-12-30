using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OracleCOEWorkTracking.Data.Entities
{
    public class RequestDevelopmentTeam
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("RequestId")]
        public int RequestId { get; set; }
        public DevelopmentTeam DevelopmentTeam { get; set; }
        [ForeignKey("DevelopmentTeamId")]
        public int DevelopmentTeamId { get; set; }
    }
}
