import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError, map, tap } from 'rxjs/operators';
import { Observable, of } from 'rxjs';
import { Paycheck } from '../ViewModels/Paycheck';

@Injectable({
  providedIn: 'root'
})
export class PaycheckService {

  constructor(private http: HttpClient) { }

  getPaycheck(formValue: any): Observable<Paycheck> {

    return this.http.post("https://localhost:5001/api/v1/paycheck/deductions", formValue)
      .pipe(
        catchError(err => {
          console.log('[PAYCHECK SERVICE][ERROR][GET PAYCHECK]');
          console.log('ERORR: ', err);
          return of(null);
        })
      );

  }

}
