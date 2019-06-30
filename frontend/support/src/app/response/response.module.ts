import { ResponseRoutingModule } from './response.module.routing';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ResponseCreateComponent } from './response-create/response-create.component';
import { MyMaterialModule } from '../material.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RequestCreateComponent } from '../request/request-create/request-create.component';

@NgModule({
  declarations: [ResponseCreateComponent],
  imports: [
    CommonModule,
    MyMaterialModule,
    ResponseRoutingModule, BrowserAnimationsModule
  ],
  entryComponents: [ RequestCreateComponent]
})
export class ResponseModule { }
