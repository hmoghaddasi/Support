import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AboutComponent } from './about/about.component';
import { NavbarComponent } from './navbar/navbar.component';
import { footerComponent } from './footer/footer.component';
import { HomeRoutingModule } from './home.module.routing';
import { HomeComponent } from './home.component';
import { PersonModule } from '../person/person.module';
import { MyMaterialModule } from '../material.module';
import { AccessDeniedComponent } from './access-denied/access-denied.component';
import { FrameworkModule } from '../framework/framework.module';
import { CardComponent } from './card/card.component';
import { ContactUsComponent } from './contact-us/contact-us.component';
import { ManualComponent } from './manual/manual.component';
@NgModule({
  declarations: [
    AboutComponent,
    NavbarComponent,
    footerComponent,
    HomeComponent,
    AccessDeniedComponent,
    CardComponent,
    ContactUsComponent,
    ManualComponent
  ],
  exports: [NavbarComponent, footerComponent
  ],
  imports: [
    CommonModule,
    HomeRoutingModule,
    PersonModule,
    MyMaterialModule,
    FrameworkModule
  ]
})
export class HomeModule { }
