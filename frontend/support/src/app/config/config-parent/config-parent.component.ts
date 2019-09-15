import { Component, OnInit } from '@angular/core';
import { ConfigService } from '../shared/config.service';
import { ConfigModel } from '../shared/config.model';
import { Observable } from 'rxjs';
import { ConfigCreateComponent } from '../config-create/config-create.component';
import { MatDialog } from '@angular/material';
import { BaseResponseDto } from 'src/app/framework/base-response/base-response-dto';
import Swal from 'sweetalert2';

export class DialogData {
  configId: number;
}
@Component({
  selector: 'app-config-parent',
  templateUrl: './config-parent.component.html',
  styleUrls: ['./config-parent.component.css']
})
export class ConfigParentComponent implements OnInit {
  configs: Observable<ConfigModel>;
  constructor(private service: ConfigService,
    private dialog: MatDialog) { }

  ngOnInit() {
    this.configs = this.service.getConfigChild(0);
    this.configs.subscribe(s =>{
      console.log(s);
    })
  }


  create() {
    const dialogRef = this.dialog.open(ConfigCreateComponent, {
      width: '600px',
      data: null
    });
    dialogRef.componentInstance.confirmedEventEmitter.subscribe((result: BaseResponseDto) => {
      if (result.resultCode === 200) {
        Swal.fire('عملیات موفق', result.message, 'success');
        this.configs = this.service.getConfigChild(0);
      } else {
        Swal.fire('عملیات ناموفق', result.message, 'error');
      }
    });
  }
}
