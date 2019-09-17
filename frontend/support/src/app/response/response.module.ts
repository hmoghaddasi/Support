import { ResponseRoutingModule } from './response.module.routing';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MyMaterialModule } from '../material.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RequestCreateComponent } from '../request/request-create/request-create.component';
import { ResponseManagementComponent } from './response-management/response-management.component';

@NgModule({
  declarations: [ResponseManagementComponent],
  imports: [
    CommonModule,
    MyMaterialModule,
    ResponseRoutingModule, BrowserAnimationsModule
  ],
  entryComponents: [ RequestCreateComponent]
})
export class ResponseModule { }
