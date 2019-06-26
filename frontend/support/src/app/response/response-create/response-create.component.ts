import { Component, OnInit, Inject } from '@angular/core';
import { ResponseModel } from '../shared/response.model';
import { MAT_DIALOG_DATA } from '@angular/material';
import { ResponseService } from '../shared/response.service';



export class DialogData {
  ResponseId: number;

}

@Component({
  selector: 'app-response-create',
  templateUrl: './response-create.component.html',
  styleUrls: ['./response-create.component.css']
})
export class ResponseCreateComponent implements OnInit {
  model = new ResponseModel();
  constructor(@Inject(MAT_DIALOG_DATA) public data: DialogData,
              private service:ResponseService) { }

  ngOnInit() {
    if (this.data.ResponseId > 0) {
      this.service.getById(this.data.ResponseId).subscribe(result => {
        this.model = result;
      });
    }
  }

  create() {
    this.service.create(this.model).subscribe(result => {
    });
  }
}
