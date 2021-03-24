import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from '../environments/environment';
import { map, tap } from 'rxjs/operators';
import { Order } from '../_models/order';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class OrderService {
  cartCountSubject: Subject<number> = new Subject();
  count = 0;

  public orders = [];
  public subTotal = 0;

  constructor(private http: HttpClient) { }


  public getAllOrders(sessionId: string) {
    return this.http.get(`${environment.apiUrl}/api/orders/myOrders/${sessionId}`)
      .pipe(map((data: Order[]) => {
        this.orders = data;
        return true;
      }))
  }

  public addProductToCard(data) {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    this.count = this.count + 1;
    return this.http.post(`${environment.apiUrl}/api/orders`, data, { headers, responseType: 'text' })
      .pipe(
        tap(data => console.log('addedOrder: ', JSON.stringify(data))),
        tap(event => this.cartCountSubject.next(this.count))
      );

  }

  public deleteOrder(id: number) {
    this.count = this.count - 1;
    return this.http.delete(`${environment.apiUrl}/api/orders/${id}`)
      .pipe(
        tap(data => console.log('deleted order: ', JSON.stringify(data))),
        tap(event => this.cartCountSubject.next(this.count))
      );
  }

  public deleteOrdersFromCartForCurrentUser(userId: string) {
    this.count = 0;
    return this.http.delete(`${environment.apiUrl}/api/orders/clear/${userId}`)
      .pipe(
        tap(data => console.log('deleted orders: ', JSON.stringify(data))),
        tap(event => this.cartCountSubject.next(this.count))
      );
  }

}
