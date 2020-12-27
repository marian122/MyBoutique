import { Injectable } from '@angular/core';
import { HttpClient, HttpEvent, HttpHeaders, HttpRequest } from '@angular/common/http';
import { environment } from '../environments/environment';
import { catchError, map, tap } from 'rxjs/operators';
import { Observable, throwError } from 'rxjs';
import { Product } from '../_models/product';
import { Order } from '../_models/order';
import { Picture } from '../_models/picture';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {
  public products = [];
  public orders = [];
  public subTotal = 0;
  public orderData = [];

  constructor(private http: HttpClient) { }

  createProduct(data) {

    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });

    return this.http.post(`${environment.apiUrl}/api/products`, data, { headers, responseType: 'json' },)
      .pipe(
        tap(data => console.log('createdProduct: ', JSON.stringify(data)))
      );
  }

  updateProduct(product): Observable<Product> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http.put<Product>(`${environment.apiUrl}/api/products/edit/${product.id}`, product, { headers, responseType: 'json' },)
      .pipe(
        tap(data => console.log('editedProduct: ', JSON.stringify(data)))
      );

  }

  deleteProduct(id: number): Observable<{}> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http.delete(`${environment.apiUrl}/api/products/${id}`, { headers: headers })
      .pipe(
        catchError(this.handleError)
      );
  }

  deleteSize(id: number): Observable<{}> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http.delete(`${environment.apiUrl}/api/products/size/${id}`, { headers: headers })
      .pipe(
        catchError(this.handleError)
      );
  }

  deleteColor(id: number): Observable<{}> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http.delete(`${environment.apiUrl}/api/products/color/${id}`, { headers: headers })
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


  public getById(id: any): Observable<Product> {
    return this.http.get<Product>(`${environment.apiUrl}/api/products/${id}`);
  }


  upload(files): Observable<HttpEvent<any>> {


    return this.http.post(`${environment.apiUrl}/api/image`, files, {
      reportProgress: true,
      observe: "events"
    }).pipe(
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
