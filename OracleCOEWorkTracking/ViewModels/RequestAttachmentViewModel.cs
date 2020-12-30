using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OracleCOEWorkTracking.ViewModels
{
    public class RequestAttachmentViewModel
    {
        public int Id { get; set; }
        public int RequestId { get; set; }
        public string FileName { get; set; }

    }
}

