import { NativeDateAdapter } from '@angular/material';
import { Platform } from '@angular/cdk/platform';


export class CustomDateAdapter extends NativeDateAdapter {
   MY_DATE_FORMATS = {
    parse: {
      dateInput: { month: 'short', year: 'numeric', day: 'numeric' }
    },
    display: {
      dateInput: 'input',
      monthYearLabel: { year: 'numeric', month: 'short' },
      dateA11yLabel: { year: 'numeric', month: 'long', day: 'numeric' },
      monthYearA11yLabel: { year: 'numeric', month: 'long' }
    }
  };
  constructor(matDateLocale: string) {
    super(matDateLocale, new Platform());
  }
  // format(date: Date, displayFormat: object): string {
  //   const faDate = moment(date.toDateString()).locale('fa').format('YYYY/MM/DD');
  //   return faDate;
  // }
}
