import { Injectable, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { RestService } from 'src/app/framework/services/rest.service';
import { ProfileModel } from './profile.model';

@Injectable({
  providedIn: 'root'
})
export class ProfileService implements OnInit {
  constructor(private restService: RestService) {
  }
  private resourceName = 'Profile';
  ngOnInit() {
  }
  editProfile(model: ProfileModel) {
    return this.restService.post(this.resourceName, model);
  }

  public get(): Observable<ProfileModel> {
    return this.restService.getAll(this.resourceName);
  }

 
}
