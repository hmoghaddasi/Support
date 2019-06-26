import { Component, OnInit, Injectable, Inject } from '@angular/core';
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
  constructor(@Inject(MAT_DIALOG_DATA) public data: DialogData,
              private service: RequestService) { }

  ngOnInit() {
    if (this.data.RequestId > 0) {
      this.service.getById(this.data.RequestId).subscribe(result => {
        this.model = result;
      });
    }
  }

  create() {
    this.service.create(this.model).subscribe(result => {
    });
  }
}
