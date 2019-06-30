import { Component, OnInit } from '@angular/core';
import { RequestModel } from '../shared/request.model';
import { RequestCreateComponent } from '../request-create/request-create.component';
import { State } from '@progress/kendo-data-query';
import { MatDialog } from '@angular/material';
import { RequestService } from '../shared/request.service';
import { BehaviorSubject, Observable } from 'rxjs';
import { GridDataResult } from '@progress/kendo-angular-grid';
import { ResponseCreateComponent } from 'src/app/response/response-create/response-create.component';
import { ResponseModel } from 'src/app/response/shared/response.model';

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
      this.service.getForGrid(this.gridState).subscribe(a => {
          this.loading = false;
          this.view.next(a);
      });
  }

  public edit(model: RequestModel) {
      const dialogRef = this.dialog.open(RequestCreateComponent, {
          width: '600px',
          data: { id: model.RequestId }
      });
      dialogRef.afterClosed().subscribe(result => {
          if (result) {
              this.reloadGrid();
          }
      });
  }

  public create(model: RequestModel) {
    const dialogRef = this.dialog.open(ResponseCreateComponent, {
        width: '600px',
        // data: { id: model.ResponseId }
    });
    dialogRef.afterClosed().subscribe(result => {
        if (result) {
            this.reloadGrid();
        }
    });
}
  public delete(model: RequestModel) {
      this.service.delete(model.RequestId).subscribe(result => {
          if (result) {
              this.reloadGrid();
          }
      });
  }

}
