import { Component, OnInit } from '@angular/core';
import { RequestService } from '../shared/request.service';
import { Observable } from 'rxjs';
import { RequestModel } from '../shared/request.model';

@Component({
  selector: 'app-user-request-list',
  templateUrl: './user-request-list.component.html',
  styleUrls: ['./user-request-list.component.css']
})
export class UserRequestListComponent implements OnInit {
  Requests: Observable<RequestModel>;
  model = new RequestModel();
  constructor(private service: RequestService) { }
  ngOnInit() {
    this.Requests = this.service.getRequest(1);
    // tslint:disable-next-line:no-debugger

  }

}
