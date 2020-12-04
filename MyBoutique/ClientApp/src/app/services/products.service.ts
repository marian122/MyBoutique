import { Injectable } from '@angular/core';
import { HttpClient, HttpEvent, HttpHeaders, HttpRequest } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { catchError, map, tap } from 'rxjs/operators';
import { Observable, throwError } from 'rxjs';
import { Product } from '../models/product';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {
  public products = [];

  constructor(private http: HttpClient) { }

  public createProduct(data) {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });

    return this.http.post(`${environment.apiUrl}/api/products`, data, { headers, responseType: 'text' })
      .pipe(
        tap(data => console.log('createdProduct: ', JSON.stringify(data))),
        catchError(this.handleError)
      );
  }

  public getAll(){
    return this.http.get(`${environment.apiUrl}/api/products`)
    .pipe(map((data: Product[]) => {
      data.sort((a,b) => b.price - a.price);
      this.products = data;
      return true;
    }))
  }

  public getById(id: any): Observable<Product>{
    return this.http.get<Product>(`${environment.apiUrl}/api/products/${id}`);
  }

  private handleError(err): Observable<never> {
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
