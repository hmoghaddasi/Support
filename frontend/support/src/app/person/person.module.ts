import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RegistrationComponent } from './registration/registration.component';
import { LoginComponent } from './login/login.component';
import { PersonRoutingModule } from './person.module.routing';
import { MyMaterialModule } from '../material.module';
import { ProfileComponent } from './profile/profile.component';
import { VerificationComponent } from './verification/verification.component';
import { ResetpassComponent } from './resetpass/resetpass.component';
import { GridModule } from '@progress/kendo-angular-grid';
import { ChangePasswordComponent } from './changepassword/change-password.component';
import { LogoutComponent } from './logout/logout.component';
import { PersonListComponent } from './person-list/person-list.component';
import { PersonAccessComponent } from './person-access/person-access.component';
import { MatDialogModule } from '@angular/material';
import { MatListModule } from '@angular/material/list';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';



@NgModule({
   declarations: [RegistrationComponent, LoginComponent, ProfileComponent, LogoutComponent, VerificationComponent,
      PersonListComponent, ChangePasswordComponent, ResetpassComponent, PersonAccessComponent],
   imports: [
      CommonModule,
      MyMaterialModule,
      PersonRoutingModule,
      GridModule,
      MatDialogModule,
      MatListModule,
      FormsModule,
      ReactiveFormsModule
   ],
   entryComponents: [PersonAccessComponent],
   exports: [
      LoginComponent,
      LogoutComponent
   ]
})

export class PersonModule { }
