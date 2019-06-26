import { Injectable } from '@angular/core';
import { RestService } from './rest.service';
import { Observable } from 'rxjs';
import { StorageService } from './storage.service';


@Injectable({ providedIn: 'root' })
export class AuthorizationService {

    private permissions: Array<string>;
    constructor(private restService: RestService,
                private storageService: StorageService) { }

    public loadPermissions() {

        this.getAccess().subscribe(a => {
            this.storageService.store('access', a);
        });
    }

    public hasPermission(permission: string): boolean {
        const access = this.storageService.load('access');
        if (access !== null) {
            this.permissions = access.split(',');
            return this.permissions.includes(permission);
        } else {
            return true;
        }
    }

    public logout(): void {
        this.storageService.clear();
    }
    private getAccess(): Observable<any> {
        return this.restService.getAll('Access');
    }
}
