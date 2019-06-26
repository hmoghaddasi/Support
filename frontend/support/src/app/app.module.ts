import { MatFormFieldModule } from '@angular/material';
import { ResponseModule } from './response/response.module';
import { RequestModule } from './request/request.module';
import { ProjectModule } from './project/project.module';
import { HttpClientModule } from '@angular/common/http';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MyMaterialModule } from './material.module';
import { FrameworkModule } from './framework/framework.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    MyMaterialModule,
    HttpClientModule,
    FrameworkModule,
    ProjectModule
    , RequestModule,
     ResponseModule
    , BrowserAnimationsModule
    ,MatFormFieldModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
  exports: []
})
export class AppModule { }
