import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ConfigListComponent } from './config-list/config-list.component';
import { ConfigSelectComponent } from './config-select/config-select.component';
import { MyMaterialModule } from '../material.module';
import { ConfigRoutingModule } from './config.module.routing';
import { ConfigCreateComponent } from './config-create/config-create.component';
import { GridModule } from '@progress/kendo-angular-grid';
import {DialogModule} from '@progress/kendo-angular-dialog';
import { ConfigParentComponent } from './config-parent/config-parent.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';


@NgModule({
  // tslint:disable-next-line:max-line-length
  declarations: [ConfigListComponent, ConfigSelectComponent, ConfigCreateComponent, ConfigParentComponent],
  // tslint:disable-next-line:max-line-length
  exports: [ConfigSelectComponent],
  imports: [
    CommonModule,
    MyMaterialModule,
    ConfigRoutingModule,
    GridModule,
    DialogModule,
    FormsModule,
    ReactiveFormsModule,
  ],

  entryComponents: [ConfigCreateComponent]
})
export class ConfigModule { }
