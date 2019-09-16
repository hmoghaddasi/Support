import { MatFormFieldModule } from '@angular/material';
import { ResponseModule } from './response/response.module';
import { RequestModule } from './request/request.module';
import { HttpClientModule } from '@angular/common/http';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MyMaterialModule } from './material.module';
import { FrameworkModule } from './framework/framework.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { GridModule } from '@progress/kendo-angular-grid';
import { HomeModule } from './home/home.module';
import { ConfigModule } from './config/config.module';
import { RTL } from '@progress/kendo-angular-l10n';


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
    RequestModule,
    ResponseModule,
    BrowserAnimationsModule,
    MatFormFieldModule,
    HomeModule,
    ConfigModule,
    GridModule,
  ],
  providers: [{ provide: RTL, useValue: true }],
  bootstrap: [AppComponent],
  exports: []
})
export class AppModule { }
