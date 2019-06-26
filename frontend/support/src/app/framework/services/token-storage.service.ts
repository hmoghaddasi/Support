import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root'
})
export class TokenStorageService {

    store(token: string) {
        sessionStorage.setItem('token', token);
    }

    load(): string {
        const token = sessionStorage.getItem('token');
        return 'Bearer ' + token;
    }
    public signed(): boolean {
        if (sessionStorage.getItem('token') === undefined || sessionStorage.getItem('token') === null) {
            return false;
        } else {
            if (sessionStorage.getItem('token').length > 0) {
                return true;
        }}
        return false;
    }
}
