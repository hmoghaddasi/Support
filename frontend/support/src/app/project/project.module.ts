import { MyMaterialModule } from './../material.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProjectSelectComponent } from './project-select/project-select.component';
import { ProjectRoutingModule } from './project.module.routing';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

@NgModule({
  declarations: [ProjectSelectComponent],
  imports: [
    CommonModule,
MyMaterialModule, ProjectRoutingModule,
BrowserAnimationsModule
  ],
  exports:[ProjectSelectComponent]
})
export class ProjectModule { }
