import { Component, OnInit} from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ToasterService } from 'angular2-toaster';
import { User } from '../models/user';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit  {
  user: User; 
  ngOnInit() {
    this.userService.getCurrentUser().subscribe(result => {
      this.user = result.result;
      console.log(this.user);
    })
  }

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private toasterService: ToasterService,
    private userService: UserService) {

  }

}
