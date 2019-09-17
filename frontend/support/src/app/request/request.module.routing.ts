import { NgModule } from '@angular/core';
import { RouterModule, Routes, Router } from '@angular/router';
import { AuthGuard } from '../framework/services/auth-guard.service';
import { Permissions } from '../framework/shared/permissions';
import { RequestListComponent } from './request-list/request-list.component';
import { UserRequestListComponent } from './user-request-list/user-request-list.component';
import { RequestDetailComponent } from './request-detail/request-detail.component';

const routes: Routes = [
  {
    path: 'request-list-admin',
    component: RequestListComponent,
    canActivate: [AuthGuard],
    data: { permission: Permissions.ADMIN_REQUEST }
  },
  {
    path: 'request-list',
    component: UserRequestListComponent,
    canActivate: [AuthGuard],
    data: { permission: Permissions.LIST_REQUEST }
  },
  {
    path: 'request-detail/:id',
    component: RequestDetailComponent,
    canActivate: [AuthGuard],
    data: { permission: Permissions.REQUEST_DETAIL }
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],

  exports: [RouterModule]
})
export class RequestRoutingModule { }
