import { NgModule } from '@angular/core';
import { RouterModule, Routes, Router } from '@angular/router';
import { ResponseManagementComponent } from './response-management/response-management.component';
import { AuthGuard } from '../framework/services/auth-guard.service';
import { Permissions } from '../framework/shared/permissions';
import { ResponseManagementAdminComponent } from './response-management-admin/response-management-admin.component';

const routes: Routes = [
  {
    path: 'response-management/:id',
    component: ResponseManagementComponent,
    canActivate: [AuthGuard],
    data: { permission: Permissions.RESPONSE_MANAGEMENT }
  },
  {
    path: 'response-management-admin/:id',
    component: ResponseManagementAdminComponent,
    canActivate: [AuthGuard],
    data: { permission: Permissions.RESPONSE_MANAGEMENT_ADMIN }
  }
];

@NgModule({
imports: [RouterModule.forRoot(routes)],

  exports: [RouterModule]
})
export class ResponseRoutingModule { }
