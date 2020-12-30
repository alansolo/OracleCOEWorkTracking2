using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using OracleCOEWorkTracking.Data.Entities;

namespace OracleCOEWorkTracking.ViewModels
{
    public class ViewModelMappingProfile : Profile
    {
        public ViewModelMappingProfile()
        {

            //AppIds = d.AppRegions.Select(s => s.AppId).ToList()

            //CreateMap<Region, RegionViewModel>().ForSourceMember(x => x.AppRegions, y => y.Ignore());
            CreateMap<Region, RegionViewModel>().ForMember(x => x.AppIds, opt => opt.MapFrom(src => src.AppRegions.Select(s => s.AppId).ToList()));
            CreateMap<RequestRegion, RegionViewModel>().ForMember(x => x.AppIds, opt => opt.MapFrom(src => src.Region.AppRegions.Select(s => s.AppId).ToList()));
            CreateMap<Module, ModuleViewModel>().ForMember(x => x.AppIds, opt => opt.MapFrom(src => src.AppModules.Select(s => s.AppId).ToList()));
            CreateMap<OwningSite, OwningSiteViewModel>().ForMember(x => x.AppIds, opt => opt.MapFrom(src => src.AppOwningSites.Select(s => s.AppId).ToList()));


            //CreateMap<RequestView, RequestViewViewModel>().ForMember(x => x.Application, opt => opt.MapFrom(src => true));
                       

            CreateMap<Request, RequestViewModel>().ForMember(x => x.AppName, opt => opt.MapFrom(src => new AppNameViewModel() {
                 Name = src.Application.Name, Id = src.Application.Id}))
                                                  .ForMember(x => x.Regions, opt => opt.MapFrom(src => src.Regions.Select(z => z.Region).ToList()))
                                                  .ForMember(x => x.SBUs, opt => opt.MapFrom(src => src.SBUs.Select(z => z.SBU).ToList()))
                                                  .ForMember(x => x.ImpactedStreams, opt => opt.MapFrom(src => src.ImpactedStreams.Select(z => z.ImpactedStream).ToList()))
                                                  .ForMember(x => x.OraclePreProdEnvironments, opt => opt.MapFrom(src => src.OraclePreProdEnvironments.Select(z => z.OraclePreProdEnvironment).ToList()))
                                                  .ForMember(x => x.Modules, opt => opt.MapFrom(src => src.Modules.Select(z => z.Module).ToList()))
                                                  .ForMember(x => x.DevelopmentTeams, opt => opt.MapFrom(src => src.DevelopmentTeams.Select(z => z.DevelopmentTeam).ToList()))
                                                  .ForMember(x => x.OraclePreProdEnvironments, opt => opt.MapFrom(src => src.OraclePreProdEnvironments.Select(z => z.OraclePreProdEnvironment).ToList()))
                                                  .ForMember(dest => dest.MD_50_DueDate, opts => opts.MapFrom(src => src.MD_50_DueDate.HasValue ? src.MD_50_DueDate.Value.ToString("MM/dd/yyyy") : ""))
                                                  .ForMember(dest => dest.MD_70_DueDate, opts => opts.MapFrom(src => src.MD_70_DueDate.HasValue ? src.MD_70_DueDate.Value.ToString("MM/dd/yyyy") : ""))
                                                  .ForMember(dest => dest.TestingDate, opts => opts.MapFrom(src => src.TestingDate.HasValue ? src.TestingDate.Value.ToString("MM/dd/yyyy") : ""))
                                                  .ForMember(dest => dest.Attribute10, opts => opts.MapFrom(src => src.Attribute10.HasValue ? src.Attribute10.Value.ToString("MM/dd/yyyy") : ""))
                                                  .ForMember(dest => dest.ProductionDate, opts => opts.MapFrom(src => src.ProductionDate.HasValue ? src.ProductionDate.Value.ToString("MM/dd/yyyy") : ""))
                                                  .ForMember(dest => dest.ModifiedOn, opts => opts.MapFrom(src => src.ModifiedOn.HasValue ? src.ModifiedOn.Value.ToString("MM/dd/yyyy") : ""))
                                                  .ForMember(dest => dest.CreatedOn, opts => opts.MapFrom(src => src.CreatedOn.ToString("MM/dd/yyyy")))
                                                  .ForMember(dest => dest.TotalEstimate, opts => opts.MapFrom(src => src.TotalEstimate == 0 ? null : src.TotalEstimate))
                                                  .ForMember(dest => dest.DCOEEstimate, opts => opts.MapFrom(src => src.DCOEEstimate == 0 ? null : src.DCOEEstimate))
                                                  .ForMember(dest => dest.OracleDevEstimateOffShore, opts => opts.MapFrom(src => src.OracleDevEstimateOffShore == 0 ? null : src.OracleDevEstimateOffShore))
                                                  .ForMember(dest => dest.OracleDevEstimateOnShore, opts => opts.MapFrom(src => src.OracleDevEstimateOnShore == 0 ? null : src.OracleDevEstimateOnShore))
                                                  .ForSourceMember(x => x.OTMImpactedStream, y => y.Ignore())
                                                  .ForSourceMember(x => x.BIImpactedStream, y => y.Ignore());

            CreateMap<RequestAttachment, RequestAttachmentViewModel>().ForSourceMember(x => x.Attachment, y => y.Ignore());
            CreateMap<Request, AddRequestViewModel>().ForMember(x => x.AppName, y => y.Ignore());
            CreateMap<Request, AddRequestViewModel>().ForMember(x => x.SBUs, y => y.Ignore());


        }

    }
}
