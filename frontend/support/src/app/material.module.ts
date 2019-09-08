import { NgModule } from '@angular/core';
import { MatNativeDateModule, MatIconModule, MatButtonModule, MatOption, MatMenuModule, MatSnackBarModule,
    MatTabsModule, MatTableModule, MatCell, MatList, MatGridList, MatRadioButton, MatIcon } from '@angular/material';
import { MatCheckboxModule, MatToolbarModule, MatSelectModule } from '@angular/material';
import { MatCardModule, MatFormFieldModule, MatInputModule, MatRadioModule, MatListModule } from '@angular/material';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatDatepickerModule, NativeDateAdapter, DateAdapter, MAT_DATE_FORMATS, MAT_DATE_LOCALE } from '@angular/material';


@NgModule({
    imports: [
        MatTableModule,
        MatTabsModule,
        MatNativeDateModule,
        MatDatepickerModule,
        MatIconModule,
        MatButtonModule,
        MatCheckboxModule,
        MatToolbarModule,
        FormsModule,
        MatCardModule,
        MatFormFieldModule,
        MatInputModule,
        MatRadioModule,
        MatToolbarModule,
        MatSnackBarModule,
        MatFormFieldModule,
    ],
    exports: [
        MatNativeDateModule,
        FormsModule,
        MatDatepickerModule,
        MatIconModule,
        MatButtonModule,
        MatCheckboxModule,
        MatToolbarModule,
        MatCardModule,
        MatFormFieldModule,
        MatInputModule,
        MatRadioModule,
        MatSelectModule,
        MatMenuModule,
        MatFormFieldModule,
        MatTableModule,
        MatTabsModule,
        MatRadioButton,
        MatIcon
    ],
    providers: [
        { provide: MAT_DATE_LOCALE, useValue: 'fa-IR' },
        // { provide: DateAdapter, useClass: CustomDateAdapter, deps: [MAT_DATE_LOCALE] },
        //  { provide: MAT_DATE_FORMATS, useValue: MY_DATE_FORMATS }
    ],
})
export class MyMaterialModule { }
