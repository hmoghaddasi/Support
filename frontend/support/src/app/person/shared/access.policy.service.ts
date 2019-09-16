import { Injectable, OnInit } from '@angular/core';
import { Observable, from, Subject } from 'rxjs';
import { RestService } from 'src/app/framework/services/rest.service';
import { PersonModel } from './person.model';
import { State } from '@progress/kendo-data-query';
import { GridDataResult } from '@progress/kendo-angular-grid';
import { ChangePersonAccessModel } from './change.person.access.model';

@Injectable({
  providedIn: 'root'
})
export class AccessPolicyService {
  public needDataUpdate = new Subject<boolean>();
  constructor(private restService: RestService) {
  }
  private resourceName = 'AccessPolicy';

  public changePersonAccess(changePersonAccessModel: ChangePersonAccessModel): any {
    return this.restService.post(this.resourceName + '/' + 'ChangePersonAccess', changePersonAccessModel);
  }

}
