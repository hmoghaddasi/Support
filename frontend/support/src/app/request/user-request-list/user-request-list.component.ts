import { Component, OnInit } from '@angular/core';
import { RequestService } from '../shared/request.service';
import { Observable, BehaviorSubject } from 'rxjs';
import { RequestModel } from '../shared/request.model';
import { ResponseCreateComponent } from 'src/app/response/response-create/response-create.component';
import { MatDialog } from '@angular/material';
import { GridDataResult } from '@progress/kendo-angular-grid';
import { State } from '@progress/kendo-data-query';

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
  public editDataItem: RequestModel;
  Requests: Observable<RequestModel>;
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
}
