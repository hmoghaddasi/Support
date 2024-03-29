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
  accept(id: number) {
    this.service.accept(id).subscribe((res: BaseResponseDto) => {
      if (res.resultCode === 200) {
        Swal.fire('عملیات موفق', res.message, 'success');
        this.service.needDataUpdate.next(true);
      } else {
        Swal.fire('عملیات ناموفق', res.message, 'error');
      }
    }, err => {
      Swal.fire('خطایی رخ داده است', err.error.message, 'error');
    });
  }

  activate(id: number) {
    this.service.activate(id).subscribe((res: BaseResponseDto) => {
      if (res.resultCode === 200) {
        Swal.fire('عملیات موفق', res.message, 'success');
        this.service.needDataUpdate.next(true);
      } else {
        Swal.fire('عملیات ناموفق', res.message, 'error');
      }
    }, err => {
      Swal.fire('خطایی رخ داده است', err.error.message, 'error');
    });
  }

  deactivate(id: number) {
    this.service.deactivate(id).subscribe((res: BaseResponseDto) => {
      if (res.resultCode === 200) {
        Swal.fire('عملیات موفق', res.message, 'success');
        this.service.needDataUpdate.next(true);
      } else {
        Swal.fire('عملیات ناموفق', res.message, 'error');
      }
    }, err => {
      Swal.fire('خطایی رخ داده است', err.error.message, 'error');
    });
  }

  access(id: number) {
    const dialogRef = this.dialog.open(PersonAccessComponent, {
      width: '600px',
      data: id
    });
  }
}
