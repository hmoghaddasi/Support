import { Component, OnInit,  Inject } from '@angular/core';
import { RequestModel } from '../shared/request.model';
import { MAT_DIALOG_DATA } from '@angular/material';
import { RequestService } from '../shared/request.service';


export class DialogData {
  RequestId: number;
//  ProjectId: number;
}


@Component({
  selector: 'app-request-create',
  templateUrl: './request-create.component.html',
  styleUrls: ['./request-create.component.css']
})
export class RequestCreateComponent implements OnInit {
  model = new RequestModel();
  constructor( private service: RequestService) {}

  ngOnInit() {

  }

  create() {
    this.service.create(this.model).subscribe(result => {
    });
  }
}
