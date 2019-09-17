import { Component, OnInit } from '@angular/core';
import { LoginModel } from '../shared/login.model';
import { RegistrationService } from '../shared/registration.service';
import { AuthorizationService } from 'src/app/framework/services/authorization.service';
import { TokenStorageService } from 'src/app/framework/services/token-storage.service';
import Swal from 'sweetalert2';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  model = new LoginModel();
  subscription = new Subscription();
  constructor(private service: RegistrationService,
              private tokenService: TokenStorageService,
              private accessService: AuthorizationService) {
      this.subscription = this.accessService.loadingPermissionsDone.subscribe(res => {
        window.location.href = './';
      });
    }

  ngOnInit() {
  }
  login() {
    this.service.login(this.model).subscribe(result => {     
      this.tokenService.store(result.token);
      this.accessService.loadPermissions();
      this.tokenService.signed();
      Swal.fire('عملیات موفق', 'با موفقیت وارد شدید', 'success');
    }, err => {
      Swal.fire('خطایی رخ داد', err.error.message, 'error');
    });
  }
}
