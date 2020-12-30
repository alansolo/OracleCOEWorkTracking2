import { Component, OnInit, ViewChild, Renderer2, AfterViewInit, NgZone, AfterViewChecked } from '@angular/core';
import { UtilService } from '../../shared/util.service';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';
import { AdminService } from '../../services/admin.service';
import { SelectListItem } from '../../models/select-list-item';
import { RequestService } from '../../services/request.service';
import { GridComponent, GridDataResult, DataStateChangeEvent, ColumnComponent } from '@progress/kendo-angular-grid';
import { process, State } from '@progress/kendo-data-query';
import { Request } from '../../models/request';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { RequestEditModalComponent } from '../../modals/request-edit-modal/request-edit-modal.component';
import { FindUserModalComponent } from '../../modals/find-user-modal/find-user-modal.component';
import { RequestView } from '../../models/request-view';
import { ActivatedRoute, Router } from '@angular/router';
import { ValidateRequiredDropdown, ValidateMultiValueDropdown } from '../../shared/custom-validators';
import { DropDownData } from '../../models/drop-down-data';
import { ToasterService } from 'angular2-toaster';
import { DatePipe } from '@angular/common';
import { StatePersistingService } from '../../services/state-persisting.service';
import { RequestNotesModalComponent } from '../../modals/request-notes-modal/request-notes-modal.component';
import { ExcelExportData } from '@progress/kendo-angular-excel-export';
import { take } from 'rxjs/operators';
import { OwningSite } from '../../models/owning-site';
import { Region } from '../../models/region';
import { Module } from '../../models/module';
import { AppName } from '../../models/application'
import { OwningStream } from '../../models/owning-stream';
import { OraclePreProdEnvironment } from '../../models/oracle-pre-prod-environment';

const matches = (el, selector) => (el.matches || el.msMatchesSelector).call(el, selector);

@Component({
  selector: 'app-manage-requests',
  templateUrl: './manage-requests.component.html',
  styleUrls: ['./manage-requests.component.css']
})
export class ManageRequestsComponent implements OnInit {
  manageRequestsForm: FormGroup;
  formSubmitAttempt: boolean;
  views: Array<RequestView>;
  selectedViewId: number;
  selectedView: RequestView;
  isLoading: boolean = true;
  isApplyingDefaultSettings: boolean = false;
  gridView: GridDataResult;
  requestArray: Array<Request>;
  formGroup: FormGroup;
  editedFormGroup: FormGroup;
  editedRequestId: number;
  editedRowIndex: number;
  editedColumnIndex: number;
  dropDownData: DropDownData;
  appmodules: Array<Module>;
  appowningSites: Array<OwningSite>;
  appowningStreams: Array<OwningStream>;
  appOraclePreProd: Array<OraclePreProdEnvironment>;

  appregions: Array<Region>;
  modalDialogOpen: boolean = false;
  openRequestsOnly: boolean = true;
  gridVisible: boolean = true;
  @ViewChild('requestsGrid') grid: GridComponent;
  @ViewChild('projectName') projectName;
  private docClickSubscription: any;

  valueMD50DueDate: Date;
  valueMD70DueDate: Date;
  valueTestingDate: Date;
  valueProductionDate: Date;

  constructor(public utilService: UtilService,
    private formBuilder: FormBuilder,
    public toasterService: ToasterService,
    private adminService: AdminService,
    private requestService: RequestService,
    private modalService: NgbModal,
    private router: Router,
    private route: ActivatedRoute,
    private renderer: Renderer2,
    private datePipe: DatePipe,
      public persistingService: StatePersistingService,
      private ngZone: NgZone)
  {
     this.allData = this.allData.bind(this);
  }

  ngOnInit() {
    this.docClickSubscription = this.renderer.listen('document', 'click', this.onDocumentClick.bind(this));
    this.route.params.subscribe(params => {
      if (params['viewId'] !== undefined) {
        this.selectedViewId = +params['viewId']
      }
      else {
        this.selectedViewId = 1;
      }
      this.formSubmitAttempt = false;
      this.initializePage();
      });

  }

  getOwningStreams(field: AppName) {
    return this.dropDownData.owningStreams;
  }

 displayFieldCss(field: string) {
    return this.utilService.displayFieldCss(this.manageRequestsForm, field, this.formSubmitAttempt);
  }

  isFieldInvalid(field: string) {
    return this.utilService.isFieldInvalid(this.manageRequestsForm, field, this.formSubmitAttempt);
  }
  //default page sizing
  public state: DataStateChangeEvent = {
    skip: 0,
    take: 25
  };

  dataStateChange(state: DataStateChangeEvent): void {
      this.state = state;
      console.log(state);
      this.persistingService.setStateRequest(this.selectedViewId, state).then(result => {
          console.log("State Saved!");
      });
      this.refreshGrid();
  }

  private initializePage() {
    this.adminService.getRequestViews().subscribe(data => {
      this.views = data.result;
      this.selectedView = this.views.find(x => x.id == this.selectedViewId);

      this.adminService.getDropDownData().subscribe(callResult => {
        this.dropDownData = callResult.result;
        this.refreshGrid();
        
        //var appId = this.manageRequestsForm['appName'].id;
        //this.repopulateDropDowns(appId);

      });
      this.persistingService.getStateRequest(this.selectedViewId).then((result: DataStateChangeEvent) => {
          console.log("Got State!");
          console.log(result);
          this.state = result;
      }).catch(e => (e));
     
    });
  }

  refreshGrid() {
        this.gridVisible = true;
        this.isLoading = true;
        this.requestService.getRequestViewData(this.selectedView.id, this.openRequestsOnly).subscribe(result => {
        this.requestArray = result.result;
        this.resetMultiValueStrings()
        this.gridView = process(this.requestArray, this.state);      
        this.applyGridSettings();
        this.isLoading = false;
      });
  }
    //private fitColumns(): void {
    //    //this.ngZone.onStable.asObservable().pipe(take(1)).subscribe(() => {
    //        this.grid.autoFitColumns();
    //    //});
    //}
  editHandler($event: any) {
    const modalRef = this.modalService.open(RequestEditModalComponent, { size: 'lg', backdrop: 'static', keyboard: false });
    modalRef.componentInstance.Request = $event.dataItem;
    modalRef.result.then((result) => {
      if (result !== 'close') {
        this.refreshGrid();
      }
    }, () => { });
  }
  cancelHandler($event : any) {
    $event.sender.closeCell();
  }

  public createFormGroup(dataItem: Request): FormGroup {

    
    //dataItem.problem = dataItem.appName.name + "*******" + dataItem.projectName;
    var appId = dataItem.appName.id;
    this.appowningSites = this.dropDownData.owningSites.filter(os => this.includes(os.appIds, appId));
    this.appregions = this.dropDownData.regions.filter(r => this.includes(r.appIds, appId));
    this.appowningStreams = this.dropDownData.owningStreams.filter(os => os.appId === appId);
    this.appmodules = this.dropDownData.modules.filter(os => this.includes(os.appIds, appId));
    this.appOraclePreProd = this.dropDownData.oraclePreProdEnvironments.filter(n => n.applicationId == appId);

    var dos = dataItem.oraclePreProdEnvironments.filter(n => n.applicationId == dataItem.applicationId);

    this.valueMD50DueDate = dataItem.mD_50_DueDate;
    this.valueMD70DueDate = dataItem.mD_70_DueDate;
    this.valueTestingDate = dataItem.testingDate;
    this.valueProductionDate = dataItem.productionDate;

    var returnDataItem = this.formBuilder.group({
      appName: [dataItem.appName, Validators.required],
      projectName: [dataItem.projectName, Validators.required],
      status: [dataItem.status, ValidateRequiredDropdown],
      problem: [dataItem.problem, Validators.required],
      benefitCase: [dataItem.benefitCase, Validators.required],
      gbsPriority: [dataItem.gbsPriority === 0 ? '' : dataItem.gbsPriority],
      coePriority: [dataItem.coePriority === 0 ? '' : dataItem.coePriority],
      regions: new FormControl(dataItem.regions, ValidateMultiValueDropdown),
      sbUs: new FormControl(dataItem.sbUs, ValidateMultiValueDropdown),
      owningStream: [dataItem.owningStream, ValidateRequiredDropdown],
      owningSite: [dataItem.owningSite],
      impactedStreams: new FormControl(dataItem.impactedStreams),
      modules: new FormControl(dataItem.modules),
      mD_50_DueDate: new FormControl(dataItem.mD_50_DueDate ? new Date(dataItem.mD_50_DueDate) : null),
      testingDate: new FormControl(dataItem.testingDate ? new Date(dataItem.testingDate) : null),
      mD_70_DueDate: new FormControl(dataItem.mD_70_DueDate ? new Date(dataItem.mD_70_DueDate) : null),
      productionDate: new FormControl(dataItem.productionDate ? new Date(dataItem.productionDate) : null),
      totalEstimate: [dataItem.totalEstimate === 0 ? '' : dataItem.totalEstimate],
      oracleDevEstimateOffShore: [dataItem.oracleDevEstimateOffShore === 0 ? '' : dataItem.oracleDevEstimateOffShore],
      oracleDevEstimateOnShore: [dataItem.oracleDevEstimateOnShore === 0 ? '' : dataItem.oracleDevEstimateOnShore],
      dcoeEstimate: [dataItem.dcoeEstimate === 0 ? '' : dataItem.dcoeEstimate],
      functionalContact: [dataItem.functionalContact],
      biContact: [dataItem.biContact],
      estimateInfra: [dataItem.estimateInfra === 0 ? '' : dataItem.estimateInfra],
      frontLineContact: [dataItem.frontLineContact],
      developmentTeams: new FormControl(dataItem.developmentTeams),
      oracleDevelopmentLead: [dataItem.oracleDevelopmentLead],
      dcoeDevelopmentLead: [dataItem.dcoeDevelopmentLead],
      mD_70: [dataItem.mD_70],
      mD_50: [dataItem.mD_50],
      tipUrl: [dataItem.tipUrl],
      oraclePreProdEnvironments: new FormControl(dataItem.oraclePreProdEnvironments),
      crNo: [dataItem.crNo === 0 ? '' : dataItem.crNo],
      ebsGateStatus: [dataItem.ebsGateStatus],
      ebsGateQuestionnaireUrl: [dataItem.ebsGateQuestionnaireUrl],
      nextEBSGate: [dataItem.nextEBSGate],
      readyForEBSGate: [dataItem.readyForEBSGate],
      biGateStatus: [dataItem.biGateStatus],
      biGateQuestionnaireUrl: [dataItem.biGateQuestionnaireUrl],
      nextBIGate: [dataItem.nextBIGate],
      readyForBIGate: [dataItem.readyForBIGate],
      _NETGateStatus: [dataItem._NETGateStatus],
      _NETGateQuestionnaireUrl: [dataItem._NETGateQuestionnaireUrl],
      next_NETGate: [dataItem.next_NETGate],
      readyFor_NETGate: [dataItem.readyFor_NETGate],
      otmebsGate: [dataItem.otmebsGate],
      otmGateQuestionnaireUrl: [dataItem.otmGateQuestionnaireUrl],
      otmGateStatus: [dataItem.otmGateStatus],
      readyForOTMGate: [dataItem.readyForOTMGate],
      requestor: [dataItem.requestor],
      biRequest: [dataItem.biRequest],
      originalSystemReference: [dataItem.originalSystemReference],
      attribute1: [dataItem.attribute1],
      attribute2: [dataItem.attribute2],
      attribute3: [dataItem.attribute3],
      attribute4: [dataItem.attribute4],
      attribute5: [dataItem.attribute5],
      attribute6: [dataItem.attribute6],
      attribute7: [dataItem.attribute7],
      attribute8: [dataItem.attribute8],
      attribute9: [dataItem.attribute9],
      attribute10: new FormControl(dataItem.attribute10 ? new Date(dataItem.attribute10) : null),
      attachments: [null]
    });
    return returnDataItem;
  };

    viewChange($event: any) {
      //this.resetFilters();
      this.gridVisible = false;
      this.router.navigate(['./requests/manage/', $event.id])
      this.persistingService.getStateRequest(this.selectedViewId).then((result: DataStateChangeEvent) => {
          this.state = result;
      }).catch(e => (e));
    }

  public cellClickHandler($event: any) {
    this.modalDialogOpen = false;
    if (this.editedFormGroup) {
      this.grid.closeCell();
      this.saveRequest(this.editedFormGroup, this.editedRequestId);
    }
    let columnType = $event.column.constructor.name;
    if (columnType !== "CommandColumnComponent") {
      this.editedFormGroup = this.createFormGroup($event.dataItem)
      this.editedRequestId = $event.dataItem.id;
      this.editedRowIndex = $event.rowIndex;
      this.editedColumnIndex = $event.columnIndex;
      $event.sender.editCell(this.editedRowIndex, this.editedColumnIndex, this.editedFormGroup)
    }
  }
  private saveRequest(fg: FormGroup, requestId: number, forceSave?: string) {
    if (fg.dirty || forceSave) {
      let r = this.convertForm(fg, requestId);
      this.requestService.saveRequest(r).subscribe((callResult) => {
        this.utilService.showErrorIfExists(this.toasterService, callResult);
        if (callResult.success) {
          let index = this.requestArray.findIndex(x => x.id === callResult.result.id);
          this.requestArray[index] = callResult.result;
          }
          this.resetMultiValueStrings()
        this.gridView = process(this.requestArray, this.state); 
      });
    }
  }

  applyGridSettings() {
    
    this.isApplyingDefaultSettings = true;
    let gridCols = this.persistingService.get<Array<any>>(window.location.href + '-' + this.selectedViewId.toString() + '-ColumnSettings1');
      setTimeout(x => {  
        if (gridCols) {
          
          //console.log(gridCols);
          //console.log(this.grid.columns.toArray());

          gridCols.forEach((col, index) => {
            let c = this.grid.columns.toArray().find(x => x.title == col.name);
            if (c == undefined) {
              //console.log("Could not find column:" + col.name);
            }
            else {
              //console.log("Showing Column: " + col.name + " " + c.isVisible + " " + col.position);
              if (c.isVisible) {
                this.grid.reorderColumn(c, col.position, { before: true });
              }
            }
        })
        
      } else {
        let cols: { name: string, position: number }[] = [];
          this.grid.columns.forEach((col, index) => {
            if (col.title) {
              let savedCol: { name: string, position: number } = { 'name': col.title, 'position': index };
              cols.push(savedCol);
            }
          })
        cols.sort((a, b) => (a.position > b.position) ? 1 : -1)
        this.persistingService.set(window.location.href + '-' + this.selectedViewId.toString() + '-ColumnSettings1', cols);
      }
      this.isApplyingDefaultSettings = false;
    }, 3000);
  }

  saveGridSettings($event: any): void {
    if ($event.newIndex != $event.oldIndex && !this.isApplyingDefaultSettings) {
      setTimeout(x => {
        var cols: { name: string, position: number }[] = [];
        let gridCols = this.grid.columns.filter(x => x.orderIndex > 0 && x.title && x.isVisible);
        gridCols = gridCols.sort((a, b) => a.orderIndex - b.orderIndex);
        gridCols.forEach((col, index) => {
          let savedCol: { name: string, position: number } = { 'name': col.title, 'position': index + 1 };
          cols.push(savedCol);
        })
        this.persistingService.set(window.location.href + '-' + this.selectedViewId.toString() + '-ColumnSettings1', cols);
      }, 3500)
    }
  }

  private onDocumentClick(e: any): void {
    if (!this.modalDialogOpen) {
      if (!matches(e.target, '#requestsGrid tbody *, #requestsGrid .k-grid-toolbar .k-button .modal-dialog')) {
        if (this.editedFormGroup && this.editedFormGroup.dirty) {
          this.saveRequest(this.editedFormGroup, this.editedRequestId);
        }
        this.closeEditor();
      }
    }
  }

  private closeEditor(): void {
    this.grid.closeCell();
    this.editedRowIndex = undefined;
    this.editedColumnIndex = undefined;
    this.editedRequestId = undefined;
    this.editedFormGroup = undefined;
  }

  public ngOnDestroy(): void {
    this.docClickSubscription();
  }


  onAppSelect(app: AppName) {
    this.repopulateDropDowns(app.id);
    
    this.editedFormGroup.controls['regions'].setValue([]);
    this.editedFormGroup.controls['modules'].setValue([]);

    //this.editedFormGroup.controls['owningSite'].setValue(0);
    //this.editedFormGroup.controls['owningStream'].setValue(0);
  }

  repopulateDropDowns(appId) {


    var appowningSites = this.dropDownData.owningSites.filter(os => this.includes(os.appIds, appId));
    //appowningSites.unshift({ id: 0, name: '' });
    this.appowningSites = appowningSites;
    
    this.appregions = this.dropDownData.regions.filter(r => this.includes(r.appIds, appId));

    var appowningStreams = this.dropDownData.owningStreams.filter(os => os.appId === appId);
    //appowningStreams.unshift({ appId: 0, id: 0, name: '', dlEmailAddress: '' });
    this.appowningStreams = appowningStreams;


    this.appmodules = this.dropDownData.modules.filter(os => this.includes(os.appIds, appId));
  }

  includes(arr, val) {
    if (arr === undefined) return false;
    return arr.indexOf(val, 0) !== -1;
  };

  changeUserControl(dataItem: any, field: string) {
    this.modalDialogOpen = true;
    this.modalService.open(FindUserModalComponent, { size: 'lg' })
      .result
      .then((result) => {

        if (result !== 'Close click') {
          this.requestService.updateRequestUserField(dataItem.id, result.displayName + ' (' + result.userId + ')', field).subscribe((callResult) => {
            this.utilService.showErrorIfExists(this.toasterService, callResult);
            this.refreshGrid();
          });
        }

      }, () => { });
  }

  clearUserControl(dataItem: any, field: string) {
      this.requestService.updateRequestUserField(dataItem.id, "", field).subscribe((callResult) => {
          this.grid.closeCell();
          this.utilService.showErrorIfExists(this.toasterService, callResult);          
          this.refreshGrid();          
      });
  }

  viewNotes(dataItem: any) {
    this.modalDialogOpen = true;
    const modalRef = this.modalService.open(RequestNotesModalComponent, { size: 'lg' });
    modalRef.componentInstance.Request = dataItem;
    modalRef.result
      .then((result) => {
        if (result !== 'Close click') {
          //console.log(result);
          //this.requestService.updateRequestUserField(dataItem.id, result.displayName + ' (' + result.userId + ')', field).subscribe((callResult) => {
          //  this.utilService.showErrorIfExists(this.toasterService, callResult);
          //  this.refreshGrid();
          //});
          //console.log(this.editedFormGroup);
        }

      }, () => { });
  }

  private convertForm(fg: FormGroup, requestId: number): Request {
    var formJson = fg.value as Request;
    var dos = formJson.oraclePreProdEnvironments.filter(n => n.applicationId == formJson.applicationId);

    let request: Request = ({
      id: requestId,
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
      attribute10: this.datePipe.transform(formJson.attribute10, "MM/dd/yyyy")
    });
   
    return request;
  }

  filterClick($event: any) {
    this.openRequestsOnly = ($event.target.value === '1');
    this.refreshGrid();
  }

  downloadAttachment(id: any) {
    this.requestService.getRequestAttachment(id);
  }

    resetFilters() {
        this.dataStateChange({ skip: 0, take: 25, filter: undefined, sort: [] });
    }

    resetMultiValueStrings() {
        this.requestArray.forEach(r => {
            r.modulesString = '';
            r.modules.forEach(m => {
                r.modulesString = (r.modulesString ? r.modulesString : '') + m.name + ' ';
            })
        });
        this.requestArray.forEach(r => {
            r.impactedStreamsString = '';
            r.impactedStreams.forEach(m => {
                r.impactedStreamsString = (r.impactedStreamsString ? r.impactedStreamsString : '') + m.name + ' ';
            })
        });
        this.requestArray.forEach(r => {
            r.sbUsString = '';
            r.sbUs.forEach(m => {
                r.sbUsString = (r.sbUsString ? r.sbUsString : '') + m.name + ' ';
            })
        });
        this.requestArray.forEach(r => {
            r.regionsString = '';
            r.regions.forEach(m => {
                r.regionsString = (r.regionsString ? r.regionsString : '') + m.name + ' ';
            })
        });
        this.requestArray.forEach(r => {
            r.oraclePreProdEnvironmentsString = '';
            r.oraclePreProdEnvironments.forEach(m => {
                r.oraclePreProdEnvironmentsString = (r.oraclePreProdEnvironmentsString ? r.oraclePreProdEnvironmentsString : '') + m.name + ' ';
            })
        });
        this.requestArray.forEach(r => {
            r.developmentTeamsString = '';
            r.developmentTeams.forEach(m => {
                r.developmentTeamsString= (r.developmentTeamsString ? r.developmentTeamsString : '') + m.name + ' ';
            })
        });
    }

    public allData(): ExcelExportData {
        let stateCopy = { ...this.state };
        stateCopy.skip = 0;
        stateCopy.take = this.requestArray.length;
        const result: ExcelExportData = {
            data: process(this.requestArray, stateCopy).data
        };

        return result;
    }


  public ValidMD70DueDate() {
    var formJson = this.editedFormGroup.value as Request;

    if (formJson.mD_50_DueDate === null) {
      return true;
    }
    else {
      return false;
    }
  }

  public ValidTestingDate() {
    var formJson = this.editedFormGroup.value as Request;

    if (formJson.mD_70_DueDate === null) {
      return true;
    }
    else {
      return false;
    }
  }

  public ValidProductionDate() {
    var formJson = this.editedFormGroup.value as Request;

    if (formJson.testingDate === null) {
      return true;
    }
    else {
      return false;
    }
  }


}
