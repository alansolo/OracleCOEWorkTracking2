import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormArray, FormControl } from '@angular/forms';
import { UtilService } from '../../shared/util.service';
import { AdminService } from '../../services/admin.service';
import { User } from '../../models/user';
import { OwningSite } from '../../models/owning-site';
import { OwningStream } from '../../models/owning-stream';
import { SelectListItem } from '../../models/select-list-item';
import { UserService } from '../../services/user.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { FindUserModalComponent } from '../../modals/find-user-modal/find-user-modal.component';
import { AddRequest } from './../../models/request';
import { RequestService } from '../../services/request.service';
import { ToasterService } from 'angular2-toaster';
import { ValidateRequiredDropdown, ValidateMultiValueDropdown } from '../../shared/custom-validators';
import { RouterLink, Router } from '@angular/router';
import { RequestConfirmationModalComponent } from '../../modals/request-confirmation-modal/request-confirmation-modal.component';
import { AppName } from '../../models/application';
import { Http } from '@angular/http';
import { HttpClient } from 'selenium-webdriver/http';

@Component({
  selector: 'app-add-request',
  templateUrl: './add-request.component.html',
  styleUrls: ['./add-request.component.css']
})
export class AddRequestComponent implements OnInit {
  addRequestForm: FormGroup;
  dropDownRegionList = [];
  dropDownSBUList = [];
  selectedRegionItems = [];
  selectedSBUItems = [];
  multiDropDownSettings = {};
  singleDropDownSettings = {};
  owningStreams: Array<SelectListItem>;
  owningSites: Array<OwningSite>;
  appNames: Array<AppName>;
  allRegionList = [];
  allOwningStreams: Array<OwningStream>;
  allOwningSites: Array<OwningSite>;
  requestor: User;
  selectedFile: File;
  fileList: File[] = [];
  listOfFiles: any[] = [];
  http: HttpClient;

  formSubmitAttempt: boolean;
  @ViewChild("firstInput") firstInputRef: ElementRef;
  @ViewChild('attachments') attachment: any;

  constructor(private formBuilder: FormBuilder,
    private adminService: AdminService,
    public utilService: UtilService,
    private userService: UserService,
    private requestService: RequestService,
    public toasterService: ToasterService,
    private modalService: NgbModal,
    private router: Router) { }

  ngOnInit() {
    this.addRequestForm = this.formBuilder.group({
      appName: [null, ValidateRequiredDropdown],
      projectName: [null, Validators.required],
      problem: [null, Validators.required],
      benefitCase: [null, Validators.required],
      regions: new FormControl([], ValidateMultiValueDropdown),
      sbus: new FormControl([], ValidateMultiValueDropdown),
      owningStream: [null, ValidateRequiredDropdown],
      owningSite: [null],
      requestor: [null],
      biRequestId: [null],
      originalSystemReference: [null],
      attachments: [null]
    });

    this.initializeForm();

    //this.firstInputRef.isDefaultFocus = true;

  }


  private initializeForm() {
    this.adminService.getAppNames().subscribe(data => {
      //debugger;
      //console.debug("app name data: " + data.result);
      this.appNames = this.utilService.initializeDropdown(data.result, this.addRequestForm.controls['appName']);
    });

    this.multiDropDownSettings = {
      singleSelection: false,
      idField: 'id',
      textField: 'name',
      selectAllText: 'Select All',
      unSelectAllText: 'UnSelect All',
      itemsShowLimit: 4,
      allowSearchFilter: false
    };
    this.adminService.getRegions().subscribe(callResult => {
      this.allRegionList = callResult.result;
    });
    this.adminService.getSBUs().subscribe(callResult => {
      this.dropDownSBUList = callResult.result;
    });
    this.adminService.getOwningSites().subscribe(data => {
      this.allOwningSites = this.utilService.initializeDropdown(data.result, this.addRequestForm.controls['owningSite']);
    });
    this.adminService.getOwningStreams().subscribe(callResult => {
      //this.allOwningStreams = this.utilService.initializeDropdown(data.result, this.addRequestForm.controls['owningStream']);
      this.allOwningStreams = callResult.result;
    });
    this.userService.getCurrentUser().subscribe(callResult => {
      console.log(callResult.result);
      this.requestor = callResult.result;
    });
    //this.addRequestForm.controls['biRequest'].setValue('false');
    this.addRequestForm.controls['projectName'].setValue('');
    this.addRequestForm.controls['problem'].setValue('');
    this.addRequestForm.controls['benefitCase'].setValue('');
    this.addRequestForm.controls['regions'].setValue([]);
    this.addRequestForm.controls['sbus'].setValue([]);
    this.addRequestForm.controls['owningStream'].setValue(null);
    this.addRequestForm.controls['owningSite'].setValue(null);
    this.addRequestForm.controls['biRequestId'].setValue('0');
    this.addRequestForm.controls['originalSystemReference'].setValue('');
    this.addRequestForm.controls['attachments'].setValue(null);
    this.fileList = [];
    this.listOfFiles = [];
  }

  submitRequest() {
    if (!this.addRequestForm.valid) {
      this.formSubmitAttempt = true;
      return;
    }

    var req = this.convertForm();
    console.log(req);

    this.requestService.addRequest(req).subscribe(callResult => {
      if (callResult.success) {
        console.log(callResult);
        console.log(this.fileList);
        if (this.fileList.length > 0) {
          this.requestService.addRequestAttachments(this.fileList, callResult.result.id).subscribe(callResult => {
            
            if (callResult.success) {
              this.initializeForm();
              const modalRef = this.modalService.open(RequestConfirmationModalComponent, { size: 'lg' });
              modalRef.componentInstance.Request = callResult.result;
              console.log(modalRef.componentInstance.Request);
            }
          })
        }
        else {
        this.initializeForm();
        const modalRef = this.modalService.open(RequestConfirmationModalComponent, { size: 'lg' });
        modalRef.componentInstance.Request = callResult.result;
        }
      }
      this.formSubmitAttempt = false;
    });
  }
  changeRequestorHandler($event: any) {
    this.modalService.open(FindUserModalComponent, { size: 'lg' })
      .result
      .then((result) => {
        if (result !== 'Close click') {
          this.requestor = result;
        }
      }, () => { });
  }


  includes(arr, val) {
    if (arr === undefined) return false;
    return arr.indexOf(val, 0) !== -1;
  };

  onAppSelect(event: any) {
    var app = this.addRequestForm.controls['appName'].value;
   
    var appOwningStreams = this.allOwningStreams.filter(function (ownstr) {
      return ownstr.appId == app.id;
    });

    this.owningStreams = this.utilService.initializeDropdown(appOwningStreams, this.addRequestForm.controls['owningStream']);

    var appRegions = this.allRegionList.filter(r => this.includes(r.appIds, app.id));
    this.dropDownRegionList = appRegions;

    var appOwningSites = this.allOwningSites.filter(os => this.includes(os.appIds, app.id));
    this.owningSites = this.utilService.initializeDropdown(appOwningSites, this.addRequestForm.controls['owningSite']);

    this.addRequestForm.controls['regions'].setValue([]);
    this.addRequestForm.controls['owningSite'].setValue(null);
    this.addRequestForm.controls['owningStream'].setValue(null);
  }


  onFileChanged(event: any) {
   
    for (var i = 0; i <= event.target.files.length - 1; i++) {
      var selectedFile = event.target.files[i];
      this.fileList.push(selectedFile);
      this.listOfFiles.push(selectedFile.name)
    }

    this.attachment.nativeElement.value = '';
    console.log(this.fileList);
  }

  removeSelectedFile(index) {
    // Delete the item from fileNames list
    this.listOfFiles.splice(index, 1);
    // delete file from FileList
    this.fileList.splice(index, 1);
  }

  openFileBrowser(event: any) {
    event.preventDefault();
    let element: HTMLElement = document.getElementById('attachments') as HTMLElement;
    element.click();
  }

  private convertForm(): AddRequest {
    var formJson = this.addRequestForm.value as AddRequest;
    console.log(formJson.biRequestId);
    let request: AddRequest = ({
      id: null,
      appName: formJson.appName,
      projectName: formJson.projectName,
      problem: formJson.problem,
      benefitCase: formJson.benefitCase,
      regions: formJson.regions,
      sbus: formJson.sbus,
      owningSite: formJson.owningSite,
      owningStream: formJson.owningStream,
      biRequestId: formJson.biRequestId,
      originalSystemReference: formJson.originalSystemReference,
      requestor: this.requestor.displayName + ' (' + this.requestor.userId + ')'
    });
    return request;
  }

  displayFieldCss(field: string) {
    return this.utilService.displayFieldCss(this.addRequestForm, field, this.formSubmitAttempt);
  }

  isFieldInvalid(field: string) {
    return this.utilService.isFieldInvalid(this.addRequestForm, field, this.formSubmitAttempt);
  }

}
