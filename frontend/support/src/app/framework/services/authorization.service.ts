import { Injectable } from '@angular/core';
import { RestService } from './rest.service';
import { Observable, Subject } from 'rxjs';
import { StorageService } from './storage.service';


@Injectable({ providedIn: 'root' })
export class AuthorizationService {

    private permissions: Array<string>;
    public loadingPermissionsDone = new Subject<boolean>();
    constructor(private restService: RestService,
                private storageService: StorageService) { }

    public loadPermissions() {
        this.getAccess().subscribe(access => {
            debugger;
            this.storageService.store('access', access);
            this.loadingPermissionsDone.next(true);
        });
    }

    public hasPermission(permission: string): boolean {
        const access = this.storageService.load('access');
        if (access !== null) {
            this.permissions = access.split(',');
            return this.permissions.includes(permission);
        } else {
            return false;
        }
    }

    public logout(): void {
        this.storageService.clear();
    }
    private getAccess(): Observable<any> {
        return this.restService.getAll('AccessPolicy');
    }
}
