import {Component, OnDestroy, OnInit} from '@angular/core';
import {Subject} from "rxjs";
import {FormBuilder, FormGroup, Validators} from "@angular/forms";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit, OnDestroy {
  $subscriptions: Subject<void> = new Subject<void>();
  loginForm!: FormGroup;

  constructor(private builder: FormBuilder) { }

  ngOnInit(): void {
    this.loginForm = this.builder.group({
      login: ['', [Validators.required]],
      password: ['', [Validators.required]]
    })
  }

  ngOnDestroy(): void {
    this.$subscriptions.next();
    this.$subscriptions.complete();
  }

  get login() {
    return this.loginForm.get('login');
  }

  get password() {
    return this.loginForm.get('password');
  }

}
