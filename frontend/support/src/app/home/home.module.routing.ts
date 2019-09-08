import { NgModule } from '@angular/core';
import { RouterModule, Routes, Router } from '@angular/router';
import { AboutComponent } from './about/about.component';
import { NavbarComponent } from './navbar/navbar.component';
import { footerComponent } from './footer/footer.component';
import { HomeComponent } from './home.component';
import { AccessDeniedComponent } from './access-denied/access-denied.component';
import { CardComponent } from './card/card.component';


const routes: Routes = [
  { path: '', component: HomeComponent},
  { path: 'card', component: CardComponent},
  { path: 'about', component: AboutComponent},
  { path: 'navbar', component: NavbarComponent},
  { path: 'footer', component: footerComponent},
  { path: 'access-denied', component: AccessDeniedComponent}

];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class HomeRoutingModule {}
