import {Component, OnDestroy, OnInit} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {Subject} from "rxjs";

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit, OnDestroy {
  registerForm!: FormGroup;
  $subscriptions: Subject<void> = new Subject<void>();

  constructor(private builder: FormBuilder) { }

  ngOnInit(): void {
    this.registerForm = this.builder.group({
      'email': ['', [Validators.required, Validators.email]],
      'login': ['', [Validators.required]],
      'password': ['', [Validators.required]],
      'confirmPassword': ['', [Validators.required]],
    });
  }

  ngOnDestroy(): void {
    this.$subscriptions.next();
    this.$subscriptions.complete();
  }

  get login() {
    return this.registerForm.get('login');
  }

  get email() {
    return this.registerForm.get('email');
  }

  get password() {
    return this.registerForm.get('password');
  }

  get confirmPassword() {
    return this.registerForm.get('confirmPassword');
  }

}
