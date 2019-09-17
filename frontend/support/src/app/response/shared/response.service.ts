import { Injectable } from '@angular/core';

import { Observable, Subject } from 'rxjs';
import { RestService } from 'src/app/framework/services/rest.service';
import { State } from '@progress/kendo-data-query';
import { GridDataResult } from '@progress/kendo-angular-grid';
import { ResponseModel } from './response.model';
import Swal from 'sweetalert2';
import { BaseResponseDto } from 'src/app/framework/base-response/base-response-dto';


@Injectable({
  providedIn: 'root'
})

export class ResponseService {

  constructor(private restService: RestService) {
  }
  private resourceName = 'response';
  public needDataUpdate = new Subject<boolean>();

  public create(model: ResponseModel): Observable<any> {
    return this.restService.post(this.resourceName, model);
  }
  public getAll(): Observable<any> {
    return this.restService.getAll(this.resourceName);
  }
  public getById(id: number): Observable<any> {
    return this.restService.getById(this.resourceName, id);
  }

  getRequestResponseList(requestId: number) {
    return this.restService.customAction(this.resourceName + '/' + "GetRequestResponseList", requestId);
  }

  public delete(id: number): any {
    Swal.fire({
      title: 'حذف',
      text: 'آیا از حذف این رکورد اطمینان دارید؟',
      type: 'warning',
      showCancelButton: true,
      confirmButtonText: 'تایید',
      cancelButtonText: 'لغو'
    }).then((result) => {
      if (result.value) {
        this.restService.delete(this.resourceName, id).subscribe((res: BaseResponseDto) => {
          if (res.resultCode === 200) {
            Swal.fire('عملیات موفق', res.message, 'success');
            this.needDataUpdate.next(true);
          } else {
            Swal.fire('عملیات ناموفق', res.message, 'error');
          }
        }, err => {
          console.log(err);
          Swal.fire('خطایی رخ داده است', err.error.message, 'error');
        });
      }
    });
  }

}


