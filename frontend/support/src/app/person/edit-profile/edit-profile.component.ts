import { Component, OnInit, EventEmitter, Inject } from '@angular/core';
import { ProfileModel } from '../shared/profile.model';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material';
import { ProfileService } from '../shared/profile.service';
import { BaseResponseDto } from 'src/app/framework/base-response/base-response-dto';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-edit-profile',
  templateUrl: './edit-profile.component.html',
  styleUrls: ['./edit-profile.component.css']
})
export class EditProfileComponent {
  model = new ProfileModel();
  createMode: boolean = true;
  public confirmedEventEmitter: EventEmitter<any>;

  constructor(@Inject(MAT_DIALOG_DATA) public data: ProfileModel,
    public dialogRef: MatDialogRef<EditProfileComponent>,
    private service: ProfileService) {
    this.confirmedEventEmitter = new EventEmitter<BaseResponseDto>();
    this.model = data;
  }

  submit() {
    this.service.editProfile(this.model).subscribe((result: BaseResponseDto) => {
      this.confirmedEventEmitter.emit(result);
      this.dialogRef.close();
    }, err => {
      Swal.fire('خطایی رخ داد', err.error.Message, 'error');
    });
  }

}
