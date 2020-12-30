
import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { Observable } from 'rxjs/Observable';
import { ServiceCallResult } from '../models/service-call-result';
import { ToasterService } from 'angular2-toaster';
import { User } from '../models/user';
import { AdminService } from '../services/admin.service';
import { UserService } from '../services/user.service';

@Injectable()
export class ManageGuard implements CanActivate {
  user: ServiceCallResult<User>;
  auth: boolean;
  constructor(
    private userService: UserService,
    private toasterService: ToasterService,
    private router: Router) {
  }

  async canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Promise<boolean> {

    this.user = await this.userService.getCurrentUser().toPromise();
    if (this.user.result.role >= 2) { return true; }
    else {
        this.toasterService.pop({
          type: 'error',
          title: 'Unauthorized',
          body: 'Additional Access Required to manage Requests.',
          timeout: 0});
        this.router.navigate(['']);
        return false;
      }
  }
}


