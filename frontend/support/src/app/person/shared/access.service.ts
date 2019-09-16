import { Injectable, OnInit } from '@angular/core';
import { Observable, from, Subject } from 'rxjs';
import { RestService } from 'src/app/framework/services/rest.service';
import { PersonModel } from './person.model';
import { State } from '@progress/kendo-data-query';
import { GridDataResult } from '@progress/kendo-angular-grid';

@Injectable({
  providedIn: 'root'
})
export class AccessService {
  public needDataUpdate = new Subject<boolean>();
  constructor(private restService: RestService) {
  }
  private resourceName = 'Access';

  public personAccess(PersonId: number): any {
    return this.restService.customAction(this.resourceName + '/' + 'PersonAccess', PersonId);
  }

}
