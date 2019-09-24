import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { RestService } from 'src/app/framework/services/rest.service';
import { GridDataResult } from '@progress/kendo-angular-grid';
import { State } from '@progress/kendo-data-query';
import Swal from 'sweetalert2';
import { ConfigModel } from './config.model';
import { BaseResponseDto } from 'src/app/framework/base-response/base-response-dto';

@Injectable({
  providedIn: 'root'
})

export class ConfigService {

  private resourceName = 'Config';
  public needDataUpdate = new Subject<boolean>();

  constructor(private restService: RestService) { }

  public getAll(): Observable<any> {
    return this.restService.getAll(this.resourceName);
  }

  public getById(id): Observable<any> {
    return this.restService.getById(this.resourceName, id);
  }
  public create(model: ConfigModel): Observable<any> {
    return this.restService.post(this.resourceName, model);
  }

  public update(model: ConfigModel): Observable<any> {
    return this.restService.put(this.resourceName, model);
  }

  public getForGrid(state: State, id: number): Observable<GridDataResult> {
    return this.restService.getForGrid(this.resourceName, state, id);
  }

  public getConfigChild(id: number): Observable<any> {
    return this.restService.customAction('ConfigChild', id);
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
          Swal.fire('خطایی رخ داده است', err.error.message, 'error');
        });
      }
    });
  }
}
