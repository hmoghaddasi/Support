import { Component, OnInit } from '@angular/core';
import { ResponseDetailModel } from '../shared/response-detail.model';
import { ResponseService } from '../shared/response.service';
import { ActivatedRoute, Router } from '@angular/router';
import Swal from 'sweetalert2';
import { ResponseModel } from '../shared/response.model';
import { BaseResponseDto } from 'src/app/framework/base-response/base-response-dto';

@Component({
  selector: 'app-response-management',
  templateUrl: './response-management.component.html',
  styleUrls: ['./response-management.component.css']
})
export class ResponseManagementComponent {
  requestId: number;
  responses: ResponseDetailModel[] = [];
  model = new ResponseModel();

  constructor(private responseService: ResponseService,
    private activatedRoute: ActivatedRoute,
    private router: Router) {
    this.activatedRoute.params.subscribe(params => {
      this.requestId = +params['id'];
      this.model.requestId = this.requestId;
    });
    this.reloadData();
  }

  reloadData() {
    this.responseService.getRequestResponseList(this.requestId).subscribe((res: ResponseDetailModel[]) => {
      this.responses = res;
    }, err => {
      Swal.fire('خطا', err.error.message, 'error');
    });
  }

  submit() {
    if (!this.model.note) {
      Swal.fire('صبر کنید', 'ابتدا یک متن در کادر پیام وارد نمایید', 'warning');
      return;
    }
    this.responseService.create(this.model).subscribe((res: BaseResponseDto) => {
      if (res.resultCode == 200) {
        this.reloadData();
        Swal.fire('عملیات موفق', res.message, 'success');
      } else {
        Swal.fire('عملیات موفق', res.message, 'success');
      }
    }, err => {
      Swal.fire('خطایی رخ داد', err.error.message, 'error');
    });
  }
}
