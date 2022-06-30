import {Routes} from "@angular/router";
import {LoginComponent} from "./login/login.component";
import {AuthSwitcherComponent} from "./auth-switcher/auth-switcher.component";

export const routes: Routes = [
  {
    path: '',
    component: AuthSwitcherComponent
  },
  {
    path: '**',
    redirectTo: ''
  }
];
