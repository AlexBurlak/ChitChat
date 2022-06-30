import {Inject, Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {LoginModel} from "../models/authentications/login-model";
import {RegistrationModel} from "../models/authentications/registration-model";

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  url: string;
  constructor(private httpClient: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.url = baseUrl;
  }

  public login(login: LoginModel) {
    return this.httpClient.post<LoginModel>(this.url + 'authentication/login', login);
  }

  public register(registration: RegistrationModel) {
    return this.httpClient.post<RegistrationModel>(this.url + 'authentication/register', registration);
  }
}
