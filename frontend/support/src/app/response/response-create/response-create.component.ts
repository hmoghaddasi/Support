import { Component, OnInit } from '@angular/core';
import { ResponseModel } from '../shared/response.model';
import { ResponseService } from '../shared/response.service';



@Component({
  selector: 'app-response-create',
  templateUrl: './response-create.component.html',
  styleUrls: ['./response-create.component.css']
})
export class ResponseCreateComponent implements OnInit {
  model = new ResponseModel();
  constructor( private service: ResponseService)  { }

  ngOnInit() {
  }

  create() {
    this.service.create(this.model).subscribe(result => {
    });
  }
}
