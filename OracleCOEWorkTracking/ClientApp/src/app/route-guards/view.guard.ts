
import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { Observable } from 'rxjs/Observable';
import { ServiceCallResult } from '../models/service-call-result';
import { ToasterService } from 'angular2-toaster';
import { User } from '../models/user';
import { AdminService } from '../services/admin.service';
import { UserService } from '../services/user.service';

@Injectable()
export class ViewGuard implements CanActivate {
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
    if (this.user.result.role >= 1) { return true; }
    else {
      this.toasterService.pop({
        type: 'error',
        title: 'Unauthorized',
        body: 'You are not authorized to access this system',
        timeout: 0
      });
      this.router.navigate(['unauthorized']);
      return false;
    }
  }
}


