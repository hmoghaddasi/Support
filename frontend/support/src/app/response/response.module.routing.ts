import { NgModule } from '@angular/core';
import { RouterModule, Routes, Router } from '@angular/router';
import { RequestCreateComponent } from '../request/request-create/request-create.component';

const routes: Routes = [
  { path: 'response-create',
   component: RequestCreateComponent ,

  },

];

@NgModule({
imports: [RouterModule.forRoot(routes)],

  exports: [RouterModule]
})
export class ResponseRoutingModule { }
