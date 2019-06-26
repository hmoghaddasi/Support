import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root'
  })
export class StorageService {

    store(key: string, value: string) {
        sessionStorage.setItem(key, value);
    }

    load(key: string): string {
        return sessionStorage.getItem(key);
    }
   public clear(): void {
        sessionStorage.clear();
    }
}
