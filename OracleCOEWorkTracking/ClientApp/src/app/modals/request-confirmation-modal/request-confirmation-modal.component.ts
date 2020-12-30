import { Component, OnInit, Input } from '@angular/core';
import { NgbModal, NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-request-confirmation-modal',
  templateUrl: './request-confirmation-modal.component.html',
  styleUrls: ['./request-confirmation-modal.component.css']
})
export class RequestConfirmationModalComponent implements OnInit {
  @Input() public Request;
  constructor(public activeModal: NgbActiveModal) {   
  }


  ngOnInit() {

  }

}
