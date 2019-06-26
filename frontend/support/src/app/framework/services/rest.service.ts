import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { TokenStorageService } from './token-storage.service';
import { State } from '@progress/kendo-data-query';
import { GridDataResult } from '@progress/kendo-angular-grid';
// import { State } from '@progress/kendo-data-query';
// import { GridDataResult } from '@progress/kendo-angular-grid';

@Injectable({
  providedIn: 'root'
})
export class RestService {
  [x: string]: any;

  constructor(private http: HttpClient,
              private tokenService: TokenStorageService) { }

  public post<TResonse>(resource: string, model: any): Observable<TResonse> {
    return this.http.post<TResonse>(this.getUrl(resource), model, this.createHeaders());
  }
  public put<TResonse>(resource: string, model: any): Observable<TResonse> {
    return this.http.put<TResonse>(this.getUrl(resource), model, this.createHeaders());
  }
  public delete(resource: string, id: number): Observable<any> {
    return this.http.delete(this.getUrl(resource) + id, this.createHeaders());
  }
  public getAll<TResonse>(resource: string): Observable<TResonse> {
    return this.http.get<TResonse>(this.getUrl(resource), this.createHeaders());
  }
  public getForGrid(resource: string, state: State, id: number = null): Observable<GridDataResult> {
    let queryString = `skip=${state.skip}&take=${state.take}`;
    if (state.filter != null) {
      const filter = encodeURIComponent(JSON.stringify(state.filter));
      queryString += `&filter=${filter}`;
    }
    if (id !== undefined) {
      queryString += `&id=${id}`;
    }
    return this.http.get<GridDataResult>(`${environment.baseUrl}${resource}Grid?${queryString}`, this.createHeaders());

  }
  public getById<TResonse>(resource: string, id: number): Observable<TResonse> {
    return this.http.get<TResonse>(this.getUrl(resource) + id, this.createHeaders());
  }
  public customAction<TResonse>(action: string, id: number): any {
    return this.http.get<TResonse>(`${environment.baseUrl}${action}?id=` + id, this.createHeaders());
  }
  private createHeaders() {
    const token = this.tokenService.load();
    return { headers: new HttpHeaders().set('Authorization', token) };
  }
  private getUrl(resource: string) {
    return `${environment.baseUrl}${resource}/`;
  }
}
