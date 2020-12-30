import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { Router, ActivatedRoute, NavigationEnd, Params, PRIMARY_OUTLET } from '@angular/router';
import { UserService } from '../services/user.service';
import { User } from '../models/user';

@Component({
  selector: 'app-title-bar',
  templateUrl: './title-bar.component.html',
  styleUrls: ['./title-bar.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class TitleBarComponent implements OnInit {
  public currentUser: User;

  constructor(
    private readonly activatedRoute: ActivatedRoute,
    private readonly router: Router,
    private userService: UserService
  )
  {

  }

  ngOnInit() {
    this.userService.getCurrentUser().subscribe(callResult => {
      console.log(callResult.result);
      this.currentUser = callResult.result;
    });
  }

}
