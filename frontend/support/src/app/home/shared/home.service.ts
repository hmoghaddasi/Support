import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { RestService } from 'src/app/framework/services/rest.service';

@Injectable({
  providedIn: 'root'
})
export class HomeService  {

  private resourceName = 'Home';

  constructor(private restService: RestService) { }

  public getHomeInfo(): Observable<any> {
    return this.restService.getAll(this.resourceName);
  }
}
