import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { AddRequest } from './../models/request';
import { Observable } from 'rxjs/Observable';
import { ServiceCallResult } from '../models/service-call-result';
import { Request } from '../models/request';
import { RequestNote } from '../models/request-note';
import { FormGroup } from '@angular/forms';
import { pipe } from 'rxjs';
import { map } from 'rxjs/operators';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

const singlePipe = itemData => {
    itemData.result.mD_50_DueDate = convertDate(itemData.result.mD_50_DueDate);
    itemData.result.mD_70_DueDate = convertDate(itemData.result.mD_70_DueDate);
    itemData.result.productionDate = convertDate(itemData.result.productionDate);
    itemData.result.testingDate = convertDate(itemData.result.testingDate);
    itemData.result.createdOn = convertDate(itemData.result.createdOn);
    itemData.result.modifiedOn = convertDate(itemData.result.modifiedOn);
    return itemData;
};

const multiPipe = itemData => {
    itemData.mD_50_DueDate = convertDate(itemData.mD_50_DueDate);
    itemData.mD_70_DueDate = convertDate(itemData.mD_70_DueDate);
    itemData.productionDate = convertDate(itemData.productionDate);
    itemData.testingDate = convertDate(itemData.testingDate);
    itemData.createdOn = convertDate(itemData.createdOn);
    itemData.modifiedOn = convertDate(itemData.modifiedOn);
    return itemData;
};

function convertDate(str: string) {
    if (str == null) {
        return "";
    }
    else if (str !== "") {
        return new Date(str);
    }
    else {
        return str;
    }
}

@Injectable()
export class RequestService {

  constructor(private http: HttpClient) { }

  private _urls = {
    addRequest: 'api/request/addrequest',
    getRequestViewData: 'api/request/getRequestViewData',
    getAllRequests: 'api/request/getAllRequests',
    getAllRequestsViewData: 'api/request/getAllRequestsViewData',
    saveRequest: 'api/request/updateRequest',
    updateRequestUserField: 'api/request/updaterequestuserfield',
    addRequestNote: 'api/request/addrequestnote',
    getRequestNotes: 'api/request/getrequestnotes',
    addRequestAttachment: 'api/request/addrequestattachment',
    updateRequestAttachment: 'api/request/updaterequestattachments',
    getRequestAttachment: 'api/request/getrequestattachment',
  };

  addRequest(request: AddRequest): Observable<ServiceCallResult<AddRequest>> {
    return this.http.post<ServiceCallResult<AddRequest>>(this._urls.addRequest, request, { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) });
  }

  addRequestNote(requestNote: RequestNote): Observable<ServiceCallResult<RequestNote>> {
    return this.http.post<ServiceCallResult<RequestNote>>(this._urls.addRequestNote, requestNote, { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) });
  }

  addRequestAttachments(files: File[], requestId: number): Observable<ServiceCallResult<Request>> {
    const formData: FormData = new FormData();
    formData.append('id', requestId.toString());
    for (let i = 0; i < files.length; i++) {
      formData.append('file-'+i.toString(), files[i], files[i].name);
    }
    console.log(formData);
    return this.http.post<ServiceCallResult<Request>>(this._urls.addRequestAttachment, formData);
  }

  updateRequestAttachments(files: File[], idsToKeep: number[], requestId: number): Observable<ServiceCallResult<Request>> {
      const formData: FormData = new FormData();
      formData.append('id', requestId.toString());
      for (let i = 0; i < files.length; i++) {
          formData.append('file-' + i.toString(), files[i], files[i].name);
      }
      for (let id of idsToKeep) {
          formData.append('keep', id.toString());
      }
      console.log(formData);
      return this.http.post<ServiceCallResult<Request>>(this._urls.updateRequestAttachment, formData);
  }

  saveRequest(request: Request): Observable<ServiceCallResult<Request>> {
      return this.http.post<ServiceCallResult<Request>>(this._urls.saveRequest, request, { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) }).pipe(map(singlePipe));
  }

  updateRequestUserField(requestId: number, user: string, fieldName: string): Observable<ServiceCallResult<boolean>> {
    let Params = new HttpParams();
    Params = Params.append('requestId', requestId.toString());
    Params = Params.append('user', user);
    Params = Params.append('fieldName', fieldName);
    return this.http.post<ServiceCallResult<boolean>>(this._urls.updateRequestUserField, Params);
  }

  getRequestViewData(viewId: number, openRequestsOnly: boolean): Observable<ServiceCallResult<Request[]>> {
    let Params = new HttpParams();
    Params = Params.append('viewId', viewId.toString());
    Params = Params.append('openRequestsOnly', openRequestsOnly.toString());
      return this.http.get<ServiceCallResult<Request[]>>(this._urls.getRequestViewData, { params: Params }).pipe(
          map(itemData => {
              itemData.result.map(multiPipe)
              return itemData
          })
      );      
  }

  getAllRequests(openRequestsOnly: boolean): Observable<ServiceCallResult<Request[]>> {
    let Params = new HttpParams();
    Params = Params.append('openRequestsOnly', openRequestsOnly.toString());
      return this.http.get<ServiceCallResult<Request[]>>(this._urls.getAllRequests, { params: Params }).pipe(
        map(itemData => {
              itemData.result.map(multiPipe)
              return itemData
          })
      );      
  }

  getAllRequestViewData(viewId: number, openRequestsOnly: boolean): Observable<ServiceCallResult<Request[]>> {
    let Params = new HttpParams();
    Params = Params.append('viewId', viewId.toString());
    Params = Params.append('openRequestsOnly', openRequestsOnly.toString());
    return this.http.get<ServiceCallResult<Request[]>>(this._urls.getAllRequestsViewData, { params: Params }).pipe(
      map(itemData => {
        itemData.result.map(multiPipe)
        return itemData
      })
    );
  }

  getRequestNotes(requestId: number): Observable<ServiceCallResult<RequestNote[]>> {
    let Params = new HttpParams();
    Params = Params.append('requestId', requestId.toString());
    return this.http.get<ServiceCallResult<RequestNote[]>>(this._urls.getRequestNotes, { params: Params });
  }

  getRequestAttachment(id: number) {
    const url = encodeURI(`${this._urls.getRequestAttachment}/${id.toString()}`);
    window.open(url);
  }

}
