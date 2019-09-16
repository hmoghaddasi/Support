import { Component, OnInit,  Inject, EventEmitter } from '@angular/core';
import { RequestModel } from '../shared/request.model';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material';
import { RequestService } from '../shared/request.service';
import { BaseResponseDto } from 'src/app/framework/base-response/base-response-dto';
import Swal from 'sweetalert2';


export class DialogData {
  RequestId: number;
//  ProjectId: number;
}


@Component({
  selector: 'app-request-create',
  templateUrl: './request-create.component.html',
  styleUrls: ['./request-create.component.css']
})
export class RequestCreateComponent {
  model = new RequestModel();
  public confirmedEventEmitter: EventEmitter<any>;

  constructor(
    private service: RequestService,
    public dialogRef: MatDialogRef<RequestCreateComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any) {
    this.confirmedEventEmitter = new EventEmitter<BaseResponseDto>();
  }


  submitform() {
      this.service.create(this.model).subscribe((result: BaseResponseDto) => {
        this.confirmedEventEmitter.emit(result);
        this.dialogRef.close();
      }, err => {
        Swal.fire('خطایی رخ داد', err.error.message, 'error');
      });
  } 
}
