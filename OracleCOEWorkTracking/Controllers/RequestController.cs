using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using OracleCOEWorkTracking.Controllers.Helpers;
//using OracleCOEWorkTracking.Controllers.Helpers;
using OracleCOEWorkTracking.Data;
using OracleCOEWorkTracking.Data.Entities;
using OracleCOEWorkTracking.Data.Repositories;
using OracleCOEWorkTracking.Resources;
using OracleCOEWorkTracking.ViewModels;


namespace OracleCOEWorkTracking.Controllers
{
    //[AutoValidateAntiforgeryToken]
    [ResponseCache(NoStore = true, Duration = 0)] // IE caches get requests so grids do not refresh
    [Route("api/[controller]")]
    public class RequestController : Controller
    {
        private readonly IDBContextRepository _dbrepository;
        //private readonly IMapper _mapper;
        private readonly WorkTrackingContext _wtContext;
        public RequestController(IDBContextRepository dbRepository,  WorkTrackingContext wtContext)
        {
            _dbrepository = dbRepository;
            _wtContext = wtContext;
        }

        [HttpGet("[action]")]
        public ServiceCallResult<List<RequestViewModel>> GetAllRequests(bool openRequestsOnly = false)
        {
            try
            {
                var vm = new List<RequestViewModel>();
                //var completedId = _wtContext.Statuses.Where(x => x.Name.ToLower() == "completed").FirstOrDefault().Id;
                //var cancelledId = _wtContext.Statuses.Where(x => x.Name.ToLower() == "cancelled").FirstOrDefault().Id;
                IQueryable<Request> query = _wtContext.Requests.Include(x => x.Status)
                                                .Include(x => x.Application)
                                                .Include(x => x.Regions).ThenInclude(x => x.Region)
                                                .Include(x => x.SBUs).ThenInclude(x => x.SBU)
                                                .Include(x => x.OwningSite)
                                                .Include(x => x.OwningStream)
                                                .Include(x => x.ImpactedStreams).ThenInclude(x => x.ImpactedStream)
                                                .Include(x => x.OraclePreProdEnvironments).ThenInclude(x => x.OraclePreProdEnvironment)
                                                .Include(x => x.BIRequest)
                                                .Include(x => x.Attachments);
                if (openRequestsOnly)
                {
                    query = query.Where(x => x.Status.Name.ToLower() != "completed" && x.Status.Name.ToLower() != "cancelled");
                }
                var requests = query.ToList();
                foreach (var r in requests)
                {
                    vm.Add(Mappers<Request, RequestViewModel>.MapToViewModel(r));
                }

                return ServiceCallResult<List<RequestViewModel>>.CreateSuccessResult(String.Format(UserMessageResource.GetListSuccess, FieldNamesResource.Request), vm);
            }
            catch (Exception ex)
            {
                return ServiceCallResult<List<RequestViewModel>>.CreateErrorResult(string.Format(UserMessageResource.GetListError, FieldNamesResource.Request) + " " + ex.Message, new List<RequestViewModel>());
            }
        }
        [HttpGet("[action]")]
        public ServiceCallResult<List<RequestViewModel>> GetAllRequestsViewData(int viewId, bool openRequestsOnly = false)
        {
            try
            {
                var view = _wtContext.RequestViews.Where(x => x.Id == viewId).FirstOrDefault();
                if (view != null)
                {
                    List<int> requestIds = new List<int>();
                    DbCommand command = _wtContext.Database.GetDbConnection().CreateCommand();
                    command.CommandText = "select id from requests ";
                    command.CommandText += string.IsNullOrEmpty(view.WhereClaus) ? "" : "where " + view.WhereClaus;
                    _wtContext.Database.OpenConnection();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            requestIds.Add((int)reader["id"]);
                        }
                    }
                    _wtContext.Database.CloseConnection();

                    var vm = new List<RequestViewModel>();

                    IQueryable<Request> query = _wtContext.Requests
                                                    .Include(x => x.Status)
                                                    .Include(x => x.Application)
                                                    .Include(x => x.Regions).ThenInclude(x => x.Region)
                                                    .Include(x => x.SBUs).ThenInclude(x => x.SBU)
                                                    .Include(x => x.OwningSite)
                                                    .Include(x => x.OwningStream)
                                                    .Include(x => x.ImpactedStreams).ThenInclude(x => x.ImpactedStream)
                                                    .Include(x => x.OraclePreProdEnvironments).ThenInclude(x => x.OraclePreProdEnvironment)
                                                    .Include(x => x.BIRequest)
                                                    .Include(x => x.Attachments);

                    query = query.Where(x => requestIds.Contains(x.Id));

                    if (openRequestsOnly)
                    {
                        query = query.Where(x => x.Status.Name.ToLower() != "completed" && x.Status.Name.ToLower() != "cancelled");
                    }
                    var requests = query.ToList();
                    foreach (var r in requests)
                    {
                        vm.Add(Mappers<Request, RequestViewModel>.MapToViewModel(r));
                    }

                    return ServiceCallResult<List<RequestViewModel>>.CreateSuccessResult(String.Format(UserMessageResource.GetListSuccess, FieldNamesResource.Request), vm);
                }
                else
                {
                    return ServiceCallResult<List<RequestViewModel>>.CreateErrorResult(string.Format(UserMessageResource.CannotFindFieldInDatabase, FieldNamesResource.RequestView), new List<RequestViewModel>());
                }
            }
            catch (Exception ex)
            {
                return ServiceCallResult<List<RequestViewModel>>.CreateErrorResult(string.Format(UserMessageResource.GetListError, FieldNamesResource.Request) + " " + ex.Message, new List<RequestViewModel>());
            }
        }
        [HttpGet("[action]/{Id}")]
        public ActionResult GetRequestAttachment(int Id)
        {
            try
            {
                var attachment = _wtContext.RequestAttachments.Where(x => x.Id == Id).FirstOrDefault();
                Byte[] file = attachment.Attachment;
                MemoryStream stream = new MemoryStream();
                stream.Write(file, 0, file.Length);
                stream.Position = 0;
                FileExtensionContentTypeProvider contentTypeProvider = new FileExtensionContentTypeProvider();
                string contentType;
                if (!contentTypeProvider.TryGetContentType(attachment.FileName, out contentType))
                {
                    contentType = "application/octet-stream";
                }
                return new FileStreamResult(stream, contentType) { FileDownloadName = attachment.FileName };
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        //[HttpGet("[action]")]
        //public ServiceCallResult<List<RequestViewModel>> GetRequestViewDataOld(int viewId, bool openRequestsOnly = false)
        //{
        //    try
        //    {
        //        var vm = new List<RequestViewModel>();
        //        var view = _wtContext.RequestViews.Where(x => x.Id == viewId).FirstOrDefault();
        //        if (view != null)
        //        {   //.Where(string.IsNullOrEmpty(view.WhereClaus) ? "id > 0" : view.WhereClaus)
        //            IQueryable<Request> query = _wtContext.Requests
        //                                              .OrderBy(string.IsNullOrEmpty(view.OrderBy) ? "id desc" : view.OrderBy)
        //                                              .Include(x => x.Status)
        //                                              .Include(x => x.Regions).ThenInclude(x => x.Region)
        //                                              .Include(x => x.SBUs).ThenInclude(x => x.SBU)
        //                                              .Include(x => x.OwningSite)
        //                                              .Include(x => x.OwningStream)
        //                                              .Include(x => x.ImpactedStreams).ThenInclude(x => x.ImpactedStream)
        //                                              .Include(x => x.Modules).ThenInclude(x => x.Module)
        //                                              .Include(x => x.DevelopmentTeams).ThenInclude(x => x.DevelopmentTeam)
        //                                              .Include(x => x.OraclePreProdEnvironments).ThenInclude(x => x.OraclePreProdEnvironment)
        //                                              .Include(x => x.BIRequest)
        //                                              .Include(x => x.BIGateStatus)
        //                                              .Include(x => x.NextBIGate)
        //                                              .Include(x => x.ReadyForBIGate)
        //                                              .Include(x => x._NETGateStatus)
        //                                              .Include(x => x.Next_NETGate)
        //                                              .Include(x => x.ReadyFor_NETGate)
        //                                              .Include(x => x.EBSGateStatus)
        //                                              .Include(x => x.NextEBSGate)
        //                                              .Include(x => x.ReadyForEBSGate)
        //                                              .Include(x => x.OTMGateStatus)
        //                                              .Include(x => x.OTMEBSGate)
        //                                              .Include(x => x.ReadyForOTMGate)
        //                                              .Include(x => x.Attachments);

        //            query = query.Where(string.IsNullOrEmpty(view.WhereClaus) ? "id > 0" : view.WhereClaus);

        //            if (openRequestsOnly)
        //            {
        //                query = query.Where(x => x.Status.Name.ToLower() != "completed" && x.Status.Name.ToLower() != "cancelled");
        //            }
        //            var requests = query.ToList();
        //            foreach (var r in requests)
        //            {
        //                vm.Add(Mappers<Request, RequestViewModel>.MapToViewModel(r));
        //            }

        //        }
        //        else
        //        {
        //            return ServiceCallResult<List<RequestViewModel>>.CreateErrorResult(string.Format(UserMessageResource.CannotFindFieldInDatabase, FieldNamesResource.RequestView), new List<RequestViewModel>());
        //        }
        //        return ServiceCallResult<List<RequestViewModel>>.CreateSuccessResult(string.Format(UserMessageResource.GetListSuccess, FieldNamesResource.Request), vm);
        //    }
        //    catch (Exception ex)
        //    {
        //        return ServiceCallResult<List<RequestViewModel>>.CreateErrorResult(string.Format(UserMessageResource.GetListError, FieldNamesResource.Request) + " " + ex.Message, new List<RequestViewModel>());
        //    }
        //}
        [HttpGet("[action]")]
        public ServiceCallResult<List<RequestViewModel>> GetRequestViewData(int viewId, bool openRequestsOnly = false)
        {
            try
            {
                var vm = new List<RequestViewModel>();
                var view = _wtContext.RequestViews.Where(x => x.Id == viewId).FirstOrDefault();
                if (view != null)
                {
                    List<int> requestIds = new List<int>();
                    DbCommand command = _wtContext.Database.GetDbConnection().CreateCommand();
                    command.CommandText = "select id from requests ";
                    command.CommandText += string.IsNullOrEmpty(view.WhereClaus) ? "" : "where " + view.WhereClaus;
                    _wtContext.Database.OpenConnection();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            requestIds.Add((int)reader["id"]);
                        }
                    }
                    _wtContext.Database.CloseConnection();

                    IQueryable<Request> query = _wtContext.Requests
                                   .OrderBy(string.IsNullOrEmpty(view.OrderBy) ? "id desc" : view.OrderBy)
                                   .Include(x=>x.Application)
                                   .Include(x => x.Status)
                                   .Include(x => x.Regions).ThenInclude(x => x.Region)
                                   .Include(x => x.SBUs).ThenInclude(x => x.SBU)
                                   .Include(x => x.OwningSite)
                                   .Include(x => x.OwningStream)
                                   .Include(x => x.ImpactedStreams).ThenInclude(x => x.ImpactedStream)
                                   .Include(x => x.Modules).ThenInclude(x => x.Module)
                                   .Include(x => x.DevelopmentTeams).ThenInclude(x => x.DevelopmentTeam)
                                   .Include(x => x.OraclePreProdEnvironments).ThenInclude(x => x.OraclePreProdEnvironment)
                                   .Include(x => x.BIRequest)
                                   .Include(x => x.BIGateStatus)
                                   .Include(x => x.NextBIGate)
                                   .Include(x => x.ReadyForBIGate)
                                   .Include(x => x._NETGateStatus)
                                   .Include(x => x.Next_NETGate)
                                   .Include(x => x.ReadyFor_NETGate)
                                   .Include(x => x.EBSGateStatus)
                                   .Include(x => x.NextEBSGate)
                                   .Include(x => x.ReadyForEBSGate)
                                   .Include(x => x.OTMGateStatus)
                                   .Include(x => x.OTMEBSGate)
                                   .Include(x => x.ReadyForOTMGate)
                                   .Include(x => x.Attachments);
                    query = query.Where(x => requestIds.Contains(x.Id));

                    if (openRequestsOnly)
                    {
                        query = query.Where(x => x.Status.Name.ToLower() != "completed" && x.Status.Name.ToLower() != "cancelled");
                    }
                    var requests = query.ToList();
                    foreach (var r in requests)
                    {
                        vm.Add(Mappers<Request, RequestViewModel>.MapToViewModel(r));
                    }
                }
                else
                {
                    return ServiceCallResult<List<RequestViewModel>>.CreateErrorResult(string.Format(UserMessageResource.CannotFindFieldInDatabase, FieldNamesResource.RequestView), new List<RequestViewModel>());
                }
                return ServiceCallResult<List<RequestViewModel>>.CreateSuccessResult(string.Format(UserMessageResource.GetListSuccess, FieldNamesResource.Request), vm);
            }
            catch (Exception ex)
            {
                return ServiceCallResult<List<RequestViewModel>>.CreateErrorResult(string.Format(UserMessageResource.GetListError, FieldNamesResource.Request) + " " + ex.Message, new List<RequestViewModel>());
            }
        }
        [HttpGet("[action]")]
        public ServiceCallResult<List<RequestNoteViewModel>> GetRequestNotes(int requestId)
        {
            try
            {
                var vm = new List<RequestNoteViewModel>();
                var notes = _wtContext.RequestNotes.Where(x => x.RequestId == requestId).OrderByDescending(x=> x.ModifiedOn).ToList();
  
                foreach (var n in notes)
                {
                    vm.Add(Mappers<RequestNote, RequestNoteViewModel>.MapToViewModel(n));
                }

                return ServiceCallResult<List<RequestNoteViewModel>>.CreateSuccessResult(string.Format(UserMessageResource.GetListSuccess, FieldNamesResource.RequestNote), vm);
            }
            catch (Exception ex)
            {
                return ServiceCallResult<List<RequestNoteViewModel>>.CreateErrorResult(string.Format(UserMessageResource.GetListError, FieldNamesResource.RequestNote) + " " + ex.Message, new List<RequestNoteViewModel>());
            }
        }
        [HttpPost("[action]")]
        public ServiceCallResult<bool> AddRequestNote([FromBody] RequestNoteViewModel requestNote)
        {
            try
            {
                _wtContext.SetCurrentUser(Auth.GetCurrentUser(User.Identity.Name).fullName);

                RequestNote newRequestNote = new RequestNote();
                newRequestNote.RequestId = requestNote.RequestId;
                newRequestNote.Note = requestNote.Note;

                _wtContext.RequestNotes.Add(newRequestNote);
                _wtContext.SaveChanges();

                return ServiceCallResult<bool>.CreateSuccessResult(String.Format(UserMessageResource.FieldAddedSuccessfully, FieldNamesResource.RequestNote), true);
            }
            catch (Exception ex)
            {
                return ServiceCallResult<bool>.CreateErrorResult(String.Format(UserMessageResource.ErrorAddingField, FieldNamesResource.RequestNote) + ex.Message, false);
            }

        }
        [HttpPost("[action]"), DisableRequestSizeLimit]
        public ServiceCallResult<AddRequestViewModel> AddRequestAttachment()
        {
            if (Request.Form.Files.Count() > 0)
            {
                try
                {
                    foreach (var file in Request.Form.Files)
                    {
                        RequestAttachment fileAttachment = new RequestAttachment();
                        var memoryStream = new MemoryStream();
                        file.CopyTo(memoryStream);
                        fileAttachment.Attachment = memoryStream.ToArray();
                        fileAttachment.FileName = file.FileName;
                        fileAttachment.RequestId = int.Parse(Request.Form["id"].ToString());
                        _wtContext.RequestAttachments.Add(fileAttachment);
                    }
                    _wtContext.SaveChanges();

                    Request ret = _wtContext.Requests
                                 .Where(x => x.Id == int.Parse(Request.Form["id"].ToString()))
                                 .Include(x => x.OwningStream)
                                 .FirstOrDefault();
                    var vm = Mappers<Request, AddRequestViewModel>.MapToViewModel(ret);
                    return ServiceCallResult<AddRequestViewModel>.CreateSuccessResult(String.Format(UserMessageResource.FieldAddedSuccessfully, FieldNamesResource.Request), vm);
                }
                catch (Exception ex)
                {
                    return ServiceCallResult<AddRequestViewModel>.CreateErrorResult(String.Format(UserMessageResource.ErrorAddingField, FieldNamesResource.Request) + ex.Message, new AddRequestViewModel());
                }
            }
            else
            {
                return ServiceCallResult<AddRequestViewModel>.CreateErrorResult(String.Format(UserMessageResource.ErrorSavingInputInvalid, FieldNamesResource.Request, FieldNamesResource.Fields), new AddRequestViewModel());
            }
        }

        [HttpPost("[action]"), DisableRequestSizeLimit]
        public ServiceCallResult<AddRequestViewModel> UpdateRequestAttachments()
        {
            try
            {
                List<int> attachIntIdList = new List<int>();
                var keepAttach = Request.Form.Where(f => f.Key.Contains("keep")).Select(s => s.Value.ToList());
                foreach(var at in keepAttach)
                {
                    foreach(var a in at)
                    {
                        int.TryParse(a, out int i);
                        attachIntIdList.Add(i);
                    }
                }
                var toDelete = _wtContext.RequestAttachments.Where(ra => ra.RequestId == int.Parse(Request.Form["id"].ToString()) && !attachIntIdList.Contains(ra.Id));
                _wtContext.RequestAttachments.RemoveRange(toDelete);
                _wtContext.SaveChanges();
                if (Request.Form.Files.Count() > 0)
                {
                    return AddRequestAttachment();
                }
                Request ret = _wtContext.Requests
                     .Where(x => x.Id == int.Parse(Request.Form["id"].ToString()))
                     .Include(x => x.OwningStream)
                     .FirstOrDefault();
                var vm = Mappers<Request, AddRequestViewModel>.MapToViewModel(ret);
                return ServiceCallResult<AddRequestViewModel>.CreateSuccessResult(String.Format(UserMessageResource.FieldAddedSuccessfully, FieldNamesResource.Request), vm);
            }
            catch (Exception ex)
            {
                return ServiceCallResult<AddRequestViewModel>.CreateErrorResult(String.Format(UserMessageResource.ErrorAddingField, FieldNamesResource.Request) + ex.Message, new AddRequestViewModel());
            }

        }


        [HttpPost("[action]")]
        public ServiceCallResult<AddRequestViewModel> AddRequest([FromBody] AddRequestViewModel request)
        {
            try
            {
                _wtContext.SetCurrentUser(Auth.GetCurrentUser(User.Identity.Name).fullName);
                if (!isRequestValid(request))
                {
                    return ServiceCallResult<AddRequestViewModel>.CreateErrorResult(String.Format(UserMessageResource.ErrorSavingInputInvalid, FieldNamesResource.Request, FieldNamesResource.Fields), request);
                }
                Request newRequest = new Request();
                newRequest.ApplicationId = request.AppName.Id;
                newRequest.ProjectName = request.ProjectName;
                newRequest.Problem = request.Problem;
                newRequest.BenefitCase = request.BenefitCase;
                newRequest.BIRequestId = request.BiRequestId;
                newRequest.OriginalSystemReference = request.OriginalSystemReference;
                newRequest.Requestor = request.Requestor;
                if (request.OwningSite != null && request.OwningSite.Id != 0)
                {
                    newRequest.OwningSiteId = request.OwningSite.Id;
                }
                newRequest.OwningStreamId = request.OwningStream.Id;
                newRequest.StatusId = _wtContext.Statuses.Where(x => x.Name.ToLower() == "new" && x.DeleteMark == false).FirstOrDefault().Id;
                int no = _wtContext.BooleanDropDownValues.Where(x => x.Name.ToLower() == "no").FirstOrDefault().Id;
                newRequest.ReadyForBIGateId = no;
                newRequest.ReadyForEBSGateId = no;
                newRequest.ReadyForOTMGateId = no;
                newRequest.ReadyFor_NETGateId = no;

                _wtContext.Requests.Add(newRequest);
                _wtContext.SaveChanges();

                Request addedRequest = _wtContext.Requests
                                                 .Where(x => x.ProjectName == request.ProjectName)
                                                 .OrderByDescending(y => y.CreatedOn)
                                                 .Include(i => i.OwningStream)
                                                 .Include(i => i.OwningSite)
                                                 .FirstOrDefault();

                if (addedRequest != null)
                {
                    //add Regions
                    foreach (var r in request.Regions)
                    {
                        var reg = new RequestRegion();
                        reg.RequestId = addedRequest.Id;
                        reg.RegionId = r.Id;
                        //reg.Region = Mappers<Region, RegionViewModel>.MapToEntity(r);
                        _wtContext.RequestRegions.Add(reg);
                    }
                    //add SBUs
                    foreach (var s in request.SBUs)
                    {
                        var sbu = new RequestSBU();
                        sbu.RequestId = addedRequest.Id;
                        sbu.SBUId = s.Id;
                        //sbu.SBU = Mappers<SBU, SBUViewModel>.MapToEntity(s);
                        _wtContext.RequestSBUs.Add(sbu);
                    }
                    //add attachments

                    _wtContext.SaveChanges();

                }

                Request ret = _wtContext.Requests
                                         .Where(x => x.ProjectName == request.ProjectName)
                                         .Include(x => x.OwningStream)
                                         .Include(x => x.BIRequest)
                                         .OrderByDescending(y => y.CreatedOn)
                                         .FirstOrDefault();
                var vm = Mappers<Request, AddRequestViewModel>.MapToViewModel(ret);

                sendNotificationEmail(ret, EmailType.NewRequestAdded);
                return ServiceCallResult<AddRequestViewModel>.CreateSuccessResult(String.Format(UserMessageResource.FieldAddedSuccessfully, FieldNamesResource.Request), vm);
            }
            catch (Exception ex)
            {
                return ServiceCallResult<AddRequestViewModel>.CreateErrorResult(String.Format(UserMessageResource.ErrorAddingField, FieldNamesResource.Request) + ex.Message, new AddRequestViewModel());
            }

        }

        [HttpPost("[action]")]
        public ServiceCallResult<RequestViewModel> UpdateRequest([FromBody] RequestViewModel request)
        {
            try
            {
                string previousStatus = "";
                bool owningStreamChange = false;
                bool statusChange = false;

                _wtContext.SetCurrentUser(Auth.GetCurrentUser(User.Identity.Name).fullName);
                if (!isRequestValid(request))
                {
                    return ServiceCallResult<RequestViewModel>.CreateErrorResult(String.Format(UserMessageResource.ErrorSavingInputInvalid, FieldNamesResource.Request, FieldNamesResource.Fields), request);
                }

                var existingRequest = _wtContext.Requests.Include(x => x.Status).Include(x => x.OwningStream).Where(x => x.Id == request.Id).FirstOrDefault();
                if (existingRequest != null)
                {
                    existingRequest.ApplicationId = request.AppName.Id;
                    existingRequest.ProjectName = request.ProjectName;
                    existingRequest.Problem = request.Problem;
                    existingRequest.BenefitCase = request.BenefitCase;
                    existingRequest.COEPriority = request.COEPriority;
                    existingRequest.GBSPriority = request.GBSPriority;
                    if (request.StatusId != existingRequest.StatusId)
                    {
                        previousStatus = existingRequest.Status.Name;
                        existingRequest.StatusId = request.StatusId;                     
                    }
                    existingRequest.MD_50_DueDate = request.MD_50_DueDate != null ? Convert.ToDateTime(request.MD_50_DueDate) : (DateTime?)null;
                    existingRequest.MD_70_DueDate = request.MD_70_DueDate != null ? Convert.ToDateTime(request.MD_70_DueDate) : (DateTime?)null;
                    existingRequest.TestingDate = request.TestingDate != null ? Convert.ToDateTime(request.TestingDate) : (DateTime?)null;
                    existingRequest.ProductionDate = request.ProductionDate != null ? Convert.ToDateTime(request.ProductionDate) : (DateTime?)null;
                    existingRequest.TotalEstimate = request.TotalEstimate;
                    existingRequest.OracleDevEstimateOffShore = request.OracleDevEstimateOffShore;
                    existingRequest.OracleDevEstimateOnShore = request.OracleDevEstimateOnShore;
                    existingRequest.DCOEEstimate = request.DCOEEstimate;
                    existingRequest.CRNo = request.CRNo;
                    existingRequest.FunctionalContact = request.FunctionalContact;
                    existingRequest.BIContact = request.BIContact;
                    existingRequest.OracleDevelopmentLead = request.OracleDevelopmentLead;
                    existingRequest.DCOEDevelopmentLead = request.DCOEDevelopmentLead;
                    existingRequest.MD_50 = request.MD_50;
                    existingRequest.MD_70 = request.MD_70;
                    existingRequest.TIPUrl = request.TIPUrl;
                    existingRequest.EBSGateQuestionnaireUrl = request.EBSGateQuestionnaireUrl;
                    existingRequest.BIGateQuestionnaireUrl = request.BIGateQuestionnaireUrl;
                    existingRequest._NETGateQuestionnaireUrl = request._NETGateQuestionnaireUrl;
                    existingRequest.OTMGateQuestionnaireUrl = request.OTMGateQuestionnaireUrl;
                    existingRequest.ReadyForEBSGateId = request.ReadyForEBSGate != null ? request.ReadyForEBSGate.Id : (int?)null;
                    existingRequest.EBSGateStatusId = request.EBSGateStatus != null ? request.EBSGateStatus.Id : (int?)null;
                    existingRequest.NextEBSGateId = request.NextEBSGate != null ? request.NextEBSGate.Id : (int?)null;
                    existingRequest.ReadyForOTMGateId = request.ReadyForOTMGate != null ? request.ReadyForOTMGate.Id : (int?)null;
                    existingRequest.OTMGateStatusId = request.OTMGateStatus != null ? request.OTMGateStatus.Id : (int?)null;
                    existingRequest.OTMEBSGateId = request.OTMEBSGate != null ? request.OTMEBSGate.Id : (int?)null;
                    existingRequest.ReadyForBIGateId = request.ReadyForBIGate != null ? request.ReadyForBIGate.Id : (int?)null;
                    existingRequest.BIGateStatusId = request.BIGateStatus != null ? request.BIGateStatus.Id : (int?)null;
                    existingRequest.NextBIGateId = request.NextBIGate != null ? request.NextBIGate.Id : (int?)null;
                    existingRequest.ReadyFor_NETGateId = request.ReadyFor_NETGate != null ? request.ReadyFor_NETGate.Id : (int?)null;
                    existingRequest._NETGateStatusId = request._NETGateStatus != null ? request._NETGateStatus.Id : (int?)null;
                    existingRequest.Next_NETGateId = request.Next_NETGate != null ? request.Next_NETGate.Id : (int?)null;
                    existingRequest.EstimateInfra = request.EstimateInfra;
                    existingRequest.FrontLineContact = request.FrontLineContact;                  
                    existingRequest.OwningSiteId = request.OwningSite != null ? request.OwningSite.Id : (int?)null;                    
                    if (existingRequest.OwningStreamId != request.OwningStream.Id)
                    {
                        owningStreamChange = true;
                        existingRequest.OwningStreamId = request.OwningStream.Id;
                    }
                    existingRequest.Requestor = request.Requestor;
                    existingRequest.BIRequestId = request.BIRequestId;
                    existingRequest.OriginalSystemReference = request.OriginalSystemReference;
                    existingRequest.Attribute1 = request.Attribute1;
                    existingRequest.Attribute2 = request.Attribute2;
                    existingRequest.Attribute3 = request.Attribute3;
                    existingRequest.Attribute4 = request.Attribute4;
                    existingRequest.Attribute5 = request.Attribute5;
                    existingRequest.Attribute6 = request.Attribute6;
                    existingRequest.Attribute7 = request.Attribute7;
                    existingRequest.Attribute8 = request.Attribute8;
                    existingRequest.Attribute9 = request.Attribute9;
                    existingRequest.Attribute10 = request.Attribute10 != null ? Convert.ToDateTime(request.Attribute10) : (DateTime?)null;
                    //default these values to false, set them to true whether values exist in impacted stream array. 
                    existingRequest.BIImpactedStream = false;
                    existingRequest.OTMImpactedStream = false;


                    //Change Valid
                    if (existingRequest.Status.Id != request.Status.Id)
                    {
                        statusChange = true;
                        existingRequest.StatusId = request.Status.Id;
                    }

                    if (existingRequest.OwningStream.Id != request.OwningStream.Id)
                    {
                        owningStreamChange = true;
                        existingRequest.OwningStreamId = request.OwningStream.Id;
                    }


                    //regions
                    var regions = _wtContext.RequestRegions.Where(x => x.RequestId == request.Id).ToList();
                    _wtContext.RequestRegions.RemoveRange(regions);
                    foreach (var r in request.Regions)
                    {
                        var reg = new RequestRegion();
                        reg.RequestId = request.Id;
                        reg.RegionId = r.Id;
                        _wtContext.RequestRegions.Add(reg);
                    }

                    //sbus
                    var sbus = _wtContext.RequestSBUs.Where(x => x.RequestId == request.Id).ToList();
                    _wtContext.RequestSBUs.RemoveRange(sbus);
                    foreach (var s in request.SBUs)
                    {
                        var sbu = new RequestSBU();
                        sbu.RequestId = request.Id;
                        sbu.SBUId = s.Id;
                        _wtContext.RequestSBUs.Add(sbu);
                    }
                    //impactedstreams
                    var impactedstreams = _wtContext.RequestImpactedStreams.Where(x => x.RequestId == request.Id).ToList();
                    _wtContext.RequestImpactedStreams.RemoveRange(impactedstreams);
                    foreach (var i in request.ImpactedStreams)
                    {
                        var ist = new RequestImpactedStream();
                        ist.RequestId = request.Id;
                        ist.ImpactedStreamId = i.Id;
                        if (i.Name.ToUpper() == "BI")
                        {
                            existingRequest.BIImpactedStream = true;
                        } 
                        if (i.Name.ToUpper() == "OTM")
                        {
                            existingRequest.OTMImpactedStream = true;
                        }

                        _wtContext.RequestImpactedStreams.Add(ist);
                    }
                    //modules
                    var modules = _wtContext.RequestModules.Where(x => x.RequestId == request.Id).ToList();
                    _wtContext.RequestModules.RemoveRange(modules);
                    foreach (var i in request.Modules)
                    {
                        var mod = new RequestModule();
                        mod.RequestId = request.Id;
                        mod.ModuleId = i.Id;
                        _wtContext.RequestModules.Add(mod);
                    }
                    //developmentteams
                    var developmentteams = _wtContext.RequestDevelopmentTeams.Where(x => x.RequestId == request.Id).ToList();
                    _wtContext.RequestDevelopmentTeams.RemoveRange(developmentteams);
                    foreach (var i in request.DevelopmentTeams)
                    {
                        var dt = new RequestDevelopmentTeam();
                        dt.RequestId = request.Id;
                        dt.DevelopmentTeamId = i.Id;
                        _wtContext.RequestDevelopmentTeams.Add(dt);
                    }
                    //oraclepreprodenvironments
                    var oracleenvs = _wtContext.RequestOraclePreProdEnvironments.Where(x => x.RequestId == request.Id).ToList();
                    _wtContext.RequestOraclePreProdEnvironments.RemoveRange(oracleenvs);
                    foreach (var i in request.OraclePreProdEnvironments)
                    {
                        var oe = new RequestOraclePreProdEnvironment();
                        oe.RequestId = request.Id;
                        oe.OraclePreProdEnvironmentId = i.Id;
                        _wtContext.RequestOraclePreProdEnvironments.Add(oe);
                    }

                    //add note if status has changed
                    if (!string.IsNullOrEmpty(previousStatus))
                    {
                        var note = new RequestNote();
                        note.RequestId = request.Id;
                        note.Note = "Status Changed from " + previousStatus + " to " + request.Status.Name;
                        _wtContext.RequestNotes.Add(note);
                    }
                    //attachments

                    _wtContext.SaveChanges();

                }
                else
                {
                    return ServiceCallResult<RequestViewModel>.CreateErrorResult(String.Format(UserMessageResource.ErrorSavingInputInvalid, FieldNamesResource.Request, FieldNamesResource.Fields), request);
                }
                Request ret = _wtContext.Requests.Where(x => x.Id == request.Id)
                                .Include(x=>x.Application)
                                  .Include(x => x.Attachments)
                                  .Include(x => x.Status)
                                  .Include(x => x.Regions).ThenInclude(x => x.Region)
                                  .Include(x => x.SBUs).ThenInclude(x => x.SBU)
                                  .Include(x => x.OwningSite)
                                  .Include(x => x.OwningStream)
                                  .Include(x => x.ImpactedStreams).ThenInclude(x => x.ImpactedStream)
                                  .Include(x => x.Modules).ThenInclude(x => x.Module)
                                  .Include(x => x.DevelopmentTeams).ThenInclude(x => x.DevelopmentTeam)
                                  .Include(x => x.OraclePreProdEnvironments).ThenInclude(x => x.OraclePreProdEnvironment)
                                  .Include(x => x.BIRequest)
                                  .Include(x => x.BIGateStatus)
                                  .Include(x => x.NextBIGate)
                                  .Include(x => x.ReadyForBIGate)
                                  .Include(x => x._NETGateStatus)
                                  .Include(x => x.Next_NETGate)
                                  .Include(x => x.ReadyFor_NETGate)
                                  .Include(x => x.EBSGateStatus)
                                  .Include(x => x.NextEBSGate)
                                  .Include(x => x.ReadyForEBSGate)
                                  .Include(x => x.OTMGateStatus)
                                  .Include(x => x.OTMEBSGate)
                                  .Include(x => x.ReadyForOTMGate).FirstOrDefault();

                //if (owningStreamChange)
                //{
                //    sendNotificationEmail(ret, EmailType.OwningStreamChange);
                //}

                OwningStream owningStream = _wtContext.OwningStreams.Where(n => n.Id == request.OwningStream.Id).FirstOrDefault();
                string email = string.Empty;

                if (owningStream != null)
                {
                    email = owningStream.dlEmailAddress;
                }

                //Send Notifications
                if (statusChange)
                {
                    string title = "Change Status Oracle COE";
                    string description = "Request status has been updated in ";
                    sendNotificationEmail(ret, EmailType.OwningStreamChange, title, email, description);
                }

                if (owningStreamChange)
                {
                    string title = "Change Owning Stream Oracle COE";
                    string description = "Owning Stream has been updated in ";
                    sendNotificationEmail(ret, EmailType.OwningStreamChange, title, email, description);
                }

                var vm = Mappers<Request, RequestViewModel>.MapToViewModel(ret);
                return ServiceCallResult<RequestViewModel>.CreateSuccessResult(string.Format(UserMessageResource.FieldSavedSuccessfully, FieldNamesResource.Request), vm);
            }
            catch (Exception ex)
            {
                return ServiceCallResult<RequestViewModel>.CreateErrorResult(string.Format(UserMessageResource.ErrorAddingField, FieldNamesResource.Request) + ex.Message, new RequestViewModel());
            }

        }

        [HttpPost("[action]")]
        public ServiceCallResult<RequestViewModel> UpdateRequestUserField(int requestId, string user, string fieldName)
        {
            try
            {
                _wtContext.SetCurrentUser(Auth.GetCurrentUser(User.Identity.Name).fullName);

                var existingRequest = _wtContext.Requests.Where(x => x.Id == requestId).FirstOrDefault();
                if (existingRequest != null)
                {
                    if (fieldName.ToLower() == "requestor")
                    {
                        existingRequest.Requestor = user;
                    }
                    else if(fieldName.ToLower() == "bicontact")
                    {
                        existingRequest.BIContact = user;
                    }
                    else if (fieldName.ToLower() == "functionalcontact")
                    {
                        existingRequest.FunctionalContact = user;
                    }
                    else if (fieldName.ToLower() == "frontlinecontact")
                    {
                        existingRequest.FrontLineContact = user;
                    }
                    else if (fieldName.ToLower() == "oracledevelopmentlead")
                    {
                        existingRequest.OracleDevelopmentLead = user;
                    }
                    else if (fieldName.ToLower() == "dcoedevelopmentlead")
                    {
                        existingRequest.DCOEDevelopmentLead = user;
                    }

                    _wtContext.SaveChanges();



                }
                else
                {
                    return ServiceCallResult<RequestViewModel>.CreateErrorResult(String.Format(UserMessageResource.ErrorSavingInputInvalid, FieldNamesResource.Request, FieldNamesResource.Fields), new RequestViewModel());
                }
                Request ret = _wtContext.Requests.Where(x => x.Id == requestId).FirstOrDefault();
                var vm = Mappers<Request, RequestViewModel>.MapToViewModel(ret);
                return ServiceCallResult<RequestViewModel>.CreateSuccessResult(string.Format(UserMessageResource.FieldSavedSuccessfully, FieldNamesResource.Request), vm);
            }
            catch (Exception ex)
            {
                return ServiceCallResult<RequestViewModel>.CreateErrorResult(string.Format(UserMessageResource.ErrorAddingField, FieldNamesResource.Request) + ex.Message, new RequestViewModel());
            }

        }

        private bool isRequestValid(AddRequestViewModel request)
        {
            bool ret = true;
            if (request != null)
            {
                if (string.IsNullOrEmpty(request.ProjectName) || string.IsNullOrEmpty(request.Problem) || string.IsNullOrEmpty(request.BenefitCase) || string.IsNullOrEmpty(request.Requestor))
                {
                    ret = false;
                }
                if (request.Regions.Count() <= 0 || request.SBUs.Count() <= 0)
                {
                    ret = false;
                }
                if (request.OwningStream != null) {} else
                {
                    ret = false;
                }
            }
            else
            {
                ret = false;
            }

            return ret;
        }
        private bool isRequestValid(RequestViewModel request)
        {
            bool ret = true;
            if (request != null)
            {
                if (string.IsNullOrEmpty(request.ProjectName) || string.IsNullOrEmpty(request.Problem) || string.IsNullOrEmpty(request.BenefitCase) || string.IsNullOrEmpty(request.Requestor))
                {
                    ret = false;
                }
                //if (request.Regions.Count() <= 0 || request.SBUs.Count() <= 0)
                //{
                //    ret = false;
                //}
                if (request.OwningStream != null) { }
                else
                {
                    ret = false;
                }
            }
            else
            {
                ret = false;
            }

            return ret;
        }

        private void sendNotificationEmail(Request req, EmailType type)
        {
            var env = _wtContext.EnvironmentSettings.FirstOrDefault().EnvironmentName;
            if (!string.IsNullOrEmpty(req.OwningStream.dlEmailAddress))
            {
                string Body = "";
                string link = "";
                if (env == "DEV")
                {
                    link = "<a href =\"http://dev.web.ppg.com/OracleWorkMgmt/requests/\">Oracle Work Tracking Application</a>";
                }
                else if (env == "TEST")
                {
                    link = "<a href =\"http://test.web.ppg.com/OracleWorkMgmt/requests/\">Oracle Work Tracking Application</a>";
                }
                else
                {
                    link = "<a href =\"http://ppg.web.ppg.com/OracleWorkMgmt/requests/\">Oracle Work Tracking Application</a>";
                }
                SmtpClient client = new SmtpClient("smtpgate.go.ppg.com");
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress("OracleCOEWorkTracking@ppg.com");
                mailMessage.To.Add(req.OwningStream.dlEmailAddress);
                if (type == EmailType.NewRequestAdded)
                {
                    var requestor = Auth.GetUserFromFullName(req.Requestor).email;
                    if (!string.IsNullOrEmpty(requestor))
                    {
                        mailMessage.To.Add(requestor);
                    }
                    mailMessage.Subject = "New Oracle COE Request Logged" + (!string.IsNullOrEmpty(env) ? " in " + env + " " : "");
                    if (req.Requestor != req.CreatedBy)
                    {
                        var createdBy = Auth.GetUserFromFullName(req.CreatedBy).email;
                        if (!string.IsNullOrEmpty(createdBy))
                        {
                            mailMessage.To.Add(createdBy);
                        }
                    }
                    if(req.BIRequest.Name == "Yes")
                    {
                        mailMessage.To.Add("dl-NAOracleCOE-BusinessIntelligence@ppg.com");
                    }
                    
                    string linebreak = "<br><br>";
                    StringBuilder sb = new StringBuilder("A new request has been entered into the " + link);
                    sb.Append(linebreak);
                    sb.AppendFormat("<b>Request Number:</b> {0}", req.Id);
                    sb.Append(linebreak);
                    sb.AppendFormat("<b>Requestor:</b> {0}", req.Requestor);
                    sb.Append(linebreak);
                    sb.AppendFormat("<b>Logged By:</b> {0}", req.CreatedBy);
                    sb.Append(linebreak);
                    sb.AppendFormat("<b>Project Name:</b> {0}", req.ProjectName);
                    sb.Append(linebreak);
                    sb.AppendFormat("<b>Problem/Opportunity Statement:</b> {0}", req.Problem);
                    sb.Append(linebreak);
                    sb.AppendFormat("<b>Value Description:</b> {0}", req.BenefitCase);
                    sb.Append(linebreak);
                    sb.AppendFormat("<b>Owning Stream:</b> {0}", req.OwningStream.Name);
                    sb.Append(linebreak);
                    sb.AppendFormat("<b>Enhancement Request:</b> {0}", req.CRNo);
                    Body = sb.ToString();
                    
                }
                else if (type == EmailType.OwningStreamChange)
                {
                    mailMessage.Subject = "Owning Stream Changed on Project #" + req.Id.ToString()  + (!string.IsNullOrEmpty(env) ? " in " + env + " " : "");
                    Body = string.Format("The Owning Stream for request " + req.Id.ToString() + ", " + req.ProjectName + ", has been changed in the {0} to <b>" + req.OwningStream.Name + "<b>", link);
                }

                mailMessage.Body = Body;

                mailMessage.IsBodyHtml = true;
                client.Send(mailMessage);
            }
        }
        private void sendNotificationEmail(Request req, EmailType type, string title, string email,string descripcion)
        {
            var env = _wtContext.EnvironmentSettings.FirstOrDefault().EnvironmentName;
            if (!string.IsNullOrEmpty(req.OwningStream.dlEmailAddress))
            {
                string Body = "";
                string link = "";
                if (env == "DEV")
                {
                    link = "<a href =\"http://dev.web.ppg.com/OracleWorkMgmt/requests/\">Oracle Work Tracking Application</a>";
                }
                else if (env == "TEST")
                {
                    link = "<a href =\"http://test.web.ppg.com/OracleWorkMgmt/requests/\">Oracle Work Tracking Application</a>";
                }
                else
                {
                    link = "<a href =\"http://ppg.web.ppg.com/OracleWorkMgmt/requests/\">Oracle Work Tracking Application</a>";
                }
                SmtpClient client = new SmtpClient("smtpgate.go.ppg.com");
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress("OracleCOEWorkTracking@ppg.com");
                //mailMessage.To.Add(req.OwningStream.dlEmailAddress);
                //if (type == EmailType.NewRequestAdded)
                //{
                    if (!string.IsNullOrEmpty(email))
                    {
                        var requestor = email;
                        mailMessage.To.Add(requestor);
                    }
                    else
                    {
                        var requestor = Auth.GetUserFromFullName(req.Requestor).email;
                        mailMessage.To.Add(requestor);
                    }

                    //if (!string.IsNullOrEmpty(requestor))
                    //{
                    //    mailMessage.To.Add(requestor);
                    //}
                    //New Oracle COE Request Logged
                    mailMessage.Subject = title + (!string.IsNullOrEmpty(env) ? " in " + env + " " : "");
                    if (req.Requestor != req.CreatedBy)
                    {
                        var createdBy = Auth.GetUserFromFullName(req.CreatedBy).email;
                        if (!string.IsNullOrEmpty(createdBy))
                        {
                            mailMessage.To.Add(createdBy);
                        }
                    }
                    if (req.BIRequest.Name == "Yes")
                    {
                        mailMessage.To.Add("dl-NAOracleCOE-BusinessIntelligence@ppg.com");
                    }

                    string linebreak = "<br><br>";
                    StringBuilder sb = new StringBuilder(descripcion+ link);
                    sb.Append(linebreak);
                    sb.AppendFormat("<b>Request Number:</b> {0}", req.Id);
                    sb.Append(linebreak);
                    sb.AppendFormat("<b>Requestor:</b> {0}", req.Requestor);
                    sb.Append(linebreak);
                    sb.AppendFormat("<b>Logged By:</b> {0}", req.CreatedBy);
                    sb.Append(linebreak);
                    sb.AppendFormat("<b>Project Name:</b> {0}", req.ProjectName);
                    sb.Append(linebreak);
                    sb.AppendFormat("<b>Problem/Opportunity Statement:</b> {0}", req.Problem);
                    sb.Append(linebreak);
                    sb.AppendFormat("<b>Value Description:</b> {0}", req.BenefitCase);
                    sb.Append(linebreak);
                    sb.AppendFormat("<b>Owning Stream:</b> {0}", req.OwningStream.Name);
                    sb.Append(linebreak);
                    sb.AppendFormat("<b>Status:</b> {0}", req.Status.Name);
                    sb.Append(linebreak);
                    sb.AppendFormat("<b>Enhancement Request:</b> {0}", req.CRNo);
                    Body = sb.ToString();

                //}
                //else if (type == EmailType.OwningStreamChange)
                //{
                //    mailMessage.Subject = "Owning Stream Changed on Project #" + req.Id.ToString() + (!string.IsNullOrEmpty(env) ? " in " + env + " " : "");
                //    Body = string.Format("The Owning Stream for request " + req.Id.ToString() + ", " + req.ProjectName + ", has been changed in the {0} to <b>" + req.OwningStream.Name + "<b>", link);
                //}

                mailMessage.Body = Body;

                mailMessage.IsBodyHtml = true;
                client.Send(mailMessage);
            }
        }
        private enum EmailType
        {
            NewRequestAdded,
            OwningStreamChange
           
        }

    }
}
