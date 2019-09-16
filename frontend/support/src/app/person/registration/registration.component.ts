import { Component, OnInit } from '@angular/core';
import { RegistrationModel } from '../shared/registration.model';
import { RegistrationService } from '../shared/registration.service';
import { TokenStorageService } from 'src/app/framework/services/token-storage.service';
import { Router } from '@angular/router';
import Swal from 'sweetalert2';


@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {

  model = new RegistrationModel();
    constructor(private service: RegistrationService,
                private router: Router,
                private tokenService: TokenStorageService) { }

  ngOnInit() {
  }

  register() {
    this.service.register(this.model).subscribe(result => {
      this.tokenService.store(result.token);
      this.router.navigate(['./verification']);
      Swal.fire('عملیات موفق', 'کاربر شما در سامانه ثبت شد. مراحل بعدی عضویت را تکمیل نمایید', 'success');
    },err => {
      Swal.fire('خطایی رخ داد', err.error.Message, 'error');
    });
  }
}
