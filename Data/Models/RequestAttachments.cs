using System;
using System.Collections.Generic;

namespace OracleCOEWorkTracking.Data.Models
{
    public partial class RequestAttachments
    {
        public int Id { get; set; }
        public byte[] Attachment { get; set; }
        public int RequestId { get; set; }
        public string FileName { get; set; }

        public virtual Requests Request { get; set; }
    }
}
