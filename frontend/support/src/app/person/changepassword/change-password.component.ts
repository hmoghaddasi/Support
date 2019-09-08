import { Component, OnInit } from '@angular/core';
import { RegistrationService } from '../shared/registration.service';
import { ChangePasswordModel } from '../shared/changepassword.model';

@Component({
  selector: 'app-change-password',
  templateUrl: './change-password.component.html',
  styleUrls: ['./change-password.component.css']
})
export class ChangePasswordComponent implements OnInit {
  model = new ChangePasswordModel();
  constructor(private service: RegistrationService) { }

  ngOnInit() {
  }
  change() {
    this.service.change(this.model).subscribe(a => {
    });
  }
}
