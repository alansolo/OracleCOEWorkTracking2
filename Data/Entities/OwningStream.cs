﻿using OracleCOEWorkTracking.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OracleCOEWorkTracking.Data.Entities
{
    public class OwningStream : ITrack
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        //public Application AppName { get; set; }
        //[ForeignKey("AppId")]
        public int AppId { get; set; }
        public string Name { get; set; }
        public string dlEmailAddress { get; set; }
        // ITrack
        [MaxLength(50)]
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        [MaxLength(50)]
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool DeleteMark { get; set; }
    }
}
