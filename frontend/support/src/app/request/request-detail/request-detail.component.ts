import { Component, OnInit } from '@angular/core';
import { RequestDetailModel } from '../shared/request-detail.model';
import { RequestService } from '../shared/request.service';
import { ActivatedRoute, Router } from '@angular/router';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-request-detail',
  templateUrl: './request-detail.component.html',
  styleUrls: ['./request-detail.component.css']
})
export class RequestDetailComponent {

  model = new RequestDetailModel();
  user: string;

  constructor(private requestService: RequestService,
    private activatedRoute: ActivatedRoute,
    private router: Router) {
    this.activatedRoute.params.subscribe(params => {
      this.model.RequestId = +params['id'];
      this.user = params['user'];
    });
    this.requestService.getById(this.model.RequestId).subscribe((res: RequestDetailModel) => {
      this.model = res;
    }, err => {
      Swal.fire('خطا', err.error.message, 'error');
    });
  }
}
