export class LoginModel {
  public login: string;
  public password: string;
  public constructor(login: string, password: string) {
    this.login = login;
    this.password = password;
  }
}
