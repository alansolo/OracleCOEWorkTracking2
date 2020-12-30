import { Component, OnInit, Input, ViewChild } from '@angular/core';
import { NgbModal, NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { UtilService } from '../../shared/util.service';
import { AdminService } from '../../services/admin.service';
import { RequestService } from '../../services/request.service';
import { ValidateMultiValueDropdown, ValidateRequiredDropdown } from '../../shared/custom-validators';
import { DropDownData } from '../../models/drop-down-data';
import { Request } from '../../models/request';
import { FindUserModalComponent } from '../find-user-modal/find-user-modal.component';
import { DatePipe } from '@angular/common';
import { ToasterService } from 'angular2-toaster';
import { RequestNotesModalComponent } from '../request-notes-modal/request-notes-modal.component';
import { OwningSite } from '../../models/owning-site';
import { Region } from '../../models/region';
import { Module } from '../../models/module';
import { SelectListItem } from '../../models/select-list-item';
import { AppName } from '../../models/application';
//import { request } from 'http';
@Component({
  selector: 'app-request-edit-modal',
  templateUrl: './request-edit-modal.component.html',
  styleUrls: ['./request-edit-modal.component.css']
})
export class RequestEditModalComponent implements OnInit {
  @Input() Request: Request;
  isLoading: boolean = true;
  editRequestForm: FormGroup;
  dropDownData: DropDownData;
  formSubmitAttempt: boolean = false;
  multiDropDownSettings: {};
  selectedFile: File;
  fileList: File[] = [];
  listOfFiles: any[] = [];
  filesToKeep: number[] = [];
  
  regions: Array<Region>;
  owningStreams: Array<SelectListItem>;
  owningSites: Array<OwningSite>;
  modules: Array<Module>;

  valueMD50DueDate: Date;
  valueMD70DueDate: Date;
  valueTestingDate: Date;
  valueProductionDate: Date;

  constructor(public utilService: UtilService,
    public toasterService: ToasterService,
    private formBuilder: FormBuilder,
    private adminService: AdminService,
    private requestService: RequestService,
    public activeModal: NgbActiveModal,
    private modalService: NgbModal,
    private datePipe: DatePipe) {   
  }

  onAppSelect(appName :  AppName) {
    
    var appId = this.editRequestForm.controls['appName'].value;
    var origId = this.Request.appName.id
    
    if (appId != origId) {
      this.editRequestForm.controls['regions'].setValue([]);
      this.editRequestForm.controls['modules'].setValue([]);     

      this.editRequestForm.controls['owningSite'].setValue(0);
      this.editRequestForm.controls['owningStream'].setValue(0);     

      this.repopulateDropDowns(appId.id);
    }
  }

  repopulateDropDowns(appId) {
    var appOwningSites = this.dropDownData.owningSites.filter(os => this.includes(os.appIds, appId));
    appOwningSites.unshift({ id: 0, name: '' });
    this.owningSites = appOwningSites;//this.utilService.initializeDropdown(appOwningSites, this.editRequestForm.controls['owningSite']);

    //OwningStreams
    var appOwningStreams = this.dropDownData.owningStreams.filter(os => os.appId === appId);
    appOwningStreams.unshift({ appId: 0, id: 0, name: '', dlEmailAddress:'' });
    this.owningStreams = appOwningStreams;//this.utilService.initializeDropdown(appOwningStreams, this.editRequestForm.controls['owningStream']);

    //ImpactedStreams
    var appImpactedStreams = this.dropDownData.impactedStreams.filter(os => os.appId === appId);
    this.dropDownData.impactedStreams = appImpactedStreams;

    //multi-select
    this.modules = this.dropDownData.modules.filter(os => this.includes(os.appIds, appId));
    this.regions = this.dropDownData.regions.filter(r => this.includes(r.appIds, appId));

    this.dropDownData.oraclePreProdEnvironments = this.dropDownData.oraclePreProdEnvironments.filter(n => n.applicationId == appId);

    this.dropDownData.applicationAttributes = this.dropDownData.applicationAttributes.filter(n => n.applicationId == appId);

    if (this.dropDownData.applicationAttributes.length > 0) {
      this.dropDownData.applicationAttributesSelect = this.dropDownData.applicationAttributes[0];
    }
  }
  
  includes(arr, val) {
    if (arr === undefined) return false;
    return arr.indexOf(val, 0) !== -1;
  };
  ngOnInit() {
    console.log(this.Request);
    this.multiDropDownSettings = {
      singleSelection: false,
      idField: 'id',
      textField: 'name',
      selectAllText: 'Select All',
      unSelectAllText: 'UnSelect All',
      itemsShowLimit: 4,
      allowSearchFilter: false
    };



    this.adminService.getDropDownData().subscribe(callResult => {
      this.dropDownData = callResult.result;
      var appId = this.Request['appName'].id;     
      this.repopulateDropDowns(appId);
    });
    this.isLoading = false;
    this.editRequestForm = this.formBuilder.group({
      appName: [this.Request.appName, Validators.required],
      projectName: [this.Request.projectName, Validators.required],
      status: [this.Request.status, ValidateRequiredDropdown],
      problem: [this.Request.problem, Validators.required],
      benefitCase: [this.Request.benefitCase, Validators.required],
      gbsPriority: [this.Request.gbsPriority === 0 ? '' : this.Request.gbsPriority],
      coePriority: [this.Request.coePriority === 0 ? '' : this.Request.coePriority],
      regions: new FormControl(this.Request.regions, ValidateMultiValueDropdown),
      sbUs: new FormControl(this.Request.sbUs, ValidateMultiValueDropdown),
      owningStream: [this.Request.owningStream, ValidateRequiredDropdown],
      owningSite: [this.Request.owningSite],
      impactedStreams: new FormControl(this.Request.impactedStreams),
      modules: new FormControl(this.Request.modules),
      mD_50_DueDate: new FormControl(this.Request.mD_50_DueDate ? new Date(this.Request.mD_50_DueDate): null),
      testingDate: new FormControl(this.Request.testingDate ? new Date(this.Request.testingDate): null),
      mD_70_DueDate: new FormControl(this.Request.mD_70_DueDate ? new Date(this.Request.mD_70_DueDate): null),
      productionDate: new FormControl(this.Request.productionDate ? new Date(this.Request.productionDate): null),
      totalEstimate: [this.Request.totalEstimate === 0 ? '' : this.Request.totalEstimate],
      oracleDevEstimateOffShore: [this.Request.oracleDevEstimateOffShore === 0 ? '': this.Request.oracleDevEstimateOffShore],
      oracleDevEstimateOnShore: [this.Request.oracleDevEstimateOnShore === 0 ? '': this.Request.oracleDevEstimateOnShore],
      dcoeEstimate: [this.Request.dcoeEstimate === 0 ? '' : this.Request.dcoeEstimate],
      functionalContact: [this.Request.functionalContact],
      biContact: [this.Request.biContact],
      estimateInfra: [this.Request.estimateInfra === 0 ? '' : this.Request.estimateInfra],
      frontLineContact: [this.Request.frontLineContact],
      developmentTeams: new FormControl(this.Request.developmentTeams),
      oracleDevelopmentLead: [this.Request.oracleDevelopmentLead],
      dcoeDevelopmentLead: [this.Request.dcoeDevelopmentLead],
      mD_70: [this.Request.mD_70],
      mD_50: [this.Request.mD_50],
      tipUrl: [this.Request.tipUrl],
      oraclePreProdEnvironments: new FormControl(this.Request.oraclePreProdEnvironments),
      dateRequested: this.Request.createdOn ? this.Request.createdOn : null,
      crNo: [this.Request.crNo === 0 ? '' : this.Request.crNo],
      modifiedBy: [this.Request.modifiedBy],
      dateModified: this.Request.modifiedOn ? this.Request.modifiedOn : null,
      ebsGateStatus: [this.Request.ebsGateStatus],
      ebsGateQuestionnaireUrl: [this.Request.ebsGateQuestionnaireUrl],
      nextEBSGate: [this.Request.nextEBSGate],
      readyForEBSGate: [this.Request.readyForEBSGate],
      biGateStatus: [this.Request.biGateStatus],
      biGateQuestionnaireUrl: [this.Request.biGateQuestionnaireUrl],
      nextBIGate: [this.Request.nextBIGate],
      readyForBIGate: [this.Request.readyForBIGate],
      _NETGateStatus: [this.Request._NETGateStatus],
      _NETGateQuestionnaireUrl: [this.Request._NETGateQuestionnaireUrl],
      next_NETGate: [this.Request.next_NETGate],
      readyFor_NETGate: [this.Request.readyFor_NETGate],
      otmebsGate: [this.Request.otmebsGate],
      otmGateQuestionnaireUrl: [this.Request.otmGateQuestionnaireUrl],
      otmGateStatus: [this.Request.otmGateStatus],
      readyForOTMGate: [this.Request.readyForOTMGate],
      requestor: [this.Request.requestor],
      biRequest: [this.Request.biRequest],
      originalSystemReference: [this.Request.originalSystemReference],
      attribute1: [this.Request.attribute1],
      attribute2: [this.Request.attribute2],
      attribute3: [this.Request.attribute3],
      attribute4: [this.Request.attribute4],
      attribute5: [this.Request.attribute5],
      attribute6: [this.Request.attribute6],
      attribute7: [this.Request.attribute7],
      attribute8: [this.Request.attribute8],
      attribute9: [this.Request.attribute9],
      attribute10: new FormControl(this.Request.attribute10 ? new Date(this.Request.attribute10) : null),
      attachments: [null]
    });
    this.listOfFiles = this.Request.attachments.map(m => m.fileName);
    this.filesToKeep = this.Request.attachments.map(m => m.id);


    //this.initializeForm();
  }

  //private initializeForm() {
  //  debugger;
  //  var editApp = this.editRequestForm.controls['appName'].value;
 //   //this.editRequestForm.controls['owningSites'].value = 
//  }

  displayFieldCss(field: string) {
    return this.utilService.displayFieldCss(this.editRequestForm, field, this.formSubmitAttempt);
  }

  isFieldInvalid(field: string) {
    return this.utilService.isFieldInvalid(this.editRequestForm, field, this.formSubmitAttempt);
  }

  changeUserControl(controlName: string) {
    this.modalService.open(FindUserModalComponent, { size: 'lg' })
      .result
      .then((result) => {
        if (result !== 'Close click') {
          console.log(result);
          this.editRequestForm.controls[controlName].setValue(result.displayName + ' (' + result.userId + ')');
        }
      }, () => { });
  }

  clearUserControl(controlName: string) {
      this.editRequestForm.controls[controlName].setValue("");
  }

  public saveRequest() {
    console.log('submit executed');
    if (!this.editRequestForm.valid) {
      console.log('form invalid??');
      this.formSubmitAttempt = true;
      return;
    }
    var req = this.convertForm();
    
    console.log(req);
    this.requestService.saveRequest(req).subscribe(result => {
        if (result.success) {
            this.requestService.updateRequestAttachments(this.fileList, this.filesToKeep, this.Request.id).subscribe(result => {
                if (result.success) {
                    console.log(result);
                    this.utilService.showFeedback(this.toasterService, result);
                    this.activeModal.close();
                }
            });
      }
      this.formSubmitAttempt = false;
    });
  }

  private convertForm(): Request {
    var formJson = this.editRequestForm.value as Request;
    console.log(formJson);
    let request: Request = ({
      id: this.Request.id,
      applicationId: formJson.applicationId,
      appName: formJson.appName,
      projectName: formJson.projectName,
      status: formJson.status,
      statusId: formJson.status.id,
      problem: formJson.problem,
      benefitCase: formJson.benefitCase,
      gbsPriority: formJson.gbsPriority,
      coePriority: formJson.coePriority,
      regions: formJson.regions,
      sbUs: formJson.sbUs,
      owningStreams: formJson.owningStreams,
      owningSite: formJson.owningSite,
      owningStream: formJson.owningStream,
      owningStreamId: formJson.owningStream.id,
      impactedStreams: formJson.impactedStreams,
      modules: formJson.modules,
      mD_50_DueDate: formJson.mD_50_DueDate,
      mD_70_DueDate: formJson.mD_70_DueDate,
      testingDate: formJson.testingDate,
      productionDate: formJson.productionDate,
      oracleDevEstimateOffShore: formJson.oracleDevEstimateOffShore ? formJson.oracleDevEstimateOffShore : 0,
      oracleDevEstimateOnShore: formJson.oracleDevEstimateOnShore ? formJson.oracleDevEstimateOnShore : 0,
      dcoeEstimate: formJson.dcoeEstimate ? formJson.dcoeEstimate : 0,
      totalEstimate: formJson.totalEstimate ? formJson.totalEstimate : 0,
      requestor: formJson.requestor,
      biContact: formJson.biContact,
      frontLineContact: formJson.frontLineContact,
      functionalContact: formJson.functionalContact,
      estimateInfra: formJson.estimateInfra,
      developmentTeams: formJson.developmentTeams,
      dcoeDevelopmentLead: formJson.dcoeDevelopmentLead,
      oracleDevelopmentLead: formJson.oracleDevelopmentLead,
      mD_50: formJson.mD_50,
      mD_70: formJson.mD_70,
      tipUrl: formJson.tipUrl,
      oraclePreProdEnvironments: formJson.oraclePreProdEnvironments,
      biRequest: formJson.biRequest,
      biRequestId: formJson.biRequest.id,
      originalSystemReference: formJson.originalSystemReference,
      crNo: formJson.crNo,
      ebsGateStatus: formJson.ebsGateStatus,
      ebsGateQuestionnaireUrl: formJson.ebsGateQuestionnaireUrl,
      nextEBSGate: formJson.nextEBSGate,
      readyForEBSGate: formJson.readyForEBSGate,
      biGateStatus: formJson.biGateStatus,
      biGateQuestionnaireUrl: formJson.biGateQuestionnaireUrl,
      nextBIGate: formJson.nextBIGate,
      readyForBIGate: formJson.readyForBIGate,
      _NETGateStatus: formJson._NETGateStatus,
      _NETGateQuestionnaireUrl: formJson._NETGateQuestionnaireUrl,
      next_NETGate: formJson.next_NETGate,
      readyFor_NETGate: formJson.readyFor_NETGate,
      otmGateStatus: formJson.otmGateStatus,
      otmGateQuestionnaireUrl: formJson.otmGateQuestionnaireUrl,
      otmebsGate: formJson.otmebsGate,
      readyForOTMGate: formJson.readyForOTMGate,
      attribute1: formJson.attribute1,
      attribute2: formJson.attribute2,
      attribute3: formJson.attribute3,
      attribute4: formJson.attribute4,
      attribute5: formJson.attribute5,
      attribute6: formJson.attribute6,
      attribute7: formJson.attribute7,
      attribute8: formJson.attribute8,
      attribute9: formJson.attribute9,
      attribute10: this.datePipe.transform(formJson.attribute10, "MM/dd/yyyy"),
    });
    return request;
  }

  cancelAndClose() {
    this.activeModal.close();
  }

  viewNotes() {
    const modalRef = this.modalService.open(RequestNotesModalComponent, { size: 'lg' });
    modalRef.componentInstance.Request = this.Request;
    modalRef.result
      .then((result) => {
        if (result !== 'Close click') {
        }

      }, () => { });
  }

  handleFileInput(event: any) {
      for (var i = 0; i <= event.target.files.length - 1; i++) {
          var selectedFile = event.target.files[i];
          this.fileList.push(selectedFile);
          this.listOfFiles.push(selectedFile.name)
      }
  }

  removeSelectedFile(index) {
      this.filesToKeep.splice(index, 1);
      // Delete the item from fileNames list
      this.listOfFiles.splice(index, 1);
      // delete file from FileList
      this.fileList.splice(index, 1);
  }

  public ValidMD70DueDate() {
    var formJson = this.editRequestForm.value as Request;

    if (formJson.mD_50_DueDate === null) {
      return true;
    }
    else {
      return false;
    }
  }

  public ValidTestingDate() {
    var formJson = this.editRequestForm.value as Request;

    if (formJson.mD_70_DueDate === null) {
      return true;
    }
    else {
      return false;
    }
  }

  public ValidProductionDate() {
    var formJson = this.editRequestForm.value as Request;

    if (formJson.testingDate === null) {
      return true;
    }
    else {
      return false;
    }
  }

}
