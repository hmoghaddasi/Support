import { NgModule } from '@angular/core';
import { RouterModule, Routes, Router } from '@angular/router';
import { ConfigListComponent } from './config-list/config-list.component';
import { ConfigSelectComponent } from './config-select/config-select.component';
import { AuthGuard } from '../framework/services/auth-guard.service';
import { Permissions } from '../framework/shared/permissions';
import { ConfigParentComponent } from './config-parent/config-parent.component';

const routes: Routes = [
  { path: 'Configcreate',
   component: ConfigListComponent ,
   canActivate: [AuthGuard],
  data: { permission: Permissions.CREATE_CONFIG}},
  { path: 'configSelect', component: ConfigSelectComponent },
  {
    path: 'configlist',
    component:  ConfigParentComponent,
    canActivate: [AuthGuard],
    data: { permission: Permissions.LIST_CONFIG}
   }
];

@NgModule({
imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class ConfigRoutingModule {}


