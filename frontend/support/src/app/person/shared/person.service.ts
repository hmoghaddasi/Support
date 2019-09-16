import { Injectable, OnInit } from '@angular/core';
import { Observable, from, Subject } from 'rxjs';
import { RestService } from 'src/app/framework/services/rest.service';
import { PersonModel } from './person.model';
import { State } from '@progress/kendo-data-query';
import { GridDataResult } from '@progress/kendo-angular-grid';

@Injectable({
  providedIn: 'root'
})
export class PersonService implements OnInit {
  public needDataUpdate = new Subject<boolean>();
  constructor(private restService: RestService) {
  }
  private resourceName = 'Person';
  person(model: import ('./editprofile.model').EditprofileModel) {
    throw new Error('Method not implemented.');
  }
  register(model: import ('./editprofile.model').EditprofileModel) {
    throw new Error('Method not implemented.');
  }
  editprofile(model: import ('./editprofile.model').EditprofileModel) {
    return this.restService.put(this.resourceName, model);
  }
  ngOnInit() {
  }
  public getById(id: number): Observable<any> {
    return this.restService.getById(this.resourceName, id);
  }

  public update(model: PersonModel): Observable<any> {
    return this.restService.put(this.resourceName, model);
  }
  public getAll(): Observable<any> {
    return this.restService.getAll(this.resourceName);
  }
  public getForGrid(state: State, statusId): Observable<GridDataResult> {
    return this.restService.getForGrid(this.resourceName, state, statusId);
  }
  // public getForValidationGrid(state: State): Observable<GridDataResult> {
  //   return this.restService.getForGrid('Validation', state);
  // }
  public accept(PersonId: number): any {
    return this.restService.customAction(this.resourceName + '/' + 'Validate', PersonId);
  }
  public activate(PersonId: number): any {
    return this.restService.customAction(this.resourceName + '/' + 'Activate', PersonId);
  }
  public deactivate(PersonId: number): any {
    return this.restService.customAction(this.resourceName + '/' + 'DeActivate', PersonId);
  }
}
