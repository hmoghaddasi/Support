import { Component, OnInit, Input, OnDestroy } from '@angular/core';
import { GridDataResult } from '@progress/kendo-angular-grid';
import { State } from '@progress/kendo-data-query';
import { BehaviorSubject, Subscription } from 'rxjs';
import { MatDialog } from '@angular/material';
import { PersonService } from '../shared/person.service';
import { ValidationModel } from '../shared/validation.model';
import { BaseResponseDto } from 'src/app/framework/base-response/base-response-dto';
import Swal from 'sweetalert2';
import { PersonAccessComponent } from '../person-access/person-access.component';

@Component({
  selector: 'app-person-list',
  templateUrl: './person-list.component.html',
  styleUrls: ['./person-list.component.css']
})
export class PersonListComponent implements OnInit, OnDestroy {
  public view = new BehaviorSubject<GridDataResult>(null);
  subscriptions = new Subscription();
  @Input() statusId: number;
  public gridState: State = {
    sort: [],
    skip: 0,
    take: 10
  };
  public loading: boolean;

  constructor(private service: PersonService, private dialog: MatDialog) {
    this.subscriptions = service.needDataUpdate.subscribe(res => {
      if (res) {
        this.reloadGrid();
      }
    });
  }

  // tslint:disable-next-line:use-life-cycle-interface
  ngOnDestroy(): void {
    this.subscriptions.unsubscribe();
  }

  ngOnInit() {
    this.reloadGrid();
  }
  public onStateChange(state: State) {
    this.gridState = state;
    this.reloadGrid();
  }
  public reloadGrid() {
    this.loading = true;
    this.service.getForGrid(this.gridState, this.statusId).subscribe(a => {
      this.loading = false;
      this.view.next(a);
    });
  }
  accept(model: ValidationModel) {
    this.service.accept(model.PersonId).subscribe((res: BaseResponseDto) => {
      if (res.ResultCode === 200) {
        Swal.fire('عملیات موفق', res.Message, 'success');
        this.service.needDataUpdate.next(true);
      } else {
        Swal.fire('عملیات ناموفق', res.Message, 'error');
      }
    }, err => {
      Swal.fire('خطایی رخ داده است', err.error.Message, 'error');
    });
  }

  activate(model: ValidationModel) {
    this.service.activate(model.PersonId).subscribe((res: BaseResponseDto) => {
      if (res.ResultCode === 200) {
        Swal.fire('عملیات موفق', res.Message, 'success');
        this.service.needDataUpdate.next(true);
      } else {
        Swal.fire('عملیات ناموفق', res.Message, 'error');
      }
    }, err => {
      Swal.fire('خطایی رخ داده است', err.error.Message, 'error');
    });
  }

  deactivate(model: ValidationModel) {
    this.service.deactivate(model.PersonId).subscribe((res: BaseResponseDto) => {
      if (res.ResultCode === 200) {
        Swal.fire('عملیات موفق', res.Message, 'success');
        this.service.needDataUpdate.next(true);
      } else {
        Swal.fire('عملیات ناموفق', res.Message, 'error');
      }
    }, err => {
      Swal.fire('خطایی رخ داده است', err.error.Message, 'error');
    });
  }

  access(id: number) {
    const dialogRef = this.dialog.open(PersonAccessComponent, {
      width: '600px',
      data: id
    });
  }
}
