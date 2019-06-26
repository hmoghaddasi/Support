import { NgModule } from '@angular/core';
import { RouterModule, Routes, Router } from '@angular/router';
import { AuthGuard } from '../framework/services/auth-guard.service';
import { Permissions } from '../framework/shared/permissions';
import { RequestCreateComponent } from './request-create/request-create.component';
import { RequestListComponent } from './request-list/request-list.component';
import { UserRequestListComponent } from './user-request-list/user-request-list.component';

const routes: Routes = [
  { path: 'request-create',
   component: RequestCreateComponent ,

  },
  { path: 'request-list', component:RequestListComponent },
  {
    path: 'user-request-list',
    component: UserRequestListComponent,


   }
];

@NgModule({
imports: [RouterModule.forRoot(routes)],

  exports: [RouterModule]
})
export class RequestRoutingModule { }
