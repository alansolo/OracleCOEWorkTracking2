import { Component, OnInit } from '@angular/core';
import { PlatformLocation } from '@angular/common';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.css']
})
export class FooterComponent implements OnInit {

  public logoUrl: string;

  constructor(platformLocation: PlatformLocation) {
    this.logoUrl = (platformLocation as any).location.origin + '/OracleWorkMgmt/assets/images/ppg-logo.png';
  }

  ngOnInit() {
  }

}
