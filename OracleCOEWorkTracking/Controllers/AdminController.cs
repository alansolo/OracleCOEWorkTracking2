using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OracleCOEWorkTracking.Resources;
using Microsoft.AspNetCore.Mvc;
using OracleCOEWorkTracking.Controllers.Helpers;
using OracleCOEWorkTracking.Data;
using OracleCOEWorkTracking.Data.Entities;
using OracleCOEWorkTracking.Data.Repositories;
using OracleCOEWorkTracking.ViewModels;
using System.DirectoryServices.AccountManagement;
using System.Security.Principal;
using ADServiceRef;


namespace OracleCOEWorkTracking.Controllers
{
    //[AutoValidateAntiforgeryToken]
    [ResponseCache(NoStore = true, Duration = 0)] // IE caches get requests so grids do not refresh
    [Route("api/[controller]")]
    public class AdminController : Controller
    {
        private readonly IDBContextRepository _dbrepository;
        private readonly WorkTrackingContext _wtContext;
        public AdminController(IDBContextRepository dbRepository,  WorkTrackingContext wtContext)
        {
            _dbrepository = dbRepository;
            _wtContext = wtContext;
        }

        [HttpGet("[action]")]
        public ServiceCallResult<IEnumerable<RegionViewModel>> GetRegions()
        {
            try
            {
                var data = _dbrepository.GetRegions();

                var viewModels = new List<RegionViewModel>();
                foreach (var d in data)
                {
                    viewModels.Add(Mappers<Region, RegionViewModel>.MapToViewModel(d));
                }

                return ServiceCallResult<IEnumerable<RegionViewModel>>.CreateSuccessResult(String.Format(UserMessageResource.GetListSuccess, FieldNamesResource.Region), viewModels);
            }
            catch (Exception ex)
            {
                return ServiceCallResult<IEnumerable<RegionViewModel>>.CreateErrorResult(String.Format(UserMessageResource.GetListError, FieldNamesResource.Region) + " " + ex.Message, new List<RegionViewModel>());
            }


        }

        [HttpGet("[action]")]
        public ServiceCallResult<IEnumerable<SBUViewModel>> GetSBUs()
        {
            try
            {
                var data = _dbrepository.GetSBUs();
                var viewModels = new List<SBUViewModel>();
                foreach (var d in data)
                {
                    viewModels.Add(Mappers<SBU, SBUViewModel>.MapToViewModel(d));
                }
                return ServiceCallResult<IEnumerable<SBUViewModel>>.CreateSuccessResult(String.Format(UserMessageResource.GetListSuccess, FieldNamesResource.SBU), viewModels);
            }
            catch (Exception ex)
            {
                return ServiceCallResult<IEnumerable<SBUViewModel>>.CreateErrorResult(String.Format(UserMessageResource.GetListError, FieldNamesResource.SBU) + " " + ex.Message, new List<SBUViewModel>());
            }


        }
        [HttpGet("[action]")]
        public ServiceCallResult<IEnumerable<OwningSiteViewModel>> GetOwningSites()
        {
            try
            {
                var data = _dbrepository.GetOwningSites();
                var viewModels = new List<OwningSiteViewModel>(); 
                foreach (var d in data)
                {
                    viewModels.Add(Mappers<OwningSite, OwningSiteViewModel>.MapToViewModel(d));
                }
                return ServiceCallResult<IEnumerable<OwningSiteViewModel>>.CreateSuccessResult(String.Format(UserMessageResource.GetListSuccess, FieldNamesResource.OwningSite), viewModels);
            }
            catch (Exception ex)
            {
                return ServiceCallResult<IEnumerable<OwningSiteViewModel>>.CreateErrorResult(String.Format(UserMessageResource.GetListError, FieldNamesResource.OwningSite) + " " + ex.Message, new List<OwningSiteViewModel>());
            }


        }
        [HttpGet("[action]")]
        public ServiceCallResult<IEnumerable<AppNameViewModel>> GetAppNamesData()
        {

            var viewModels = new List<AppNameViewModel>();

            try
            {
                var data = _dbrepository.GetAppNames();

                
                foreach (var d in data)
                {
                    viewModels.Add(Mappers<Application, AppNameViewModel>.MapToViewModel(d));
                }
                return ServiceCallResult<IEnumerable<AppNameViewModel>>.CreateSuccessResult(String.Format(UserMessageResource.GetListSuccess, FieldNamesResource.OwningStream), viewModels);
            }
            catch (Exception ex)
            {
                return ServiceCallResult<IEnumerable<AppNameViewModel>>.CreateErrorResult(String.Format(UserMessageResource.GetListError, FieldNamesResource.OwningStream) + " " + ex.Message, new List<AppNameViewModel>());
            }

           
        }

        [HttpGet("[action]")]
        public ServiceCallResult<IEnumerable<OwningStreamViewModel>> GetOwningStreams()
        {
            try
            {
                var data = _dbrepository.GetOwningStreams();
                var viewModels = new List<OwningStreamViewModel>();
                foreach (var d in data)
                {
                    viewModels.Add(Mappers<OwningStream, OwningStreamViewModel>.MapToViewModel(d));
                }
                return ServiceCallResult<IEnumerable<OwningStreamViewModel>>.CreateSuccessResult(String.Format(UserMessageResource.GetListSuccess, FieldNamesResource.OwningStream), viewModels);
            }
            catch (Exception ex)
            {
                return ServiceCallResult<IEnumerable<OwningStreamViewModel>>.CreateErrorResult(String.Format(UserMessageResource.GetListError, FieldNamesResource.OwningStream) + " " + ex.Message, new List<OwningStreamViewModel>());
            }


        }

        [HttpGet("[action]")]
        public ServiceCallResult<IEnumerable<RequestViewViewModel>> GetRequestViews()
        {
            try
            {
                var data = _dbrepository.GetRequestViews();
                var viewModels = new List<RequestViewViewModel>();
                foreach (var d in data)
                {
                    viewModels.Add(Mappers<RequestView, RequestViewViewModel>.MapToViewModel(d));
                }
                return ServiceCallResult<IEnumerable<RequestViewViewModel>>.CreateSuccessResult(String.Format(UserMessageResource.GetListSuccess, FieldNamesResource.RequestView), viewModels.OrderBy(o => o.Name));
            }
            catch (Exception ex)
            {
                return ServiceCallResult<IEnumerable<RequestViewViewModel>>.CreateErrorResult(String.Format(UserMessageResource.GetListError, FieldNamesResource.RequestView) + " " + ex.Message, new List<RequestViewViewModel>());
            }


        }

        [HttpGet("[action]")]
        public ServiceCallResult<DropDownDataViewModel> GetDropDownData()
        {
            try
            {
                var vm = new DropDownDataViewModel();
                var apps = _dbrepository.GetAppNames();
                vm.AppNames = new List<AppNameViewModel>();
                foreach (var a in apps)
                {
                    vm.AppNames.Add(Mappers<Application, AppNameViewModel>.MapToViewModel(a));
                }

                var regions = _dbrepository.GetRegions();
                vm.Regions = new List<RegionViewModel>();
                foreach (var r in regions)
                {
                    vm.Regions.Add(Mappers<Region, RegionViewModel>.MapToViewModel(r));
                }

                var sbus = _dbrepository.GetSBUs();
                vm.SBUs = new List<SBUViewModel>();
                foreach (var s in sbus)
                {
                    vm.SBUs.Add(Mappers<SBU, SBUViewModel>.MapToViewModel(s));
                }

                var owningsites = _dbrepository.GetOwningSites();
                vm.OwningSites  = new List<OwningSiteViewModel>();
                foreach (var o in owningsites)
                {
                    vm.OwningSites.Add(Mappers<OwningSite, OwningSiteViewModel>.MapToViewModel(o));
                }
               

                var booleanDropDowns = _dbrepository.GetBooleanDropDowns();
                vm.BooleanDropDowns = new List<BooleanDropDownViewModel>();
                foreach (var b in booleanDropDowns)
                {
                    vm.BooleanDropDowns.Add(Mappers<BooleanDropDown, BooleanDropDownViewModel>.MapToViewModel(b));
                }
                var developmentTeams = _dbrepository.GetDevelopmentTeams();
                vm.DevelopmentTeams = new List<DevelopmentTeamViewModel>();
                foreach (var d in developmentTeams)
                {
                    vm.DevelopmentTeams.Add(Mappers<DevelopmentTeam, DevelopmentTeamViewModel>.MapToViewModel(d));
                }
                var gateStatuses = _dbrepository.GetGateStatuses();
                vm.GateStatuses = new List<GateStatusViewModel>();
                foreach (var g in gateStatuses)
                {
                    vm.GateStatuses.Add(Mappers<GateStatus, GateStatusViewModel>.MapToViewModel(g));
                }
                var gates = _dbrepository.GetGates();
                vm.Gates = new List<GateViewModel>();
                foreach (var g in gates)
                {
                    vm.Gates.Add(Mappers<Gate, GateViewModel>.MapToViewModel(g));
                }

                var owningStreams = _dbrepository.GetOwningStreams();
                vm.OwningStreams = new List<OwningStreamViewModel>();
                foreach (var o in owningStreams)
                {
                    vm.OwningStreams.Add(Mappers<OwningStream, OwningStreamViewModel>.MapToViewModel(o));
                }
                var impactedStreams = _dbrepository.GetImpactedStreams();
                vm.ImpactedStreams = new List<ImpactedStreamViewModel>();
                foreach (var i in impactedStreams)
                {
                    vm.ImpactedStreams.Add(Mappers<ImpactedStream, ImpactedStreamViewModel>.MapToViewModel(i));
                }
                var modules = _dbrepository.GetModules();
                vm.Modules = new List<ModuleViewModel>();
                foreach (var m in modules)
                {
                    vm.Modules.Add(Mappers<Module, ModuleViewModel>.MapToViewModel(m));
                }
                var oraclePreProdEnvironments = _dbrepository.GetOraclePreProdEnvironments();
                vm.OraclePreProdEnvironments = new List<OraclePreProdEnvironmentViewModel>();
                foreach (var o in oraclePreProdEnvironments)
                {
                    vm.OraclePreProdEnvironments.Add(Mappers<OraclePreProdEnvironment, OraclePreProdEnvironmentViewModel>.MapToViewModel(o));
                }
                var statuses = _dbrepository.GetStatuses();
                vm.Statuses = new List<StatusViewModel>();
                foreach (var s in statuses)
                {
                    vm.Statuses.Add(Mappers<Status, StatusViewModel>.MapToViewModel(s));
                }
                var applicationAttributes = _dbrepository.GetApplicationAttributes();
                vm.ApplicationAttributes = new List<ApplicationAttributeViewModel>();
                foreach (var s in applicationAttributes)
                {
                    vm.ApplicationAttributes.Add(Mappers<ApplicationAttribute, ApplicationAttributeViewModel>.MapToViewModel(s));
                }

                return ServiceCallResult<DropDownDataViewModel>.CreateSuccessResult(String.Format(UserMessageResource.GetListSuccess, FieldNamesResource.RequestView), vm);
            }
            catch (Exception ex)
            {
                return ServiceCallResult<DropDownDataViewModel>.CreateErrorResult(String.Format(UserMessageResource.GetListError, FieldNamesResource.RequestView) + " " + ex.Message, new DropDownDataViewModel());
            }


        }

        [HttpGet("[action]")]
        public async Task<ServiceCallResult<UserViewModel>> GetCurrentUser()
        {
            ADServiceClient client = new ADServiceClient();
            IIdentity id = User.Identity;
            //var user = await client.GetUserInfoExtendedByNetworkIdStartsWithAsync(id.GetLogin(), "1");
            var user = await client.GetUserInfoExtendedByNetworkIdStartsWithAsync("CCC27", "1");
            
            var uvm = new UserViewModel();               
            if (user != null && user.Length > 0)
            {   
                uvm.displayName = user[0].FullName;
                uvm.userId = user[0].NetworkId;
                uvm.email = user[0].Email;
                uvm.Role = await DetermineUserRoleAsync(id.GetLogin(), client);
                 //uvm.Role = await DetermineUserRoleAsync("C006693", client);
            }
                
            
            return ServiceCallResult<UserViewModel>.CreateSuccessResult("User Found", uvm);
        }

        [HttpGet("[action]")]
        public ServiceCallResult<IEnumerable<ApplicationAttributeViewModel>> GetApplicationAttributeViews()
        {
            try
            {
                var data = _dbrepository.GetApplicationAttributes();
                var viewModels = new List<ApplicationAttributeViewModel>();
                foreach (var d in data)
                {
                    viewModels.Add(Mappers<ApplicationAttribute, ApplicationAttributeViewModel>.MapToViewModel(d));
                }
                return ServiceCallResult<IEnumerable<ApplicationAttributeViewModel>>.CreateSuccessResult(String.Format(UserMessageResource.GetListSuccess, FieldNamesResource.RequestView), viewModels.OrderBy(o => o.Id));
            }
            catch (Exception ex)
            {
                return ServiceCallResult<IEnumerable<ApplicationAttributeViewModel>>.CreateErrorResult(String.Format(UserMessageResource.GetListError, FieldNamesResource.RequestView) + " " + ex.Message, new List<ApplicationAttributeViewModel>());
            }
        }

        [HttpGet("[action]")]
        public async Task<IEnumerable<UserViewModel>> SearchUsers(string searchTerm)
        {
            var userVMs = new List<UserViewModel>();
            if (!string.IsNullOrEmpty(searchTerm))
            {
                ADServiceClient client = new ADServiceClient();
                var users = await client.GetUserInfoExtendedByLastNameStartsWithAsync(searchTerm, "10");
                for (int i = 0; i <= users.Length - 1; i++)
                {
                    userVMs.Add(new UserViewModel() { displayName = users[i].FullName, email = users[i].Email, userId = users[i].NetworkId });
                }
            }
            return userVMs;
        }

        private async Task<Role> DetermineUserRoleAsync(string userId, ADServiceClient client)
        {
            bool badd = false;
            bool bmanage = false;
            var eSettings = _wtContext.EnvironmentSettings.FirstOrDefault();
            string[] addRequestsADGroups = eSettings.AddRequestsADGroup.Split(';');
            string[] manageRequestsADGroups = eSettings.ManageRequestsADGroup.Split(';');
            var groups = await client.GetUserGroupsByNetworkIdAsync(userId, "true");
            foreach (ADGroup group in groups)
            {
                try
                {
                    foreach (var adGroup in addRequestsADGroups)
                    {
                        if (group.Name.ToLower().Trim() == adGroup.ToLower().Trim())
                        {
                            badd = true;
                        }
                    }
                    foreach (var adGroup in manageRequestsADGroups)
                    {
                        if (group.Name.ToLower().Trim() == adGroup.ToLower().Trim())
                        {
                            bmanage = true;
                        }
                    }
                }
                catch (Exception e)
                { }
            }
            if (bmanage)
            {
                return Role.Manage;
            }else if (badd)
            {
                return Role.Add;
            }else
            {
                return Role.View;
            }
        }
    }
}
