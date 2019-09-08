import { Component, OnInit } from '@angular/core';
import { AuthorizationService } from 'src/app/framework/services/authorization.service';


@Component({
    template: ''
  })

  export class LogoutComponent implements OnInit {
    constructor(private service: AuthorizationService) {}
    ngOnInit() {
      this.service.logout();
      window.location.href = './';
    }
  }
