import { Component, OnInit } from '@angular/core';
import { RestService } from 'src/app/framework/services/rest.service';
import { VerificationModel } from '../shared/verification.model';
import { StorageService } from 'src/app/framework/services/storage.service';
import { Router } from '@angular/router';
import Swal from 'sweetalert2';
import { AuthorizationService } from 'src/app/framework/services/authorization.service';

@Component({
  selector: 'app-verification',
  templateUrl: './verification.component.html',
  styleUrls: ['./verification.component.css']
})
export class VerificationComponent implements OnInit {
  model = new VerificationModel();
  constructor(private service: RestService, private router: Router, private authService: AuthorizationService) { }

  ngOnInit() {
  }
  varification() {
    this.service.post('Verification', this.model).subscribe(a => {
      Swal.fire('عملیات موفق', 'شماره موبایل شما با موفقیت تایید گردید', 'success');
      this.authService.logout();
      this.router.navigate(['./register-success']);
    }, err => {
      Swal.fire('خطایی رخ داد', err.error.message, 'error');
    });
  }
}

