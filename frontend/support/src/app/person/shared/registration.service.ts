import { Injectable } from '@angular/core';
import { RegistrationModel } from './registration.model';
import { Observable } from 'rxjs';
import { RestService } from 'src/app/framework/services/rest.service';
import { VerificationModel } from './verification.model';
import { ValidationModel } from './validation.model';
import { MembershipModel } from './membership.model';
import { resetpassModel } from './resetpass.model';
import { ChangePasswordModel } from './changepassword.model';
import { LoginModel } from './login.model';
import { NewPharmacyMembershipModel } from './new-pharmacy-memebership';

@Injectable({
  providedIn: 'root'
})
export class RegistrationService  {

  constructor(private restService: RestService) {
  }

  public register(model: RegistrationModel): Observable<any> {
    return this.restService.post('register', model);
  }
  public verification(model: VerificationModel): Observable<any> {
    return this.restService.post('verification', model);
  }
  public validation(model: ValidationModel): Observable<any> {
    return this.restService.post('validation', model);
  }
  public membership(model: MembershipModel): Observable<any> {
    return this.restService.post('membership', model);
  }
  public resetpass(model: resetpassModel): Observable<any> {
    return this.restService.post('ResetPassword', model);
  }
  public change(model: ChangePasswordModel): Observable<any> {
    return this.restService.post('changepassword', model);
  }
  public login(model: LoginModel): Observable<any> {
    return this.restService.post('token', model);
  }

}

