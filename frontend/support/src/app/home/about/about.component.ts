import { Component, OnInit } from '@angular/core';
import { HomeService } from '../shared/home.service';
import { HomeModel } from '../shared/home.model';

@Component({
  selector: 'app-about',
  templateUrl: './about.component.html',
  styleUrls: ['./about.component.css']
})
export class AboutComponent implements OnInit {
  model = new HomeModel();
  constructor(private service: HomeService) {
    this.reloadDate();
   }

  ngOnInit() {
  }
  reloadDate() {
     this.service.getHomeInfo().subscribe((res: HomeModel) => {
       this.model = res;
       console.log(this.model);
    });
  }
}
