import { Component, OnInit, OnDestroy } from '@angular/core';
import { ResponseDetailModel } from '../shared/response-detail.model';
import { ResponseService } from '../shared/response.service';
import { ActivatedRoute, Router } from '@angular/router';
import Swal from 'sweetalert2';
import { ResponseModel } from '../shared/response.model';
import { BaseResponseDto } from 'src/app/framework/base-response/base-response-dto';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-response-management-admin',
  templateUrl: './response-management-admin.component.html',
  styleUrls: ['./response-management-admin.component.css']
})
export class ResponseManagementAdminComponent implements OnDestroy {
  requestId: number;
  responses: ResponseDetailModel[] = [];
  model = new ResponseModel();
  subscription = new Subscription();

  constructor(private responseService: ResponseService,
    private activatedRoute: ActivatedRoute,
    private router: Router) {
    this.activatedRoute.params.subscribe(params => {
      this.requestId = +params['id'];
      this.model.requestId = this.requestId;
    });
    this.reloadData();
    this.subscription = responseService.needDataUpdate.subscribe(a => {
      this.reloadData();
    })
  }
  ngOnDestroy(): void {
    this.subscription.unsubscribe();
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
      }
      else {
        Swal.fire('عملیات موفق', res.message, 'error');
      }
    }, err => {
      Swal.fire('خطایی رخ داد', err.error.message, 'error');
    });
  }
  delete(responseId: number) {
    this.responseService.delete(responseId);
  }
}
