import { Injectable } from '@angular/core';

import { Observable, Subject } from 'rxjs';
import { RestService } from 'src/app/framework/services/rest.service';
import { RequestModel } from './request.model';
import { State } from '@progress/kendo-data-query';
import { GridDataResult } from '@progress/kendo-angular-grid';
import Swal from 'sweetalert2';
import { BaseResponseDto } from 'src/app/framework/base-response/base-response-dto';


@Injectable({
  providedIn: 'root'
})

export class RequestService {
  public needDataUpdate = new Subject<boolean>();
  constructor(private restService: RestService) {
  }
  private resourceName = 'request';


  public create(model: RequestModel): Observable<any> {
    return this.restService.post(this.resourceName, model);
  }
  public getAll(): Observable<any> {
    return this.restService.getAll(this.resourceName);
  }
  public getById(id): Observable<any> {
    return this.restService.getById(this.resourceName, id);
  }
  public getRequest(id: number): Observable<any> {
    return this.restService.customAction('request', id);
  }
  public getForGrid(state: State): Observable<GridDataResult> {
    return this.restService.getForGrid(this.resourceName, state);
  }
  public getForGridUser(state: State): Observable<GridDataResult> {
    return this.restService.getForGridCustome(this.resourceName, 'RequestByCurrentUserGrid', state);
  }

  public closeTicket(requestId: number): any {
    return this.restService.customAction(this.resourceName + '/' + 'CloseTicket', requestId);
  }
}


