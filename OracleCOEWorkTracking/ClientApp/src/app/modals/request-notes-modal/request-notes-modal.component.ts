import { Component, OnInit, Input, ViewChild } from '@angular/core';
import { NgbModal, NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { UtilService } from '../../shared/util.service';
import { RequestService } from '../../services/request.service';
import { ValidateMultiValueDropdown, ValidateRequiredDropdown } from '../../shared/custom-validators';
import { Request } from '../../models/request';
import { FindUserModalComponent } from '../find-user-modal/find-user-modal.component';
import { DatePipe } from '@angular/common';
import { ToasterService } from 'angular2-toaster';
import { RequestNote } from '../../models/request-note';
import { GridDataResult, DataStateChangeEvent } from '@progress/kendo-angular-grid';
import { process, State } from '@progress/kendo-data-query';

@Component({
  selector: 'app-request-notes-modal',
  templateUrl: './request-notes-modal.component.html',
  styleUrls: ['./request-notes-modal.component.css']
})
export class RequestNotesModalComponent implements OnInit {
  @Input() Request: Request;
  addRequestNoteForm: FormGroup;
  isLoading: boolean = true;
  formSubmitAttempt: boolean = false;
  gridView: GridDataResult;
  requestNotesArray: Array<RequestNote>;
  constructor(public utilService: UtilService,
    public toasterService: ToasterService,
    private formBuilder: FormBuilder,
    private requestService: RequestService,
    public activeModal: NgbActiveModal,
    private modalService: NgbModal,
    private datePipe: DatePipe) {   
  }


  ngOnInit() {
    console.log(this.Request);
    this.refreshGrid();
    this.isLoading = false;

    this.addRequestNoteForm = this.formBuilder.group({
      note: [null, Validators.required]
    })

  }

  public createAttributeFormGroup(dataItem: any): FormGroup {
    return this.formBuilder.group({
      attribute: dataItem.attribute,
      value: dataItem.value,
      requestId: this.Request.id
    });
  };

  displayFieldCss(field: string) {
    return this.utilService.displayFieldCss(this.addRequestNoteForm, field, this.formSubmitAttempt);
  }

  isFieldInvalid(field: string) {
    return this.utilService.isFieldInvalid(this.addRequestNoteForm, field, this.formSubmitAttempt);
  }


  public saveRequestNote() {
    console.log('submit executed');
    if (!this.addRequestNoteForm.valid) {
      console.log('form invalid??');
      this.formSubmitAttempt = true;
      return;
    }
    var req = this.convertForm();
    console.log(req);
    this.requestService.addRequestNote(req).subscribe(result => {
      console.log(result);
      this.utilService.showErrorIfExists(this.toasterService, result);
      if (result.success) {
        this.refreshGrid();
      }
      this.formSubmitAttempt = false;
    });
  }

  refreshGrid() {
    this.isLoading = true;
    this.requestService.getRequestNotes(this.Request.id).subscribe(result => {
      this.requestNotesArray = result.result;
      this.gridView = process(this.requestNotesArray, this.state);
      this.addRequestNoteForm.controls['note'].setValue('');
      this.isLoading = false;
    });
  }
  //default page sizing
  public state: DataStateChangeEvent = {
    skip: 0,
    take: 1000
  };
  private convertForm(): RequestNote {
    var formJson = this.addRequestNoteForm.value as RequestNote;
    console.log(formJson);
    let requestNote: RequestNote = ({
      requestId: this.Request.id,
      note: formJson.note,     
    });
    return requestNote;
  }

  cancelAndClose() {
    this.activeModal.close();
  }

}
