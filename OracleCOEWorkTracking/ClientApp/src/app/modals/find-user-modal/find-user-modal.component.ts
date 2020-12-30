import { Component, OnInit } from '@angular/core';
import { CompleterService, CompleterData, CompleterItem } from 'ng2-completer';
import { ToasterService } from 'angular2-toaster';
import { FormGroup, FormBuilder, Validators, FormControl, AbstractControl } from '@angular/forms';

import { NgbModal, NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { User } from '../../models/user';
import { UtilService } from '../../shared/util.service';




@Component({
  selector: 'app-find-user-modal',
  templateUrl: './find-user-modal.component.html',
  styleUrls: ['./find-user-modal.component.css']
})
export class FindUserModalComponent implements OnInit {

  public searchStr: string;
  public dataService: CompleterData;
  private adSearchURL = 'api/admin/searchusers?searchTerm=';


  public findUserForm: FormGroup;
  //public newUser: User;
  public formSubmitAttempt: boolean;


  constructor(public activeModal: NgbActiveModal,
    public completerService: CompleterService,
    private formBuilder: FormBuilder,
    private utilService: UtilService) {
    this.dataService = completerService.remote(this.adSearchURL, 'displayName', 'displayName');
  }
  
  selectUser() {
    this.formSubmitAttempt = true;
    if (!this.findUserForm.valid) {
      return;
    }    
    this.activeModal.close(this.convertForm());
  }

  userSelected(selected: CompleterItem) {
    const selectedUser = selected.originalObject;
    this.findUserForm.setValue({
      'displayName': selectedUser.displayName,
      'email': selectedUser.email,
      'userId': selectedUser.userId,
    });
  }

  isFieldInvalid(field: string) {
    return this.utilService.isFieldInvalid(this.findUserForm, field, this.formSubmitAttempt);
  }

  isDropdownFieldInvalid(field: string) {
    return this.utilService.isDropdownFieldInvalid(this.findUserForm, field, this.formSubmitAttempt);
  }

  displayFieldCss(field: string) {
    return this.utilService.displayFieldCss(this.findUserForm, field, this.formSubmitAttempt);
  }

  displayDropdownFieldCss(field: string) {
    return this.utilService.displayDropdownFieldCss(this.findUserForm, field, this.formSubmitAttempt);
  }

  ngOnInit() {
    this.findUserForm = this.formBuilder.group({
      displayName: [null, null],
      userId: [null, null],
      email: [null, null]
    });
  }

  private convertForm(): User {
    let formJson = this.findUserForm.value;
    let user: User = {
      displayName: formJson.displayName,
      email: formJson.email,
      userId: formJson.userId,
      role: 0
    };
    return user;
  }
}
