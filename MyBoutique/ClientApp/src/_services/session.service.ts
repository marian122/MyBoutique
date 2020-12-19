import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { environment } from '../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class SessionService {

  constructor(private http: HttpClient) { }


  setSession(data: any): Observable<string> {
    return this.http.get<string>(`${environment.apiUrl}/api/set/${data}`)
    .pipe(
      tap(info => console.log('created session: ', info)),
      catchError(this.handleError)
    )
  }

  getSession() {
    return this.http.get(`${environment.apiUrl}/api/get`)
    .pipe(
      tap(info => console.log('currentSession: ', JSON.stringify(info))),
      catchError(this.handleError)
    )
  }

  private handleError(err) {  
    let errorMessage: string;  
    if (err.error instanceof ErrorEvent) {  
      errorMessage = `An error occurred: ${err.error.message}`;  
    } else {  
      errorMessage = `Backend returned code ${err.status}: ${err.body.error}`;  
    }  
    console.error(err);  
    return throwError(errorMessage);  
  }  

}
