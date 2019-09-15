import { Component, OnInit, Inject, EventEmitter } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material';
import { ConfigModel } from '../shared/config.model';
import { ConfigService } from '../shared/config.service';
import { BaseResponseDto } from 'src/app/framework/base-response/base-response-dto';
import Swal from 'sweetalert2';

export class DialogData {
  configId: number;
}

@Component({
  selector: 'app-config-create',
  templateUrl: './config-create.component.html',
  styleUrls: ['./config-create.component.css']
})
export class ConfigCreateComponent {
  model = new ConfigModel();
  createMode = true;
  public confirmedEventEmitter: EventEmitter<any>;

  constructor(
    private service: ConfigService,
    public dialogRef: MatDialogRef<ConfigCreateComponent>,
    @Inject(MAT_DIALOG_DATA) public data: ConfigModel) {
    this.confirmedEventEmitter = new EventEmitter<BaseResponseDto>();
    if (data) {
      this.model = data;
      this.createMode = false;
    }
  }

  submitform() {
    if (this.createMode) {
      this.service.create(this.model).subscribe((result: BaseResponseDto) => {
        this.confirmedEventEmitter.emit(result);
        this.dialogRef.close();
      }, err => {
        Swal.fire('خطایی رخ داد', err.error.message, 'error');
      });
    } else {
      this.service.update(this.model).subscribe((result: BaseResponseDto) => {
        this.confirmedEventEmitter.emit(result);
        this.dialogRef.close();
      }, err => {
        Swal.fire('خطایی رخ داد', err.error.message, 'error');
      });
    }
  }  
}
