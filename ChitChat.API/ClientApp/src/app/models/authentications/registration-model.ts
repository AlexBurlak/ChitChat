export class RegistrationModel {
  public email: string;
  public login: string;
  public password: string;
  public passwordConfirm: string;

  public constructor(email: string, login: string, password: string, passwordConfirm: string) {
    this.email = email;
    this.login = login;
    this.password = password;
    this.passwordConfirm = passwordConfirm;
  }

}
