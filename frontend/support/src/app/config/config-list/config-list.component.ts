import { Component, OnInit, Input, OnDestroy } from '@angular/core';
import { GridDataResult } from '@progress/kendo-angular-grid';
import { ConfigModel } from 'src/app/config/shared/config.model';
import { ConfigService } from 'src/app/config/shared/config.service';
import { State } from '@progress/kendo-data-query';
import { BehaviorSubject, Subscription } from 'rxjs';
import { MatDialog } from '@angular/material';
import { ConfigCreateComponent } from '../config-create/config-create.component';
import { BaseResponseDto } from 'src/app/framework/base-response/base-response-dto';
import Swal from 'sweetalert2';

export class DialogData {
    configId: number;
}
@Component({
    selector: 'app-config-list',
    templateUrl: './config-list.component.html',
    styleUrls: ['./config-list.component.css']
})
export class ConfigListComponent implements OnInit, OnDestroy {
    @Input() parentId: number;
    public view = new BehaviorSubject
        <GridDataResult>(null);
    public gridState: State = {
        sort: [],
        skip: 0,
        take: 10
    };
    public loading: boolean;
    public editDataItem: ConfigModel;
    subscriptions = new Subscription();

    constructor(private service: ConfigService,
        private dialog: MatDialog) {
        this.subscriptions = service.needDataUpdate.subscribe(res => {
            if (res) {
                this.reloadGrid();
            }
        });
    }

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
        this.service.getForGrid(this.gridState, this.parentId).subscribe(a => {
            this.loading = false;
            this.view.next(a);
        });
    }

    public edit(model: ConfigModel) {
        const dialogRef = this.dialog.open(ConfigCreateComponent, {
            width: '600px',
            data: model
        });
        dialogRef.componentInstance.confirmedEventEmitter.subscribe((result: BaseResponseDto) => {
            if (result.ResultCode === 200) {
                Swal.fire('عملیات موفق', result.Message, 'success');
                this.service.needDataUpdate.next(true);
            } else {
                Swal.fire('عملیات ناموفق', result.Message, 'error');
            }
        });
    }

    public delete(model: ConfigModel) {
        this.service.delete(model.ConfigId);
    }
}
