import { Injectable } from '@angular/core';

import { Observable } from 'rxjs';
import { RestService } from 'src/app/framework/services/rest.service';
import { State } from '@progress/kendo-data-query';
import { GridDataResult } from '@progress/kendo-angular-grid';
import { ResponseModel } from './response.model';


@Injectable({
  providedIn: 'root'
})

export class ResponseService  {

  constructor(private restService: RestService) {
  }
  private resourceName = 'request';


  public create(model: ResponseModel): Observable<any> {
    return this.restService.post(this.resourceName, model);
  }
  public getAll(): Observable<any> {
    return this.restService.getAll(this.resourceName);
  }
  public getById(id): Observable<any> {
    return this.restService.getById(this.resourceName, id);
  }


}


