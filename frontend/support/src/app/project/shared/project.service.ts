import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { RestService } from 'src/app/framework/services/rest.service';

@Injectable({
  providedIn: 'root'
})
export class ProjectService  {

  private resourceName = 'project';

  constructor(private restService: RestService) { }

  public getAll(): Observable<any> {
    return this.restService.getAll(this.resourceName);
  }




}
