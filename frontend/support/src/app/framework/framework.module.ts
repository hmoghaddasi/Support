import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule, HttpClientJsonpModule } from '@angular/common/http';

import { HasPermissionDirective } from './directives/has-permission.directive';
import { SignedDirective } from './directives/signed.directive';
import { NotSignedDirective } from './directives/not-signed.directive';

@NgModule({
  declarations: [ HasPermissionDirective, SignedDirective, NotSignedDirective],
  imports: [
    CommonModule,
    HttpClientModule,
    HttpClientJsonpModule
  ],
  exports: [ HasPermissionDirective, SignedDirective, NotSignedDirective]
})
export class FrameworkModule { }
