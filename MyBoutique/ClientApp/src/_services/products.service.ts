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

    return this.http.post(`${environment.apiUrl}/api/products`, data, { headers, responseType: 'text' })
      .pipe(
        tap(data => console.log('createdProduct: ', JSON.stringify(data)))
      );
  }

  public getAll(){
    return this.http.get(`${environment.apiUrl}/api/products`)
      .pipe(map((data: any[]) => {
        data.sort((a, b) => {
          return this.getTime(b.createdOn) - this.getTime(a.createdOn)
        });
      this.products = data;
      return true;
    }))
  }

  private getTime(date?: Date) {
    return date != null ? new Date(date).getTime() : 0;
  }

  public getById(id: any): Observable<Product>{
    return this.http.get<Product>(`${environment.apiUrl}/api/products/${id}`);
  }
//Later get all orders by session/id
  public getAllOrders(){
    return this.http.get(`${environment.apiUrl}/api/orders`)
    .pipe(map((data: Order[]) => {
      this.orders = data;
      return true;
    }))
  }

  public addProductToCard(data){
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http.post(`${environment.apiUrl}/api/orders`, data, { headers, responseType: 'text' })
    .pipe(
      tap(data => console.log('addedOrder: ', JSON.stringify(data)))
    );
  }
 
  public deleteOrder(id : number){
    return this.http.delete(`${environment.apiUrl}/api/orders/${id}`)
    .pipe( 
      tap(data => console.log('deleted order: ', JSON.stringify(data)))
    );
  }

  public deleteAllProductsFromCart(){
    return this.http.delete(`${environment.apiUrl}/api/orders`)
    .pipe( 
      tap(data => console.log('deleted orders: ', JSON.stringify(data)))
    );
  }

  public createOrder(data) {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });

    return this.http.post(`${environment.apiUrl}/api/orderdata`, data, { headers, responseType: 'text' })
      .pipe(
        tap(data => console.log('createdOrder: ', JSON.stringify(data)))
      );
  }

  public getAllOrderData(){
    return this.http.get(`${environment.apiUrl}/api/orderdata`)
    .pipe(map((data: any) => {
      this.orderData = data;
      return true;
    }))
  }

  public completeOrderData(id: number){
    return this.http.delete(`${environment.apiUrl}/api/orderdata/${id}`)
    .pipe(
      tap(data => console.log('completedOrderData: ', JSON.stringify(data)))
    );
  }
}
