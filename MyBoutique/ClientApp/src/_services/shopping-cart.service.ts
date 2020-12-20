import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { tap, map } from 'rxjs/operators';
import { environment } from '../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ShoppingCartService {
  public orders = [];
  public subTotal = 0;
  public orderData = [];

  constructor(private http: HttpClient) { }

  public createOrder(data) {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });

    return this.http.post(`${environment.apiUrl}/api/orderdata`, data, { headers, responseType: 'text' })
      .pipe(
        tap(data => console.log('createdOrder: ', JSON.stringify(data)))
      );
  }

  public getAllOrderData() {
    return this.http.get(`${environment.apiUrl}/api/orderdata`)
      .pipe(map((data: any) => {
        this.orderData = data;
        return true;
      }))
  }

  public completeOrderData(id: number) {
    return this.http.delete(`${environment.apiUrl}/api/orderdata/${id}`)
      .pipe(
        tap(data => console.log('completedOrderData: ', JSON.stringify(data)))
      );
  }
}
