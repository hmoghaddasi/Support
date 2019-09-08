import { Component, OnInit } from '@angular/core';
import { LoginModel } from 'src/app/person/shared/login.model';
import { RegistrationService } from 'src/app/person/shared/registration.service';
import { Router } from '@angular/router';
import { StorageService } from 'src/app/framework/services/storage.service';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.css']
})
// tslint:disable-next-line:class-name
export class footerComponent implements OnInit {


  model = new LoginModel();
  constructor(private service: RegistrationService, private router: Router, private storageService: StorageService) { }

  ngOnInit() {
  }
  login() {
    this.service.login(this.model).subscribe(a => {
      this.storageService.store('id', '1012');
      this.router.navigate(['./']);
    });
  }
}
