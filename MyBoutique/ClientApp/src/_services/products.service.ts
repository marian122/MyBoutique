import { Injectable } from '@angular/core';
import { HttpClient, HttpEvent, HttpHeaders, HttpRequest } from '@angular/common/http';
import { environment } from '../environments/environment';
import { catchError, map, tap } from 'rxjs/operators';
import { Observable, throwError } from 'rxjs';
import { Product } from '../_models/product';
import { Order } from '../_models/order';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {
  public products = [];
  public orders = [];
  public subTotal = 0;
  public orderData = [];

  constructor(private http: HttpClient) { }

  public createProduct(data) {

    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });

    return this.http.post(`${environment.apiUrl}/api/products`, data, { headers, responseType: 'json' },)
      .pipe(
        tap(data => console.log('createdProduct: ', JSON.stringify(data)))
      );
  }

  deleteProduct(id: number): Observable<{}> {  
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });  
    return this.http.delete<Product>(`${environment.apiUrl}/api/products/${id}`, { headers: headers })  
      .pipe(  
        catchError(this.handleError)  
      );  
  }  

  getAll(): Observable<Product[]> {
    return this.http.get<Product[]>(`${environment.apiUrl}/api/products`)
    .pipe(
      catchError(this.handleError)
    )
  }


  public getById(id: any): Observable<Product>{
    return this.http.get<Product>(`${environment.apiUrl}/api/products/${id}`);
  }


  

  upload(files): Observable<HttpEvent<any>> {

    const req = new HttpRequest('POST', `${environment.apiUrl}/api/image`, files, {
      reportProgress: true,
      responseType: 'json'
    });

    return this.http.request(req);

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
