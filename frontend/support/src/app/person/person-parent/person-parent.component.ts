import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { ConfigModel } from 'src/app/config/shared/config.model';
import { ConfigService } from 'src/app/config/shared/config.service';

@Component({
  selector: 'app-person-parent',
  templateUrl: './person-parent.component.html',
  styleUrls: ['./person-parent.component.css']
})
export class PersonParentComponent implements OnInit {

  configs: Observable<ConfigModel>;
  constructor(private service: ConfigService) { }

  ngOnInit() {
    this.configs = this.service.getConfigChild(1);
  }

}
