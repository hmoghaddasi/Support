import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { resetpassModel } from '../shared/resetpass.model';
import { RegistrationService } from '../shared/registration.service';
import { Router } from '@angular/router';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-resetpass',
  templateUrl: './resetpass.component.html',
  styleUrls: ['./resetpass.component.css']
})
export class ResetpassComponent implements OnInit {
  model = new resetpassModel();
  constructor(private service: RegistrationService, private router: Router) { }

  ngOnInit() {
  }
  
  reset() {
    this.service.resetpass(this.model).subscribe(a => {
      Swal.fire('عملیات موفق', 'رمز عبور جدید برایتان ارسال گردید', 'success');
      this.router.navigate(['./login']);
    });
  }
}
