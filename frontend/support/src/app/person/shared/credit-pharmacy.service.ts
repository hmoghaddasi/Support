import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { RestService } from 'src/app/framework/services/rest.service';
import Swal from 'sweetalert2';
import { BaseResponseDto } from 'src/app/framework/base-response/base-response-dto';
import { CreditPharmacyModel } from './credit-pharmacy.model';

@Injectable({
  providedIn: 'root'
})
export class CreditPharmacyService {
  private resourceName = 'CreditPharmacy';
  public needDataUpdate = new Subject<boolean>();
    constructor(private restService: RestService) {
  }
  public create(model: CreditPharmacyModel): Observable<any> {
    return this.restService.post(this.resourceName, model);
  }
}