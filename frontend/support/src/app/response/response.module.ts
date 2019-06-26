import { ResponseRoutingModule } from './response.module.routing';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ResponseCreateComponent } from './response-create/response-create.component';
import { MyMaterialModule } from '../material.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

@NgModule({
  declarations: [ResponseCreateComponent],
  imports: [
    CommonModule,
    MyMaterialModule,
    ResponseRoutingModule,BrowserAnimationsModule
  ]
})
export class ResponseModule { }
