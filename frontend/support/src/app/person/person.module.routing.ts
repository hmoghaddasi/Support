import { NgModule } from '@angular/core';
import { RouterModule, Routes, Router } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { RegistrationComponent } from './registration/registration.component';
import { ProfileComponent } from './profile/profile.component';
import { VerificationComponent } from './verification/verification.component';
import { ResetpassComponent } from './resetpass/resetpass.component';
import { ChangePasswordComponent } from './changepassword/change-password.component';
import { AuthGuard } from '../framework/services/auth-guard.service';
import { Permissions } from '../framework/shared/permissions';
import { LogoutComponent } from './logout/logout.component';
import { RegisterSuccessComponent } from './register-success/register-success.component';
import { PersonParentComponent } from './person-parent/person-parent.component';

const routes: Routes = [
  { path: 'register', component: RegistrationComponent },
  { path: 'login', component: LoginComponent },
  { path: 'logout', component: LogoutComponent },
  { path: 'reset-password', component: ResetpassComponent },
  { path: 'verification', component: VerificationComponent },
  {
    path: 'changepassword',
    component: ChangePasswordComponent,
    canActivate: [AuthGuard],
    data: { permission: Permissions.CHANGEPASSWORD_PERSON }
  },
  {
    path: 'profile',
    component: ProfileComponent,
    canActivate: [AuthGuard],
    data: { permission: Permissions.PROFILE_PERSON }
  },
  {
    path: 'register-success',
    component: RegisterSuccessComponent
  },
  {
    path: 'person-list', component: PersonParentComponent,
    canActivate: [AuthGuard],
    data: { permission: Permissions.LIST_PERSON }
  },
];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class PersonRoutingModule { }


