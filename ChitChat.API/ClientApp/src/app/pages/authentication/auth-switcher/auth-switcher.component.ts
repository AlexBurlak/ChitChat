import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-auth-switcher',
  templateUrl: './auth-switcher.component.html',
  styleUrls: ['./auth-switcher.component.css']
})
export class AuthSwitcherComponent implements OnInit {
  isLoggin: boolean = true;
  constructor() { }

  ngOnInit(): void {
  }

}
