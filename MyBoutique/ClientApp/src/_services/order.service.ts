import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from '../environments/environment';
import { map, tap } from 'rxjs/operators';
import { Order } from '../_models/order';

@Injectable({
  providedIn: 'root'
})
export class OrderService {
  public orders = [];
  public subTotal = 0;

  constructor(private http: HttpClient) { }

  public getAllOrders() {
    return this.http.get(`${environment.apiUrl}/api/orders`)
      .pipe(map((data: Order[]) => {
        this.orders = data;
        return true;
      }))
  }

  public addProductToCard(data) {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http.post(`${environment.apiUrl}/api/orders`, data, { headers, responseType: 'text' })
      .pipe(
        tap(data => console.log('addedOrder: ', JSON.stringify(data)))
      );
  }

  public deleteOrder(id: number) {
    return this.http.delete(`${environment.apiUrl}/api/orders/${id}`)
      .pipe(
        tap(data => console.log('deleted order: ', JSON.stringify(data)))
      );
  }

  public deleteOrdersFromCartForCurrentUser(userId: string) {
    return this.http.delete(`${environment.apiUrl}/api/orders/clear/${userId}`)
      .pipe(
        tap(data => console.log('deleted orders: ', JSON.stringify(data)))
      );
  }

}
