import { ResponseModule } from './../response/response.module';
import { MyMaterialModule } from './../material.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RequestCreateComponent } from './request-create/request-create.component';
import { RequestListComponent } from './request-list/request-list.component';
import { UserRequestListComponent } from './user-request-list/user-request-list.component';
import { RequestRoutingModule } from './request.module.routing';
import { GridModule } from '@progress/kendo-angular-grid';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ConfigModule } from '../config/config.module';
import { MatGridListModule, MatListModule } from '@angular/material';
import { RequestDetailComponent } from './request-detail/request-detail.component';
@NgModule({
  declarations: [RequestCreateComponent, RequestListComponent, UserRequestListComponent, RequestDetailComponent],
  imports: [
    CommonModule,
    RequestRoutingModule,
    MyMaterialModule,
    GridModule,
    BrowserAnimationsModule,
    ResponseModule,
    ConfigModule,
    CommonModule,
    BrowserModule,
    MatGridListModule,
    MatListModule,
  ],
  entryComponents: []
})
export class RequestModule { }
