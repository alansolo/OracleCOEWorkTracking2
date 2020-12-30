using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OracleCOEWorkTracking.Data.Entities
{
    public class RequestOraclePreProdEnvironment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("RequestId")]
        public int RequestId { get; set; }
        public OraclePreProdEnvironment OraclePreProdEnvironment { get; set; }
        [ForeignKey("OraclePreProdEnvironmentId")]
        public int OraclePreProdEnvironmentId { get; set; }
    }
}
