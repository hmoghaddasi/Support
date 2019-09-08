import { Component, OnInit } from '@angular/core';
import { ProfileModel } from '../shared/profile.model';
import { Router } from '@angular/router';
import { TokenStorageService } from 'src/app/framework/services/token-storage.service';
import { ProfileService } from '../shared/profile.service';
import { MatDialog } from '@angular/material';
import { BaseResponseDto } from 'src/app/framework/base-response/base-response-dto';
import Swal from 'sweetalert2';
@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})

export class ProfileComponent implements OnInit {
  public model = new ProfileModel();
  constructor(private service: ProfileService, private router: Router, private dialog: MatDialog,
              private tokenService: TokenStorageService) {
    this.reloadDate();
  }

  ngOnInit() {
  }

  reloadDate() {
    this.service.get().subscribe(a => {
      this.model = a;
      console.log(a);
    });
  }

}



