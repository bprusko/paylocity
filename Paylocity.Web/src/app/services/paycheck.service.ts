import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError, map, tap } from 'rxjs/operators';
import { Observable, of } from 'rxjs';
import { FeeInfo } from '../ViewModels/FeeInfo';

@Injectable({
  providedIn: 'root'
})
export class PaycheckService {

  constructor(private http: HttpClient) { }

  getPaycheck(formValue: any): Observable<FeeInfo> {

    return this.http.post("http://localhost:5000/api/v1/benefits/fees", formValue)
      .pipe(
        catchError(err => {
          console.log('[PAYCHECK SERVICE][ERROR][GET PAYCHECK]');
          console.log('ERORR: ', err);
          return of(null);
        })
      );

  }

}
