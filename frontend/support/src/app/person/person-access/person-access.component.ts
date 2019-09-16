import { Component, OnInit, Inject, EventEmitter } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { AccessService } from '../shared/access.service';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { AccessModel } from '../shared/access.model';
import { AccessPolicyService } from '../shared/access.policy.service';
import { ChangePersonAccessModel } from '../shared/change.person.access.model';
import { BaseResponseDto } from 'src/app/framework/base-response/base-response-dto';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-person-access',
  templateUrl: './person-access.component.html',
  styleUrls: ['./person-access.component.css']
})
export class PersonAccessComponent implements OnInit {

  id: number;
  accessList: AccessModel[] = [];
  model = new ChangePersonAccessModel();

  constructor(public dialogRef: MatDialogRef<PersonAccessComponent>,
              private accessService: AccessService,
              private accessPolicyService: AccessPolicyService,
              @Inject(MAT_DIALOG_DATA) public data: number) {
    this.id = data;
    this.model.PersonId = data;
    this.getAccessList(this.id);
  }

  getAccessList(id: number) {
    this.accessService.personAccess(this.id).subscribe(a => {
      this.accessList = a;
    }, err => {
      this.accessList = [];
    });
  }

  ngOnInit() {
  }

  changePersonAccess(accessId: number, addOrRemove: boolean) {
    this.model.AccessId = accessId;
    this.model.AddOrRemove = addOrRemove;
    this.accessPolicyService.changePersonAccess(this.model).subscribe((result: BaseResponseDto) => {
      debugger
      if(result.resultCode == 200) {
        this.accessList = [];
        this.getAccessList(this.id);
      }
    }, err => {
      Swal.fire('خطایی رخ داد', err.error.Message, 'error');
    });
  }

  reject(): void {
    console.log('reject');
    this.dialogRef.close();
  }

}
