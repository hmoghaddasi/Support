// import { Injectable } from '@angular/core';
// import { HttpClient } from '@angular/common/http';
// import { GridDataResult } from '@progress/kendo-angular-grid';
// import { toODataString } from '@progress/kendo-data-query';
// import { Observable } from 'rxjs/Observable';
// import { BehaviorSubject } from 'rxjs/BehaviorSubject';
// import { map } from 'rxjs/operators/map';
// import { tap } from 'rxjs/operators/tap';
// import { environment } from 'src/environments/environment';

// export abstract class GridService extends BehaviorSubject<GridDataResult> {
//     public loading: boolean;

//     constructor(
//         private http: HttpClient,
//         protected tableName: string
//     ) {
//         super(null);
//     }

//     public query(state: any): void {
//         this.fetch(this.tableName, state)
//             .subscribe(x => super.next(x));
//     }

//     protected fetch(tableName: string, state: any): Observable<GridDataResult> {
//         const queryStr = `${toODataString(state)}&$count=true`;
//         this.loading = true;
//         return this.http
//             .get(`${environment.baseUrl}${tableName}`)
//             .pipe(
//                 map(response => ({
//                     data: response,
//                     total: parseInt(response['@odata.count'], 10)
//                 } as GridDataResult)),
//                 tap(() => this.loading = false)
//             );
//     }
// }
