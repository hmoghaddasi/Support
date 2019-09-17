import { Component, OnInit } from '@angular/core';
import { RequestService } from '../shared/request.service';
import { Observable, BehaviorSubject } from 'rxjs';
import { RequestCreateModel } from '../shared/request.model';
import { MatDialog } from '@angular/material';
import { GridDataResult } from '@progress/kendo-angular-grid';
import { State } from '@progress/kendo-data-query';
import { RequestCreateComponent } from '../request-create/request-create.component';
import { BaseResponseDto } from 'src/app/framework/base-response/base-response-dto';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-user-request-list',
  templateUrl: './user-request-list.component.html',
  styleUrls: ['./user-request-list.component.css']
})
export class UserRequestListComponent implements OnInit {
  public view = new BehaviorSubject<GridDataResult>(null);
  public gridState: State = {
    sort: [],
    skip: 0,
    take: 10
  };
  public loading: boolean;
  constructor(private service: RequestService,
    private dialog: MatDialog) { }

  ngOnInit() {
    this.reloadGrid();
  }
  public onStateChange(state: State) {
    this.gridState = state;
    this.reloadGrid();
  }
  public reloadGrid() {
    this.loading = true;
    this.service.getForGridUser(this.gridState).subscribe(a => {
      this.loading = false;
      this.view.next(a);
    });
  }

  create() {
    const dialogRef = this.dialog.open(RequestCreateComponent, {
      width: '600px',
      data: null
    });
    dialogRef.componentInstance.confirmedEventEmitter.subscribe((result: BaseResponseDto) => {
      if (result.resultCode === 200) {
        Swal.fire('عملیات موفق', result.message, 'success');
        this.reloadGrid();
      } else {
        Swal.fire('عملیات ناموفق', result.message, 'error');
      }
    });
  }
}
