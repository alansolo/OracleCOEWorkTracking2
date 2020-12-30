using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OracleCOEWorkTracking.ViewModels
{
    public class UserViewModel
    {
        public string userId { get; set; }
        public string displayName { get; set; }
        public string email { get; set; }
        public string fullName { get { return displayName + " (" + userId + ")"; } }

        public Role Role { get; set; }
    }

    public enum Role
    {
        View,
        Add,
        Manage
    }
}
