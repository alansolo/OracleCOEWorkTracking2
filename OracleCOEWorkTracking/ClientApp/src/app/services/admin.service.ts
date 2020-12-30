import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';

import { Observable } from 'rxjs/Observable';
import { ServiceCallResult } from '../models/service-call-result';
import { Region } from '../models/Region';
import { SBU } from '../models/sbu';
import { OwningSite } from '../models/owning-site';
import { OwningStream } from '../models/owning-stream';
import { RequestView } from '../models/request-view';
import { DropDownData } from '../models/drop-down-data';
import { AppName } from '../models/application';


const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable()
export class AdminService {

  constructor(private http: HttpClient) { }

  private _urls = {
    getRegions: 'api/admin/getregions',
    getSBUs: 'api/admin/getSBUs',
    getOwningSites: 'api/admin/getOwningSites',
    getOwningStreams: 'api/admin/getOwningStreams',
    getRequestViews: 'api/admin/getRequestViews',
    getDropDownData: 'api/admin/getDropDownData',
    getAppNames: 'api/admin/getAppNamesData'
  };
  getAppNames(): Observable<ServiceCallResult<AppName[]>> {
    return this.http.get<ServiceCallResult<AppName[]>>(this._urls.getAppNames, { withCredentials: true });
  }
  getRegions(): Observable<ServiceCallResult<Region[]>> {
    return this.http.get<ServiceCallResult<Region[]>>(this._urls.getRegions, { withCredentials: true });
  }
  getSBUs(): Observable<ServiceCallResult<SBU[]>> {
    return this.http.get<ServiceCallResult<SBU[]>>(this._urls.getSBUs, { withCredentials: true });
  }
  getOwningSites(): Observable<ServiceCallResult<OwningSite[]>> {
    return this.http.get<ServiceCallResult<OwningSite[]>>(this._urls.getOwningSites, { withCredentials: true });
  }
  getOwningStreams(): Observable<ServiceCallResult<OwningStream[]>> {
    return this.http.get<ServiceCallResult<OwningStream[]>>(this._urls.getOwningStreams, { withCredentials: true });
  }

  getRequestViews(): Observable<ServiceCallResult<RequestView[]>> {
    return this.http.get<ServiceCallResult<RequestView[]>>(this._urls.getRequestViews, { withCredentials: true });
  }
  getDropDownData(): Observable<ServiceCallResult<DropDownData>> {
    return this.http.get<ServiceCallResult<DropDownData>>(this._urls.getDropDownData, { withCredentials: true });
  }
}
