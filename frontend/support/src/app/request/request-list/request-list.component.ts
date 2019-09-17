import { Component, OnInit } from '@angular/core';
import { RequestCreateModel } from '../shared/request.model';
import { RequestCreateComponent } from '../request-create/request-create.component';
import { State } from '@progress/kendo-data-query';
import { MatDialog } from '@angular/material';
import { RequestService } from '../shared/request.service';
import { BehaviorSubject, Observable } from 'rxjs';
import { GridDataResult } from '@progress/kendo-angular-grid';
import { ResponseModel } from 'src/app/response/shared/response.model';
import { BaseResponseDto } from 'src/app/framework/base-response/base-response-dto';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-request-list',
  templateUrl: './request-list.component.html',
  styleUrls: ['./request-list.component.css']
})
export class RequestListComponent implements OnInit {
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
      this.service.getForGrid(this.gridState).subscribe(a => {
          this.loading = false;
          this.view.next(a);
      });
  }

  close(id: number) {
    this.service.closeTicket(id).subscribe((res: BaseResponseDto) => {
      if (res.resultCode === 200) {
        Swal.fire('عملیات موفق', res.message, 'success');
        this.reloadGrid();
    } else {
        Swal.fire('عملیات ناموفق', res.message, 'error');
      }
    }, err => {
      Swal.fire('خطایی رخ داده است', err.error.message, 'error');
    });
  }
}
