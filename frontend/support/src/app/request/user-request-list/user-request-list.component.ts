import { Component, OnInit } from '@angular/core';
import { RequestService } from '../shared/request.service';
import { Observable } from 'rxjs';
import { RequestModel } from '../shared/request.model';
import { ResponseCreateComponent } from 'src/app/response/response-create/response-create.component';
import { MatDialog } from '@angular/material';

@Component({
  selector: 'app-user-request-list',
  templateUrl: './user-request-list.component.html',
  styleUrls: ['./user-request-list.component.css']
})
export class UserRequestListComponent implements OnInit {
  Requests: Observable<RequestModel>;
  model = new RequestModel();   constructor(private service: RequestService,
    private dialog: MatDialog) { }
  ngOnInit() {

  }
  public create(model: RequestModel) {
    const dialogRef = this.dialog.open(ResponseCreateComponent, {
        width: '600px',
        // data: { id: model.ResponseId }
    });
    dialogRef.afterClosed().subscribe(result => {
        if (result) {
        }
    });
}

}
