using OracleCOEWorkTracking.ViewModels;
using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;

namespace OracleCOEWorkTracking.Controllers.Helpers
{
    public class Auth
    {
        public static UserViewModel GetCurrentUser(string IdentityName)
        {
            var uvm = new UserViewModel();
            using (PrincipalContext context = new PrincipalContext(ContextType.Domain))
            {
                using (UserPrincipal user
                        = UserPrincipal.FindByIdentity(context, IdentityName))
                {
                    if (user != null)
                    {
                        uvm.displayName = user.DisplayName;
                        uvm.userId = user.SamAccountName;
                        uvm.email = user.EmailAddress;
                    }
                }
            }
            return uvm;
        }

        public static UserViewModel GetUserFromFullName(string fullName)
        {
            var uvm = new UserViewModel();
            try
            {
                using (PrincipalContext context = new PrincipalContext(ContextType.Domain))
                {
                    using (UserPrincipal user
                            = UserPrincipal.FindByIdentity(context, fullName.Split('(', ')')[1]))
                    {
                        if (user != null)
                        {
                            uvm.displayName = user.DisplayName;
                            uvm.userId = user.SamAccountName;
                            uvm.email = user.EmailAddress;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                uvm = new UserViewModel();
            }

            return uvm;
        }


    }

    public static class Extensions
    {
        public static string GetDomain(this IIdentity identity)
        {
            string s = identity.Name;
            int stop = s.IndexOf("\\");
            return (stop > -1) ? s.Substring(0, stop) : string.Empty;
        }

        public static string GetLogin(this IIdentity identity)
        {
            string s = identity.Name;
            int stop = s.IndexOf("\\");
            return (stop > -1) ? s.Substring(stop + 1, s.Length - stop - 1) : string.Empty;
        }
    }
}
