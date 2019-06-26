import { Injectable } from '@angular/core';

import { Observable } from 'rxjs';
import { RestService } from 'src/app/framework/services/rest.service';
import { RequestModel } from './request.model';
import { State } from '@progress/kendo-data-query';
import { GridDataResult } from '@progress/kendo-angular-grid';


@Injectable({
  providedIn: 'root'
})

export class RequestService  {
  [x: string]: any;
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
  public getForGrid(state: State): Observable<GridDataResult> {
    return this.restService.getForGrid(this.resourceName, state);
  }

}


