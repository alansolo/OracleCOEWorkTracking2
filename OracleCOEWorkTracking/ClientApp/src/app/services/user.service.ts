import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';

import { Observable } from 'rxjs/Observable';
import { User } from '../models/user';
import { ServiceCallResult } from '../models/service-call-result';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable()
export class UserService {

  constructor(private http: HttpClient) { }

  private _urls = {
    getCurrentUser: 'api/admin/getcurrentuser'
  };

  getCurrentUser(): Observable<ServiceCallResult<User>> {
    return this.http.get<ServiceCallResult<User>>(this._urls.getCurrentUser, { withCredentials: true });
  }
}
