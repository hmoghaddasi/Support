import { NgModule } from '@angular/core';
import { RouterModule, Routes, Router } from '@angular/router';
import { ProjectSelectComponent } from './project-select/project-select.component';


const routes: Routes = [

  { path: 'project-select', component: ProjectSelectComponent },

];

@NgModule({
imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class ProjectRoutingModule {}



